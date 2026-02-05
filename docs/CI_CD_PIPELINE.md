# 🔄 CI/CD Pipeline Documentation

## Overview

This document explains the complete CI/CD (Continuous Integration/Continuous Deployment) pipeline for the Azure Pension Demo project. The pipeline is fully automated using GitHub Actions and handles testing, building, deploying, and releasing.

---

## 📊 Pipeline Architecture

```
┌─────────────────────────────────────────────────────────────────┐
│                     GitHub Events                               │
│  (Pull Request to main / Push to main)                          │
└──────────────────────────┬──────────────────────────────────────┘
                           │
                    ┌──────▼──────┐
                    │   TEST JOB  │ ✅ Runs on all PRs and pushes
                    └──────┬──────┘
                           │
        ┌──────────────────┼──────────────────┐
        │                  │                  │
   Pull Request      Push to Main (PR)   Push to Main (Release)
        │                  │                  │
    STOP HERE      ┌─────────────────┐  ┌──────────────────┐
                   │  INFRA JOB      │  │  DEPLOY-PROD JOB │
                   │  (if TF changed)│  │  (only on release)
                   └────────┬────────┘  └────────┬─────────┘
                            │                    │
                   ┌────────▼────────┐  ┌────────▼─────────┐
                   │  DEPLOY-DEV JOB │  │  CLEANUP JOB     │
                   │  (Dev testing)  │  │  (delete branches)
                   └────────┬────────┘  └──────────────────┘
                            │
                   ┌────────▼──────────┐
                   │ RELEASE-PLEASE JOB│
                   │ (create release)  │
                   └───────────────────┘
```

---

## 🔄 Complete Workflow

### Scenario 1: Developer Creates a Pull Request

```
1. Developer pushes commits to feature branch
2. Creates Pull Request to main
3. GitHub Actions triggers
   ├── ✅ Runs TESTS job
   │   ├── Restores dependencies
   │   ├── Builds solution
   │   └── Runs unit tests
   │
   └── Merge requirement: ✅ Tests must pass
```

**Result:** Tests run, code review happens. No deployment yet.

---

### Scenario 2: Code Merged to Main (Normal Commit)

```
1. Developer merges PR to main
2. GitHub Actions triggers
   ├── ✅ TESTS job
   │   └── Build & test again
   │
   ├── 🏗️ INFRASTRUCTURE job (if terraform files changed)
   │   ├── Validates Terraform files
   │   ├── Creates Terraform plan
   │   └── Applies changes to Dev
   │
   └── 🚀 DEPLOY-DEV job
       ├── Builds Azure Functions (Release config)
       ├── Publishes to ./output
       └── Deploys to: vjs-pension-dev-func-2
           (https://vjs-pension-dev-func.azurewebsites.net)

3. ✨ RELEASE-PLEASE job runs
   ├── Analyzes commits since last release
   ├── Creates PR with:
   │   ├── Version bump (e.g., 1.4.2 → 1.5.0)
   │   └── Updated CHANGELOG.md
   └── Waits for merge
```

**Result:** Code deployed to Dev, release PR created.

---

### Scenario 3: Release-Please PR Merged

```
1. Team reviews Release-Please PR
   └── Verifies version and CHANGELOG

2. PR merged to main (contains: chore(main): release)

3. GitHub Actions triggers
   ├── ✅ TESTS job
   │   └── Final verification
   │
   └── 🚀 DEPLOY-PROD job
       ├── Builds Azure Functions (Release config)
       ├── Publishes to ./output
       └── Deploys to: vjs-pension-prod-func-2
           (https://vjs-pension-prod-func.azurewebsites.net)

4. 🧹 CLEANUP-RELEASE-BRANCH job
   ├── Deletes release-please branch
   └── Repository cleaned up

5. 📦 GitHub Release created automatically
   ├── Tag: v1.5.0
   ├── Release notes auto-generated
   └── Linked to commits & PRs
```

**Result:** Code deployed to Production, release published.

---

## 📋 Job Specifications

### 1️⃣ TEST Job

**Triggers:** 
- On every Pull Request to main
- On every Push to main

**What it does:**
```yaml
- Checks out code
- Sets up .NET 8 SDK
- Restores NuGet packages
- Builds entire solution
- Runs unit tests with code coverage
- Collects code coverage metrics
```

**Configuration:**
```yaml
runs-on: ubuntu-latest
if: github.event_name == 'pull_request' || 
    (github.event_name == 'push' && github.ref == 'refs/heads/main')
```

**Artifacts:**
- ✅ Build output
- 📊 Code coverage reports (XPlat format)

