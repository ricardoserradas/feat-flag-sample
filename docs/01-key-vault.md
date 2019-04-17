# Use Azure Key Vault to protect application secrets

This is the best practice to store application's sensitive data so you:

- Do not store sensitive information in your source control
  - Not even by mistake
- Do not store sensitive data on configuration files in your environment

**Source**: https://docs.microsoft.com/en-us/azure/architecture/multitenant-identity/key-vault

## Create/Configure the Key Vault

> Target platform: Windows
>
> So far, if you're operating on Linux or MacOS, please refer to [this link](01-key-vault-unix.md).

First, do the following steps to have the `Setup-KeyVault.ps1` script:

> I'm instructing you to clone my fork because the [Pull Request](https://github.com/mspnp/multitenant-saas-guidance/pull/108)
> was not approved yet.

- Clone `https://github.com/ricardoserradas/multitenant-saas-guidance.git`
- Checkout the branch `riserrad/fix-pwsh-scripts-kv`

```powershell
# Go to the script folder
PS>  cd multitenant-saas-guidance\scripts

# Create the Key Vault
PS> .\Setup-KeyVault.ps1 -KeyVaultName <<key vault name>> -ResourceGroupName $resourceGroupName -Location $resourcesLocation

# Add the Web App ID to the Access policies
# At this point, I needed to have my application already registered to the Azure Active Directory
PS> .\Setup-KeyVault.ps1 -KeyVaultName <<key vault name>> -ApplicationIds @("<<Surveys app id>>", "<<Surveys.WebAPI app ID>>")

# Add the database connection string to the Key Vault
# At this point, I needed to have my Azure SQL database already created
PS> .\Setup-KeyVault.ps1 `
-SubscriptionId "<subscription-id>" `
-ResourceGroupName $resourceGroupName `
-KeyVaultName riserradff `
-KeyName Data--MainDatabaseConnectionString `
-KeyValue "<connection string to the Azure SQL database>"
```

### Improvements mapped

- [Provide guidance for generating certificate data for other platforms](https://github.com/MicrosoftDocs/architecture-center/issues/1416)
- [Fix missing parameters on PowerShell script](https://github.com/mspnp/multitenant-saas-guidance/pull/108)
- [Adjusting key-vault.md to support updates on Setup-KeyVault.ps1](https://github.com/MicrosoftDocs/architecture-center/pull/1418)
- [The article does not show hot to retrieve Secrets from Key Vault](https://github.com/MicrosoftDocs/architecture-center/issues/1492)
  - For a clear guidance on how to consume a Key Vault from a .NET Core App, use
  [this blog post](https://www.humankode.com/asp-net-core/how-to-store-secrets-in-azure-key-vault-using-net-core)
  as a reference