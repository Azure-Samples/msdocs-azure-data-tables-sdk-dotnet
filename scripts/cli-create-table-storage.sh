LOCATION='eastus'
RESOURCE_GROUP_NAME='rg-msdocs-tables-sdk-demo'
STORAGE_ACCOUNT_NAME='stmsdocstablessdkdemo'
TABLE_NAME='WeatherData'


az group create \
    --location $LOCATION \
    --name $RESOURCE_GROUP_NAME


az storage account create \
    --resource-group $RESOURCE_GROUP_NAME \
    --location $LOCATION \
    --name $STORAGE_ACCOUNT_NAME


az storage account keys list \
    --resource-group $RESOURCE_GROUP_NAME \
    --account-name $STORAGE_ACCOUNT_NAME


az storage table create \
    --name $TABLE_NAME \
    --account-name $STORAGE_ACCOUNT_NAME


az storage account show-connection-string \
    --resource-group $RESOURCE_GROUP_NAME \
    --name $STORAGE_ACCOUNT_NAME