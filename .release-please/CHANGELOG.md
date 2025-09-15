# Changelog

## [1.0.0] - 2025-09-10

### Features

- feat: Complete project restructuring with clean solution architecture
- feat: Add Azure Functions with .NET 8 isolated worker model
- feat: Implement CI/CD pipeline with GitHub Actions
- feat: Add Bruno API testing configuration
- feat: Configure Terraform infrastructure as code
- feat: Add release-please automation for semantic releases

### Build System

- build: Move tests to src/Tests directory for better organization
- build: Configure Directory.Build.props for centralized package management
- build: Set up GitHub Actions workflows for automated deployment

### Continuous Integration

- ci: Add simplified CI/CD pipeline using publish profiles
- ci: Configure environment-specific deployments (dev/prod)
- ci: Add release-please for automated release management

### Infrastructure

- infra: Configure Terraform with .NET 8 Azure Functions
- infra: Set up Terraform Cloud remote backend
- infra: Add proper variable declarations to eliminate warnings
