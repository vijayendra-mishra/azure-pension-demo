# 📦 Release Please - Team Guide

## What is Release-Please?

**Release-Please** is an automated tool that:
- 🔄 **Automatically generates releases** based on your commit messages
- 📝 **Auto-updates CHANGELOG** with version history
- 🏷️ **Creates Git tags** for each release
- 🚀 **Publishes releases** to GitHub with notes
- ✨ **Simplifies versioning** using Semantic Versioning

**In simple terms:** It removes the manual work of creating releases and keeps version numbers consistent.

---

## 🎯 How It Works (The Flow)

### Normal Development Workflow

```
1. Developer commits code with conventional messages
   ↓
2. Code gets merged to 'main' branch
   ↓
3. Release-Please runs automatically
   ↓
4. Creates a Pull Request with:
   - Updated version number
   - Updated CHANGELOG
   ↓
5. You review & merge the PR
   ↓
6. Release-Please creates a GitHub Release
   ↓
7. CI/CD deploys to Production
```

### Visual Example

```
Commits on main:
├── feat: add new pension calculations     → Will trigger MINOR version bump
├── fix: correct pension date validation   → Will trigger PATCH version bump
└── docs: update README

Release-Please Does This Automatically:
├── Bumps version 1.4.2 → 1.5.0
├── Updates CHANGELOG with new features
├── Creates git tag v1.5.0
├── Creates GitHub Release with release notes
└── CI/CD pipeline deploys it
```

---

## 📋 Semantic Versioning Format: `MAJOR.MINOR.PATCH`

Release-Please uses this format to decide version numbers based on commit types:

| Commit Type | Example | Version Change | Why |
|-----------|---------|----------------|-----|
| `feat:` | `feat: add pension calculator` | `1.4.2` → `1.5.0` | New feature (MINOR) |
| `fix:` | `fix: correct date format` | `1.4.2` → `1.4.3` | Bug fix (PATCH) |
| `BREAKING CHANGE:` | `feat: remove old API\n\nBREAKING CHANGE: ...` | `1.4.2` → `2.0.0` | Breaking change (MAJOR) |
| `docs:`, `chore:`, `style:` | `docs: update README` | No version bump | No release |

---

## ✍️ How to Write Commits for Release-Please

### Commit Message Format

```
type(scope): short description

optional body explaining why

optional footer
```

### ✅ Good Examples

```bash
# New feature
git commit -m "feat: add pension contribution calculator"

# Bug fix
git commit -m "fix: correct pension date validation"

# Breaking change
git commit -m "feat: redesign pension API response

BREAKING CHANGE: response format changed from XML to JSON"

# With scope for clarity
git commit -m "feat(pension): add new calculation method"
git commit -m "fix(ui): correct button alignment on mobile"
```

### ❌ Bad Examples (Won't Trigger Release)

```bash
# Too vague
git commit -m "update code"

# Wrong format
git commit -m "Updated pension calculations"

# No type prefix
git commit -m "Added new features"
```

---

## 🔍 What You'll See in GitHub

### 1️⃣ Release-Please Creates a PR

When commits are pushed to `main`, release-please automatically creates a PR like:

```
Title: chore(main): release v1.5.0

Files Changed:
- CHANGELOG.md (updated with new version)
- .release-please/release-please-manifest.json (version bump)

Description:
🎉 This PR contains the following changes:
- feat: add pension calculator (#123)
- fix: correct date format (#124)
```

### 2️⃣ You Review & Merge

Simply review the changes (especially the CHANGELOG) and merge it.

### 3️⃣ GitHub Release is Created

After merging, release-please creates a GitHub Release automatically:

```
Release: v1.5.0
Tag: v1.5.0
Release Notes:
## 🎉 Features
- Add pension calculator
- Improve calculation accuracy

## 🐛 Bug Fixes
- Correct date validation

## 📚 Documentation
- Update API docs
```

---

## 🚀 Your Current Setup (azure-pension-demo)

Your project already has release-please configured! Here's what's enabled:

### Configuration File
**Location:** `.release-please/release-please-config.json`

```json
{
  "release-type": "simple",
  "packages": {
    ".": {
      "changelog-path": ".release-please/CHANGELOG.md"
    }
  }
}
```

### GitHub Actions Workflow
**Location:** `.github/workflows/ci-cd.yml`

The `release-please` job runs automatically:
```yaml
release-please:
  needs: deploy-dev
  runs-on: ubuntu-latest
  steps:
    - uses: googleapis/release-please-action@v4
```

