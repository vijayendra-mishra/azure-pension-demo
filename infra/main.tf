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
  
  # When using Terraform Cloud remote backend, authentication is handled
  # by the ARM_* environment variables stored in the Terraform Cloud workspace
  # No local authentication is needed
}
