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
  
  # Disable Azure CLI authentication since it's broken on this system
  use_cli = false
  
  # Explicitly provide subscription_id when not using CLI
  subscription_id = "780e8e76-e1c2-412d-b6d3-cc253736e07d"
  
  # Use Service Principal authentication via environment variables:
  # ARM_CLIENT_ID, ARM_CLIENT_SECRET, ARM_TENANT_ID
  # These are set in Terraform Cloud workspace variables
}
