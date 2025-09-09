# Infrastructure Configuration

## Terraform Variable Configuration

### Terraform Cloud Setup

To resolve the warnings about undeclared variables, ensure that Azure authentication variables are set as **Environment Variables** (not Terraform Variables) in your Terraform Cloud workspace:

#### Environment Variables (Sensitive - Environment)
```
ARM_CLIENT_ID=<your-service-principal-client-id>
ARM_CLIENT_SECRET=<your-service-principal-client-secret>
ARM_SUBSCRIPTION_ID=<your-azure-subscription-id>
ARM_TENANT_ID=<your-azure-tenant-id>
```

#### Terraform Variables
```
environment = "dev" (or "prod")
location = "UK West"
```

### Local Development

For local development, set these as environment variables:

**PowerShell:**
```powershell
$env:ARM_CLIENT_ID="your-value"
$env:ARM_CLIENT_SECRET="your-value"
$env:ARM_SUBSCRIPTION_ID="your-value"
$env:ARM_TENANT_ID="your-value"
```

**Bash:**
```bash
export ARM_CLIENT_ID="your-value"
export ARM_CLIENT_SECRET="your-value"
export ARM_SUBSCRIPTION_ID="your-value"
export ARM_TENANT_ID="your-value"
```

### Fixing the Warnings

If you see warnings about undeclared variables, it means these are being passed through terraform.tfvars instead of environment variables. 

**Solution:** In Terraform Cloud:
1. Go to your workspace settings
2. Navigate to Variables
3. Move ARM_* variables from "Terraform Variables" to "Environment Variables"
4. Mark them as "Sensitive"

This follows Terraform best practices for handling authentication credentials.