**Requirements Met:**
- All tests must pass (required for merge)
- No console errors during build

---

### 2️⃣ INFRASTRUCTURE Job

**Triggers:**
- Only on Push to main
- Only if Terraform files changed (auto-detected)

**What it does:**
```yaml
1. Checks if terraform/ files modified
   └── If not changed: Skip job entirely
   
2. Sets up Terraform
   ├── Creates .terraformrc with Terraform Cloud token
   ├── Selects workspace: azure-pension-demo-dev
   └── Initializes Terraform
   
3. Plans infrastructure changes
   ├── Reads terraform/environments/dev/terraform.tfvars
   ├── Creates plan file (tfplan-dev)
   └── Shows what will change
   
4. Applies changes
   ├── Creates/updates Azure resources
   ├── Function App: vjs-pension-dev-func-2
   ├── Storage Account
   ├── Application Insights
   └── App Service Plan
```

**Configuration:**
```yaml
needs: test
environment: dev
if: github.event_name == 'push' && 
    github.ref == 'refs/heads/main' &&
    !contains(github.event.head_commit.message, 'chore(main): release')
```

**Azure Resources Managed:**
- Resource Group: `vjs-pension-dev-rg`
- Function App: `vjs-pension-dev-func-2`
- Storage Account: `vjspensiondev*`
- Application Insights: `vjs-pension-dev-ai`
- App Service Plan: `vjs-pension-dev-plan`

**Authentication:**
```
ARM_CLIENT_ID          → Service Principal ID
ARM_CLIENT_SECRET      → Service Principal Secret
ARM_SUBSCRIPTION_ID    → Azure Subscription
ARM_TENANT_ID         → Azure Tenant
TF_API_TOKEN          → Terraform Cloud token
```

---

### 3️⃣ DEPLOY-DEV Job

**Triggers:**
- Only on Push to main
- Only if NOT a release commit (`chore(main): release`)
- Only if NOT a release-please branch
- Only if INFRASTRUCTURE job succeeded (or skipped)

**What it does:**
```yaml
1. Checks out code
2. Sets up .NET 8 SDK
3. Restores NuGet packages from src/Functions
4. Builds with Release configuration
5. Publishes to ./output folder
   └── Includes all dependencies
6. Deploys to Azure
   ├── App Name: vjs-pension-dev-func-2
   ├── Publish Profile: from secrets
   └── Package: ./output
```

**Configuration:**
```yaml
needs: infrastructure
environment: dev
if: github.event_name == 'push' && 
    github.ref == 'refs/heads/main' && 
    !contains(github.event.head_commit.message, 'chore(main): release') &&
    !contains(github.head_ref, 'release-please')
```

**Deployed To:**
- **URL:** https://vjs-pension-dev-func-2.azurewebsites.net
- **Environment:** Dev
- **Endpoints:**
  - GET /api/health
  - GET /api/pensions
  - GET /api/pension/{id}

**Requirements:**
- Must use Release configuration (not Debug)
- Must pass all tests first
- Must skip if release-please branch

---

### 4️⃣ RELEASE-PLEASE Job

**Triggers:**
- Only on Push to main
- Only if NOT a release commit
- Only if DEPLOY-DEV job succeeded

**What it does:**
```yaml
1. Analyzes commits since last release
   ├── Looks for feat:, fix:, BREAKING CHANGE:
   └── Determines version bump
   
2. Creates Pull Request with:
   ├── Updated CHANGELOG.md
   ├── Version bump in manifest file
   └── Release notes
   
3. PR Title: chore(main): release v1.5.0
   (Example version)
```

**Configuration:**
```yaml
needs: deploy-dev
if: github.event_name == 'push' && 
    github.ref == 'refs/heads/main' && 
    !contains(github.event.head_commit.message, 'chore(main): release') &&
    needs.deploy-dev.result == 'success'
```

**Version Calculation:**
- `feat:` commits → MINOR version bump
- `fix:` commits → PATCH version bump
- `BREAKING CHANGE:` → MAJOR version bump
- Other commits → No release

**Example Flow:**
```
Current version: 1.4.2
Commits: feat: add calculator, fix: date bug
Result: Release 1.5.0 created
```

---

### 5️⃣ DEPLOY-PROD Job

**Triggers:**
- Only on Push to main
- Only if commit message contains `chore(main): release`

**What it does:**
```yaml
1. Checks out code
2. Sets up .NET 8 SDK
3. Builds with Release configuration
4. Publishes to ./output
5. Deploys to Azure Production
   ├── App Name: vjs-pension-prod-func-2
   ├── Publish Profile: from secrets
   └── Package: ./output
```

