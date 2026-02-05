# 🏦 Azure Pension Demo

A comprehensive demonstration of modern Azure development practices featuring a pension management system built with .NET 8 Azure Functions, complete CI/CD pipeline, and Infrastructure as Code.

## 🚀 Overview

This project showcases enterprise-grade Azure development patterns including:

- **Azure Functions** with .NET 8 Isolated Worker Model
- **Clean Architecture** with Domain, Application, and Functions layers
- **Automated CI/CD** with GitHub Actions and Release Please
- **Infrastructure as Code** with Terraform
- **API Testing** with Bruno
- **Monitoring & Observability** ready for Azure Application Insights

## 🏗️ Architecture

```
├── src/
│   ├── Domain/           # Core business entities
│   ├── Application/      # Business logic & CQRS queries
│   ├── Functions/        # Azure Functions HTTP triggers
│   └── Tests/           # Unit tests
├── terraform/           # Infrastructure as Code
├── bruno/              # API testing collections
├── .github/workflows/  # CI/CD pipeline
└── .release-please/   # Automated versioning
```

### Technology Stack

- **Runtime**: .NET 8 with Azure Functions v4
- **Architecture**: Clean Architecture + CQRS with MediatR
- **Infrastructure**: Azure Functions Consumption Plan
- **CI/CD**: GitHub Actions with Release Please
- **IaC**: Terraform with Azure Provider
- **Testing**: Bruno for API testing, NUnit for unit tests
- **Monitoring**: Azure Application Insights integration

## 📋 Features

### Pension Management API
- **GET /api/health** - Health check endpoint
- **GET /api/pensions** - Retrieve all pension records
- **GET /api/pension/{id}** - Retrieve specific pension by ID

### Sample Data
The system includes sample pension data for:
- John Smith (Defined Benefit Plan)
- Sarah Johnson (Defined Contribution Plan)  
- Michael Seils (Executive Plan)

## 🔄 CI/CD Pipeline

The project implements a sophisticated CI/CD pipeline with the following flow:

### Development Flow
1. **Pull Request** → Runs tests
2. **Merge to Main** → Tests + Deploy to Dev + Create Release Branch
3. **Release Merge** → Tests + Deploy to Production + Cleanup

### Pipeline Features
- ✅ Automated testing on all PRs
- ✅ Environment-specific deployments (Dev/Prod)
- ✅ Conventional commits with Release Please
- ✅ Automatic versioning and changelog generation
- ✅ Branch cleanup after releases

## 🚀 Quick Start

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Azure Functions Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local)
- [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli)
- [Terraform](https://www.terraform.io/downloads.html) (for infrastructure)

### Local Development

1. **Clone the repository**
   ```bash
   git clone https://github.com/vijayendra-mishra/azure-pension-demo.git
   cd azure-pension-demo
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the solution**
   ```bash
   dotnet build
   ```

4. **Run tests**
   ```bash
   dotnet test
   ```

5. **Start the Functions locally**
   ```bash
   cd src/Functions
   func start
   ```

6. **Test the endpoints**
   - Health: http://localhost:7071/api/health
   - All Pensions: http://localhost:7071/api/pensions
   - Specific Pension: http://localhost:7071/api/pension/1

## 🧪 Testing

### Unit Tests
```bash
dotnet test src/Tests/
```

### API Testing with Bruno
1. Install [Bruno](https://www.usebruno.com/)
2. Open the `bruno/` folder as a collection
3. Select environment (Local/Dev/Prod)
4. Run the test collection

### Available Test Cases
- Health Check validation
- Get all pensions with data validation
- Get individual pension by ID
- Error handling for invalid IDs

## 🏗️ Infrastructure

### Azure Resources
- **Function App**: Consumption plan for cost-effective serverless execution
- **Application Insights**: For monitoring and telemetry
- **Resource Group**: Logical container for all resources

### Terraform Deployment
```bash
cd terraform
terraform init
terraform plan
terraform apply
```

### Environment Configuration
- **Dev Environment**: `terraform/environments/dev/`
- **Prod Environment**: `terraform/environments/prod/`

## 🔧 Configuration

### Local Settings (src/Functions/local.settings.json)
```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated",
    "Environment": "Local",
    "AZURE_FUNCTIONS_ENVIRONMENT": "Development"
  },
  "Host": {
    "LocalHttpPort": 7071,
    "CORS": "*"
  }
}
```

### GitHub Secrets Required
- `AZURE_FUNCTIONAPP_PUBLISH_PROFILE_DEV`: Dev environment publish profile
- `AZURE_FUNCTIONAPP_PUBLISH_PROFILE_PROD`: Prod environment publish profile
- `RELEASE_PLEASE_TOKEN`: GitHub token for release automation

## 📚 Development Guidelines

### Conventional Commits
This project uses [Conventional Commits](https://www.conventionalcommits.org/) for automated versioning:

- `feat:` - New features
- `fix:` - Bug fixes
- `docs:` - Documentation changes
- `style:` - Code style changes
- `refactor:` - Code refactoring
- `test:` - Test additions/changes
- `chore:` - Build process or auxiliary tool changes

### Code Structure
- **Domain Layer**: Pure business entities with no dependencies
- **Application Layer**: Business logic, queries, and commands using MediatR
- **Functions Layer**: HTTP triggers and Azure Functions-specific code
- **Tests**: Comprehensive unit tests for business logic

## 🌐 Deployment

### Development Environment
- **URL**: `https://vjs-pension-dev-func.azurewebsites.net`
- **Deployment**: Automatic on merge to main
- **Purpose**: Integration testing and validation

### Production Environment  
- **URL**: `https://vjs-pension-prod-func.azurewebsites.net`
- **Deployment**: Automatic on release branch merge
- **Purpose**: Live production system

## 📊 Monitoring

The application includes comprehensive logging and monitoring:

- **Health Checks**: Built-in health endpoint for monitoring
- **Application Insights**: Telemetry and performance monitoring
- **Structured Logging**: Consistent logging throughout the application
- **Error Handling**: Graceful error responses with proper HTTP status codes

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Make your changes following the coding guidelines
4. Write tests for new functionality
5. Commit using conventional commit format
6. Push to your branch (`git push origin feature/amazing-feature`)
7. Open a Pull Request

## 📝 License

This project is for demonstration purposes. See the [LICENSE](LICENSE) file for details.

## 📞 Support

For questions or support, please open an issue in the GitHub repository.

---

**Built with ❤️ using Azure Functions, .NET 8, and modern DevOps practices**
