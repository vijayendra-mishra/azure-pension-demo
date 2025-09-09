# 🚀 Azure Pension Demo - Release Workflow

## 📋 Demo Workflow Overview

This project uses a **simplified trunk-based development** approach perfect for demos and interviews.

### 🔄 Complete Release Process

#### **1. Feature Development**
```bash
# Work on feature branches
git checkout -b feature/new-pension-endpoint
# ... make changes ...
git push origin feature/new-pension-endpoint
# Create PR to main → merge when ready
```

#### **2. Create Release (Manual Trigger)**
```
GitHub Actions → Release → Run workflow → Enter version (e.g., 1.2.0)
```

**What happens automatically:**
1. ✅ Creates `release/1.2.0` branch
2. ✅ Triggers **DEV deployment** (Azure Functions)
3. ✅ Creates **Pull Request** from release to main
4. ✅ PR includes deployment checklist

#### **3. Release to Production**
```
Review PR → Approve → Merge to main
```

**What happens automatically:**
1. ✅ Runs **Terraform Plan** for PROD (manual apply required)
2. ✅ Deploys to **PROD environment** (Azure Functions)
3. ✅ **Deletes release branch** (cleanup)

---

## 🏗️ Infrastructure Management

### **DEV Environment**
- **Manual**: Run Terraform commands locally
- **Workspace**: `dev` (CLI-driven)
```bash
cd infra
terraform workspace select dev
terraform plan
terraform apply  # when ready
```

### **PROD Environment** 
- **Automatic Planning**: When merging to main
- **Manual Apply**: Review plan in Terraform Cloud, then apply
- **Workspace**: `prod` (repo-driven)

---

## 🎯 Required GitHub Secrets

### **Function App Deployment**
```
AZURE_FUNCTIONAPP_PUBLISH_PROFILE_DEV   # For DEV deployments
AZURE_FUNCTIONAPP_PUBLISH_PROFILE_PROD  # For PROD deployments
```

### **Infrastructure (Terraform)**
```
TF_API_TOKEN        # Terraform Cloud API token
ARM_CLIENT_ID       # Azure Service Principal ID  
ARM_CLIENT_SECRET   # Azure Service Principal Secret
ARM_SUBSCRIPTION_ID # Azure Subscription ID
ARM_TENANT_ID       # Azure Tenant ID
```

---

## 🔍 Workflow Files

| File | Purpose | Triggers |
|------|---------|----------|
| `ci-cd.yml` | Build, test, deploy apps | Push to main/release branches |
| `infrastructure.yml` | Terraform plan for PROD | Push to main (infra changes) |
| `release.yml` | Create release branches | Manual workflow dispatch |

---

## 🎪 Demo Script

### **For Interviews/Demos:**

1. **Show Feature Development**
   ```bash
   git checkout -b feature/add-health-endpoint
   # Add new endpoint
   git commit -m "Add health check endpoint"
   git push origin feature/add-health-endpoint
   # Create PR → merge
   ```

2. **Show Release Process**
   - GitHub → Actions → Release → Run workflow → "1.0.1"
   - Show automatic DEV deployment
   - Show created PR with checklist

3. **Show Production Deploy**
   - Merge release PR
   - Show Terraform plan running
   - Show PROD deployment
   - Show automatic cleanup

4. **Show Infrastructure**
   ```bash
   cd infra
   terraform workspace select dev
   terraform plan  # Show local dev changes
   ```

### **Key Demo Points:**
- ✅ **Automated CI/CD** with proper environments
- ✅ **Infrastructure as Code** with Terraform
- ✅ **Security**: Manual approval for PROD infrastructure
- ✅ **Clean Workflow**: Trunk-based with release branches
- ✅ **Real Azure Resources**: Functions, Storage, App Insights

---

## 🎯 Benefits for Interview

- **Modern DevOps**: Shows current best practices
- **Azure Knowledge**: Real Azure services and deployment
- **Security Awareness**: Separate dev/prod, manual approvals
- **Clean Code**: .NET 8, clean architecture, testing
- **Professional Setup**: Proper branching strategy and automation
