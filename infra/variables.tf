variable "environment" {
  description = "The environment to deploy (dev or prod)"
  type        = string
}

variable "location" {
  description = "Azure region"
  type        = string
  default     = "East US"
}