**Configuration:**
```yaml
needs: test
environment: prod
if: github.event_name == 'push' && 
    github.ref == 'refs/heads/main' && 
    contains(github.event.head_commit.message, 'chore(main): release')
```

**Deployed To:**
- **URL:** https://vjs-pension-prod-func-2.azurewebsites.net
- **Environment:** Production
- **Endpoints:**
  - GET /api/health
  - GET /api/pensions
  - GET /api/pension/{id}

**Safety Features:**
- Only runs on release commits
- Only runs after tests pass
- Manual approval not needed (automated on release)

---

### 6️⃣ CLEANUP-RELEASE-BRANCH Job

**Triggers:**
- Only on Push to main
- Only if commit message contains `chore(main): release`
- Only if DEPLOY-PROD job succeeded

**What it does:**
```yaml
1. Checks out code with fetch-depth: 0
2. Configures git user (GitHub Actions)
3. Finds all branches starting with "release-please"
4. Deletes each release-please branch
5. Cleans up repository
```

**Configuration:**
```yaml
needs: deploy-prod
if: github.event_name == 'push' && 
    github.ref == 'refs/heads/main' && 
    contains(github.event.head_commit.message, 'chore(main): release') &&
    needs.deploy-prod.result == 'success'
```

**Why This Matters:**
- Keeps repository clean
- Removes temporary release branches
- Prevents branch clutter
- Automatic cleanup = no manual work

---

## 🔐 Required Secrets

Store these in GitHub Settings → Secrets and Variables:

| Secret Name | Purpose | Where to Get |
|-----------|---------|--------------|
| `AZURE_FUNCTIONAPP_PUBLISH_PROFILE_DEV` | Deploy to Dev Function App | Azure Portal → Function App → Download Publish Profile |
| `AZURE_FUNCTIONAPP_PUBLISH_PROFILE_PROD` | Deploy to Prod Function App | Azure Portal → Function App → Download Publish Profile |
| `RELEASE_PLEASE_TOKEN` | GitHub token for release-please | GitHub Settings → Personal Access Tokens (write:repo scope) |
| `ARM_CLIENT_ID` | Azure Service Principal ID | Azure Portal → Service Principal |
| `ARM_CLIENT_SECRET` | Azure Service Principal Secret | Azure Portal → Service Principal |
| `ARM_SUBSCRIPTION_ID` | Azure Subscription ID | Azure Portal → Subscriptions |
| `ARM_TENANT_ID` | Azure Tenant ID | Azure Portal → Tenant Properties |
| `TF_API_TOKEN` | Terraform Cloud API Token | Terraform Cloud → Account Settings → Tokens |

---

## 📊 Job Dependencies

```
TEST (all events)
├── INFRASTRUCTURE (push main, TF changed)
│   └── DEPLOY-DEV (push main, not release)
│       └── RELEASE-PLEASE (push main, success)
│
└── DEPLOY-PROD (push main, release commit)
    └── CLEANUP-RELEASE-BRANCH (success)
```

**Key Rule:** Jobs only run if their dependencies succeed.

---

## 🔍 How to Debug Pipeline Issues

### 1. Check Job Logs
```
GitHub → Actions → [Workflow Name] → [Job] → Logs
```

### 2. Common Issues

| Issue | Solution |
|-------|----------|
| Tests failing | Check build output, fix code locally first |
| Deploy failing | Verify publish profile is current, check Azure access |
| Terraform failing | Check TF_API_TOKEN is valid, workspace exists |
| Release-Please not running | Check if previous job succeeded |

### 3. Manual Debugging
```bash
# Run tests locally
dotnet test

# Build Functions
dotnet build src/Functions/Functions.csproj

# Publish locally
dotnet publish src/Functions/Functions.csproj --configuration Release
```

---

## 📈 Monitoring & Observability

### GitHub Actions Dashboard
- **Location:** GitHub → Actions tab
- **Shows:** All workflow runs, pass/fail status
- **Artifacts:** Download build outputs, logs

### Application Insights (Production)
- **Dev:** `vjs-pension-dev-ai`
- **Prod:** `vjs-pension-prod-ai`
- **Monitors:** Performance, errors, requests

### Health Endpoints
```
Dev:  https://vjs-pension-dev-func-2.azurewebsites.net/api/health
Prod: https://vjs-pension-prod-func-2.azurewebsites.net/api/health
```

---

## 🚀 Deployment Timeline Example