---

## 📝 Team Guidelines

### For Developers

**Do:**
- ✅ Use conventional commit format: `type: description`
- ✅ Use `feat:` for new features
- ✅ Use `fix:` for bug fixes
- ✅ Use `docs:`, `chore:`, `style:` for non-feature changes
- ✅ Write clear, descriptive messages
- ✅ Include breaking changes in commit body

**Don't:**
- ❌ Use vague messages like "update" or "fix stuff"
- ❌ Skip the type prefix (`feat:`, `fix:`)
- ❌ Manually create version tags (let release-please do it)
- ❌ Edit CHANGELOG manually (release-please auto-generates it)

### For Release Management

When release-please creates a PR:
1. **Review** the CHANGELOG entries
2. **Verify** the version bump is correct
3. **Merge** the PR to main
4. **Release-Please** handles the rest automatically
5. **CI/CD** deploys to production

---

## 🔄 Release Workflow Timeline

```
Day 1-2: Development
├── Developer commits: feat: add new feature
├── Developer commits: fix: bug fix
└── Code reviewed and merged to main

Day 3: Release-Please Runs
├── Analyzes commits since last release
├── Creates PR with:
│   ├── Version bump (1.4.2 → 1.5.0)
│   └── Updated CHANGELOG
└── Sends notification

Day 3 (Later): Release Review
├── Team reviews PR
├── Verifies CHANGELOG looks good
└── Merges to main

Day 3 (Even Later): Automatic Release
├── Release-Please detects merge
├── Creates GitHub Release v1.5.0
├── Tags commit as v1.5.0
└── CI/CD deploys to production
```

---

## ❓ FAQs

### Q: Can I manually create a release?
**A:** You can, but you shouldn't. Let release-please handle it automatically to keep things consistent.

### Q: What if release-please creates a PR with wrong version?
**A:** Review the commits since the last release. If they only contain `fix:` commits, it should be a PATCH bump. If you disagree, you can manually adjust before merging.

### Q: Why does it create a PR instead of releasing directly?
**A:** This gives you a chance to review:
- ✅ The version number
- ✅ The CHANGELOG entries
- ✅ The release notes

Before it's locked in as a release.

### Q: Do I need to manually update version numbers anywhere?
**A:** No! Release-please handles all version updates automatically:
- CHANGELOG.md
- Git tags
- GitHub Releases
- `.release-please/release-please-manifest.json`

### Q: What counts as a breaking change?
**A:** Changes that require users to update their code:
- Removing a public method
- Changing API response format
- Removing configuration options
- Changing authentication requirements

Mark these with: `BREAKING CHANGE: description` in commit body

### Q: How do I see the release history?
**A:** Check three places:
1. **GitHub Releases** - https://github.com/vijayendra-mishra/azure-pension-demo/releases
2. **CHANGELOG.md** - In your repository
3. **Git Tags** - `git tag --list`

---

## 📚 Example Release Cycle

### Scenario: You develop 3 features and 1 bug fix

**Step 1: Make commits**
```bash
git commit -m "feat: add pension forecast calculation"
git commit -m "feat: add pdf export functionality"  
git commit -m "fix: correct pension date display"
git commit -m "docs: update API documentation"
```

**Step 2: Push to main** (after code review)
```bash
git push origin main
```

**Step 3: Release-Please runs (automatic)**
Creates PR with:
```
- Version: 1.4.2 → 1.5.0 (because of 2 feat: commits)
- CHANGELOG updated with new features
```

**Step 4: Team reviews and merges**
```
✅ All looks good! Merging...
```

**Step 5: GitHub Release created (automatic)**
```
Release v1.5.0
- Add pension forecast calculation
- Add PDF export functionality
- Fix pension date display

✨ Live in production!
```

---

## 🎓 Learning Resources

- **Conventional Commits:** https://www.conventionalcommits.org/
- **Semantic Versioning:** https://semver.org/
- **Release-Please GitHub:** https://github.com/googleapis/release-please
- **Our Project Release History:** `.release-please/CHANGELOG.md`

---

## 🤔 Questions?

If you have questions about release-please:
1. Check the **FAQs** section above
2. Look at the **`.release-please/CHANGELOG.md`** to see examples
3. Review recent **GitHub Releases** for patterns
4. Ask your team lead!

---

**Remember:** The goal of release-please is to make releases **automatic, consistent, and transparent** for the entire team! 🎉
