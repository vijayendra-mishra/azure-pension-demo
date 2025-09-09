# Azure Pension Demo

This project demonstrates a C# Azure Functions app for managing pension details, using EF Core (with Azure SQL Edge), Mediatr for CQRS, and trunk-based GitHub deployment to Azure via Terraform.

## Architecture
- **Azure Functions (C#)**: API endpoints for pension operations (.NET 9)
- **EF Core + Azure SQL Edge**: Data persistence
- **Mediatr**: CQRS pattern for clean separation
- **Terraform**: Azure provisioning (dev/prod)
- **GitHub Actions**: Trunk-based deployment

## Local Development
- Use Docker Compose for local Azure SQL Edge (see below)
- Run the Functions app from `src/Functions`

## Structure
- `src/` - All application code
- `infra/` - Terraform scripts

## Quick Start
1. `docker-compose up` (for local Azure SQL Edge)
2. `dotnet run --project src/Functions` (run API)

---

See subfolder READMEs for details.