```
Wednesday 10:00 AM
├── Developer commits: feat: add pension calculator
└── Pushes to feature branch

Wednesday 10:30 AM
├── Creates Pull Request to main
└── CI/CD runs TESTS ✅

Wednesday 02:00 PM
├── Code review approved
└── PR merged to main

Wednesday 02:01 PM - GitHub Actions Runs
├── TESTS ✅ (5 min)
├── INFRASTRUCTURE 🏗️ (optional, 10 min)
├── DEPLOY-DEV 🚀 (7 min)
│   └── Live in Dev: https://vjs-pension-dev-func-2.azurewebsites.net
│
└── RELEASE-PLEASE 📦
    └── Creates PR: chore(main): release v1.5.0

Wednesday 03:00 PM
├── Team reviews Release PR
└── Verifies CHANGELOG looks good

Wednesday 03:15 PM
├── Merge Release PR
└── Commit message: chore(main): release v1.5.0

Wednesday 03:16 PM - GitHub Actions Runs (Release)
├── TESTS ✅
├── DEPLOY-PROD 🚀 (7 min)
│   └── Live in Prod: https://vjs-pension-prod-func-2.azurewebsites.net
│
└── CLEANUP-RELEASE-BRANCH 🧹
    └── Deleted release-please branch

Wednesday 03:23 PM - Release Published
├── GitHub Release v1.5.0 created
├── Git tag: v1.5.0
├── Release notes auto-generated
└── ✨ Production live!
```

---

## 📝 Environment Comparison

| Aspect | Dev | Prod |
|--------|-----|------|
| **Trigger** | Every push to main | Only release commits |
| **Terraform** | Applied automatically | Same infrastructure |
| **URL** | `-dev-` subdomain | `-prod-` subdomain |
| **Health Check** | `/api/health` endpoint | `/api/health` endpoint |
| **Approval** | Automatic | Automatic (after release PR) |
| **Downtime** | No impact on prod | Minimal (seconds) |
| **Rollback** | Revert and redeploy | Revert and redeploy |

---

## 🔄 Key Concepts

### Continuous Integration (CI)
- Every push triggers tests
- Code must pass tests before merge
- Automated validation
- Prevents broken code in main branch

### Continuous Deployment (CD)
- Automatic deployment after merge
- No manual deployment steps
- Consistent deployments
- Same process every time

### Infrastructure as Code (IaC)
- Terraform manages Azure resources
- Version controlled in git
- Automated provisioning
- Easy to reproduce environments

---

## 🎯 Best Practices

### For Developers

1. **Use conventional commits**
   ```bash
   git commit -m "feat: add new calculator"
   git commit -m "fix: correct validation"
   ```

2. **Test locally before push**
   ```bash
   dotnet test
   dotnet build
   ```

3. **Create descriptive PRs**
   - Clear title
   - Link to issues
   - Explain changes

4. **Don't modify CHANGELOG manually**
   - Let release-please update it
   - Prevents merge conflicts

### For Ops/Release

1. **Review release-please PR carefully**
   - Verify version bump is correct
   - Check CHANGELOG entries
   - Ensure all features are listed

2. **Merge only when ready**
   - All team feedback incorporated
   - Documentation updated
   - No known issues

3. **Monitor production after release**
   - Check health endpoints
   - Review Application Insights
   - Be ready to rollback if needed

---

## 🆘 Support

### If something fails:

1. **Check the job logs** - GitHub Actions shows exactly what failed
2. **Verify secrets** - Make sure Azure credentials are correct
3. **Test locally** - Reproduce the issue locally first
4. **Check dependencies** - Ensure all required SDKs are installed
5. **Ask the team** - Reach out if stuck

### Common Commands

```bash
# View git history
git log --oneline

# View releases
git tag --list

# Check remote branches
git branch -r

# View latest commit
git show --stat
```

---

## 📚 Related Files

- **Workflow:** `.github/workflows/ci-cd.yml`
- **Release Config:** `.release-please/release-please-config.json`
- **Terraform:** `terraform/` directory
- **Changelog:** `.release-please/CHANGELOG.md` & `CHANGELOG.md`
- **Guide:** `RELEASE_PLEASE_GUIDE.md`

---

## ✅ Verification Checklist

Before going live with new changes:

- [ ] All tests pass locally
- [ ] Code builds successfully
- [ ] Functions work in Dev environment
- [ ] Release PR looks correct
- [ ] CHANGELOG has all features listed
- [ ] Version bump makes sense (semver)
- [ ] Team has reviewed release notes
- [ ] Production deployment completes
- [ ] Health endpoints respond correctly
- [ ] No errors in Application Insights

---

**Last Updated:** February 5, 2026  
**Pipeline Status:** ✅ Active and Monitoring
