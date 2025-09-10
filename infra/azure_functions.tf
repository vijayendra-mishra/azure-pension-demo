resource "azurerm_resource_group" "pension" {
  name     = "vjs-pension-${var.environment}-rg"
  location = var.location

  tags = {
    "azd-env-name" = var.environment
  }
}

resource "azurerm_storage_account" "pension" {
  name                     = "vjspensiondemo${var.environment}"
  resource_group_name      = azurerm_resource_group.pension.name
  location                 = azurerm_resource_group.pension.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
  min_tls_version          = "TLS1_2"

  tags = {
    "azd-env-name" = var.environment
  }
}

resource "azurerm_application_insights" "pension" {
  name                = "vjs-pension-${var.environment}-ai"
  location            = azurerm_resource_group.pension.location
  resource_group_name = azurerm_resource_group.pension.name
  application_type    = "web"

  tags = {
    "azd-env-name" = var.environment
  }
}

# App Service Plan per environment (FREE TIER!)
resource "azurerm_service_plan" "pension" {
  name                = "vjs-pension-${var.environment}-plan"
  location            = azurerm_resource_group.pension.location
  resource_group_name = azurerm_resource_group.pension.name
  os_type             = "Linux"
  sku_name            = "F1"  # FREE TIER - $0 cost!

  tags = {
    "azd-env-name" = var.environment
  }
}

resource "azurerm_linux_function_app" "pension" {
  name                = "vjs-pension-${var.environment}-func"
  location            = azurerm_resource_group.pension.location
  resource_group_name = azurerm_resource_group.pension.name
  service_plan_id     = azurerm_service_plan.pension.id

  storage_account_name       = azurerm_storage_account.pension.name
  storage_account_access_key = azurerm_storage_account.pension.primary_access_key

  site_config {
    application_stack {
      dotnet_version              = "8.0"
      use_dotnet_isolated_runtime = true
    }
  }

  app_settings = {
    "FUNCTIONS_WORKER_RUNTIME"             = "dotnet-isolated"
    "WEBSITE_RUN_FROM_PACKAGE"             = "1"
    "Environment"                          = var.environment
    "APPINSIGHTS_INSTRUMENTATIONKEY"       = azurerm_application_insights.pension.instrumentation_key
    "APPLICATIONINSIGHTS_CONNECTION_STRING" = azurerm_application_insights.pension.connection_string
  }
}
