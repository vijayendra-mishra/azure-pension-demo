terraform {
  backend "remote" {
    organization = "vjs-terraform-org"
    workspaces {
      prefix = "azure-pension-demo-"
    }
  }
}
