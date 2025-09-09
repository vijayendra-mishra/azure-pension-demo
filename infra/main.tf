terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = ">= 3.0.0"
    }
  }
  required_version = ">= 1.0.0"
}

provider "azurerm" {
  features {}
  
  # Authentication is handled via environment variables:
  # TF_VAR_ARM_CLIENT_ID, TF_VAR_ARM_CLIENT_SECRET, 
  # TF_VAR_ARM_SUBSCRIPTION_ID, TF_VAR_ARM_TENANT_ID
  # These should be set in Terraform Cloud workspace variables
  # or GitHub Actions secrets, not in terraform.tfvars
}
