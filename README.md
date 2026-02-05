# 🏦 Azure Pension Demo# 🏦 Azure Pension Demo# 🏦 Azure Pension Demo



A .NET 8 Azure Functions demo with automated CI/CD, Infrastructure as Code, and complete documentation.



## 📚 DocumentationA comprehensive demonstration of modern Azure development practices featuring a pension management system built with .NET 8 Azure Functions, complete CI/CD pipeline, and Infrastructure as Code.A comprehensive demonstration of modern Azure development practices featuring a pension management system built with .NET 8 Azure Functions, complete CI/CD pipeline, and Infrastructure as Code.



- **[Project Overview](./docs/README.md)** - Architecture, setup, and features

- **[CI/CD Pipeline](./docs/CI_CD_PIPELINE.md)** - Pipeline details and jobs

- **[Release-Please Guide](./docs/RELEASE_PLEASE_GUIDE.md)** - Automated releases## 📚 Documentation## 🚀 Overview

- **[Changelog](./docs/CHANGELOG.md)** - Release history



## 🚀 Quick Start

All project documentation has been organized in the `/docs` folder:This project showcases enterprise-grade Azure development patterns including:

```bash

# Clone and setup

git clone https://github.com/vijayendra-mishra/azure-pension-demo.git

cd azure-pension-demo- **[Project Overview & Quick Start](./docs/README.md)** - Architecture, setup instructions, and features- **Azure Functions** with .NET 8 Isolated Worker Model

dotnet restore && dotnet build

- **[CI/CD Pipeline Documentation](./docs/CI_CD_PIPELINE.md)** - Complete pipeline explanation with job specifications- **Clean Architecture** with Domain, Application, and Functions layers

# Run tests

dotnet test- **[Release-Please Guide](./docs/RELEASE_PLEASE_GUIDE.md)** - Team guide for automated versioning and releases- **Automated CI/CD** with GitHub Actions and Release Please



# Start locally- **[Release History](./docs/CHANGELOG.md)** - Full changelog and version history- **Infrastructure as Code** with Terraform

cd src/Functions && func start

```- **API Testing** with Bruno



**API Endpoints:**## 🚀 Quick Start- **Monitoring & Observability** ready for Azure Application Insights

- Health: http://localhost:7071/api/health

- All Pensions: http://localhost:7071/api/pensions

- Specific: http://localhost:7071/api/pension/{id}

### Prerequisites## 🏗️ Architecture

## 🏗️ Stack

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

- **Runtime:** .NET 8 Azure Functions

- **Architecture:** Clean Architecture + CQRS- [Azure Functions Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local)```

- **CI/CD:** GitHub Actions + Release Please

- **Infrastructure:** Terraform- [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli)├── src/

- **Testing:** NUnit + Bruno

│   ├── Domain/           # Core business entities

## 🔄 Deployment

### Get Started│   ├── Application/      # Business logic & CQRS queries

- **Dev:** Automatic on push to main

- **Prod:** Automatic on release│   ├── Functions/        # Azure Functions HTTP triggers



See [CI/CD Pipeline docs](./docs/CI_CD_PIPELINE.md) for details.1. **Clone the repository**│   └── Tests/           # Unit tests



## 📞 Support   ```bash├── terraform/           # Infrastructure as Code



Open a GitHub issue for questions.   git clone https://github.com/vijayendra-mishra/azure-pension-demo.git├── bruno/              # API testing collections



---   cd azure-pension-demo├── .github/workflows/  # CI/CD pipeline



Built with Azure Functions, .NET 8, and modern DevOps practices   ```└── .release-please/   # Automated versioning


```

2. **Restore and build**

   ```bash### Technology Stack

   dotnet restore

   dotnet build- **Runtime**: .NET 8 with Azure Functions v4

   ```- **Architecture**: Clean Architecture + CQRS with MediatR

- **Infrastructure**: Azure Functions Consumption Plan

3. **Run tests**- **CI/CD**: GitHub Actions with Release Please

   ```bash- **IaC**: Terraform with Azure Provider

   dotnet test- **Testing**: Bruno for API testing, NUnit for unit tests

   ```- **Monitoring**: Azure Application Insights integration



4. **Start locally**## 📋 Features

   ```bash

   cd src/Functions### Pension Management API

   func start- **GET /api/health** - Health check endpoint

   ```- **GET /api/pensions** - Retrieve all pension records

