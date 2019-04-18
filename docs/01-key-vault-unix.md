# Creating an Azure Key Vault on Linux and MacOs

> Target platforms: Linux, MacOs, Windows

```bash
# Creating the Key Vault
az keyvault create \
  -n <name> \
  -g <resourcegroupname> \
  -l <location>

# Setting the policy to let the Application
# list and get secrets on this Key Vault
az keyvault set-policy \
  -n <name> \
  --object-id <app-id> \
  --secret-permissions get list

# Adding the Database Connection String to the Key Vault
az keyvault secret set \
  -n "Data--MainDatabaseConnectionString \
  --vault-name "<name>" \
  --value "<database-connection-string>"
```

Where:

- `<name>` is the name of the Azure Key Vault you're creating
- `<app-id>` is the ID of the application you registered on your Azure Active Directory
- `<database-connection-string>` is the connection string to access
the database you created

After you have your Key Vault configured properly, you can get back to the
[main](01-key-vault.md#Using-the-Key-Vault-from-the-Web-App)
to consume the Key Vault from the Web App.