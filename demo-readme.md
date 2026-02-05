# Azure Pension Demo

A .NET 8 Azure Functions application for managing pension records.

## Features

- Pension management API
- Azure Functions serverless compute
- CI/CD with GitHub Actions
- Infrastructure as Code with Terraform
- Automated releases with Release Please

## Getting Started

1. Clone the repo
2. Run `dotnet build`
3. Run `dotnet test`
4. Start: `cd src/Functions && func start`

Test endpoint: http://localhost:7071/api/health

## Endpoints

- `GET /api/health` - Health check
- `GET /api/pensions` - List all pensions
- `GET /api/pension/{id}` - Get pension by ID

## Docs

See `/docs` folder for detailed documentation.