- **GET /api/pension/{id}** - Retrieve specific pension by ID

Then test the endpoints:

- Health: http://localhost:7071/api/health### Sample Data

- All Pensions: http://localhost:7071/api/pensionsThe system includes sample pension data for:

- Specific Pension: http://localhost:7071/api/pension/1- John Smith (Defined Benefit Plan)

- Sarah Johnson (Defined Contribution Plan)  

## 🏗️ Architecture- Michael Seils (Executive Plan)



```## 🔄 CI/CD Pipeline

├── src/

│   ├── Domain/           # Core business entitiesThe project implements a sophisticated CI/CD pipeline with the following flow:

│   ├── Application/      # Business logic & CQRS queries

│   ├── Functions/        # Azure Functions HTTP triggers### Development Flow

│   └── Tests/           # Unit tests1. **Pull Request** → Runs tests

├── terraform/           # Infrastructure as Code2. **Merge to Main** → Tests + Deploy to Dev + Create Release Branch

├── bruno/              # API testing collections3. **Release Merge** → Tests + Deploy to Production + Cleanup

├── docs/               # Documentation

└── .github/workflows/  # CI/CD pipeline### Pipeline Features

```- ✅ Automated testing on all PRs

- ✅ Environment-specific deployments (Dev/Prod)

## 📋 Key Features- ✅ Conventional commits with Release Please

- ✅ Automatic versioning and changelog generation

- **Azure Functions** with .NET 8 Isolated Worker Model- ✅ Branch cleanup after releases

- **Clean Architecture** with Domain, Application, and Functions layers

- **Automated CI/CD** with GitHub Actions and Release Please## 🚀 Quick Start

- **Infrastructure as Code** with Terraform

- **API Testing** with Bruno### Prerequisites

- **Health Checks** and Azure Application Insights integration- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

- [Azure Functions Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local)

## 🔄 CI/CD Pipeline- [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli)

- [Terraform](https://www.terraform.io/downloads.html) (for infrastructure)

The project uses automated CI/CD with:

- ✅ Automated testing on all PRs### Local Development

- ✅ Environment-specific deployments (Dev/Prod)

- ✅ Conventional commits with Release Please1. **Clone the repository**

- ✅ Automatic versioning and changelog generation   ```bash

- ✅ Branch cleanup after releases   git clone https://github.com/vijayendra-mishra/azure-pension-demo.git

   cd azure-pension-demo

See [CI/CD Pipeline Documentation](./docs/CI_CD_PIPELINE.md) for details.   ```



## 🎯 Development Workflow2. **Restore dependencies**

   ```bash

1. **Create feature branch** from `main`   dotnet restore

2. **Make changes** and commit with conventional messages (`feat:`, `fix:`, etc.)   ```

3. **Create Pull Request** → Tests run automatically

4. **Merge to main** → Deploys to Dev + Creates release PR3. **Build the solution**

5. **Review release PR** → Merge to trigger production deployment   ```bash

   dotnet build

Learn more in [Release-Please Guide](./docs/RELEASE_PLEASE_GUIDE.md).   ```



## 📊 Environments4. **Run tests**

   ```bash

| Environment | Trigger | URL |   dotnet test

|-----------|---------|-----|   ```

| **Dev** | Every push to main | https://vjs-pension-dev-func-2.azurewebsites.net |

| **Prod** | Release commits only | https://vjs-pension-prod-func-2.azurewebsites.net |5. **Start the Functions locally**

   ```bash

## 🤝 Contributing   cd src/Functions

   func start

1. Fork the repository   ```

2. Create a feature branch

3. Make your changes6. **Test the endpoints**

4. Write tests   - Health: http://localhost:7071/api/health

5. Commit using conventional format: `feat:`, `fix:`, etc.   - All Pensions: http://localhost:7071/api/pensions

6. Push and create a Pull Request   - Specific Pension: http://localhost:7071/api/pension/1



## 📞 Support## 🧪 Testing



For questions or issues, please open a GitHub issue.### Unit Tests

```bash

---dotnet test src/Tests/

```

**Built with ❤️ using Azure Functions, .NET 8, and modern DevOps practices**

### API Testing with Bruno

See [full documentation](./docs/) for more details.1. Install [Bruno](https://www.usebruno.com/)

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
