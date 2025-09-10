variable "environment" {
  description = "The environment to deploy (dev or prod)"
  type        = string
}

variable "location" {
  description = "Azure region"
  type        = string
  default     = "East US"
}

# Azure authentication variables - declared to silence warnings
# These are provided by Terraform Cloud and used automatically by the azurerm provider
variable "ARM_CLIENT_ID" {
  description = "Azure Service Principal Client ID"
  type        = string
  sensitive   = true
  default     = null
}

variable "ARM_CLIENT_SECRET" {
  description = "Azure Service Principal Client Secret"
  type        = string
  sensitive   = true
  default     = null
}

variable "ARM_SUBSCRIPTION_ID" {
  description = "Azure Subscription ID"
  type        = string
  sensitive   = true
  default     = null
}

variable "ARM_TENANT_ID" {
  description = "Azure Tenant ID"
  type        = string
  sensitive   = true
  default     = null
}
