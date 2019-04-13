# Full Feature Flag sample (with DevOps practices applied)

I'm creating this repo with the idea of having a full sample of Feature Flags
in action. By action, I mean having:

- A Web App with a feature to be implemented
- Feature Flag coding already in place
- ARM templates for deploying the sample infrastructure
- Good engineering practices
- A step-by-step tutorial for you to *feel* the benefits of the technique

## Engineering practices reference

### Use Azure Key Vault to protect application secrets

This is the best practice to store application's sensitive data so you:

- Do not store sensitive information in your source control
  - Not even by mistake
- Do not store sensitive data on configuration files in your environment

**Source**: https://docs.microsoft.com/en-us/azure/architecture/multitenant-identity/key-vault

### Commands used, in a nutshell

#### Create Azure Resources

```bash
# TODO: Add bash scripts I used to create resource groups,
# app service and SQL DB here
```

#### Create/Configure the Key Vault

First, do the following steps to have the `Setup-KeyVault.ps1` script:

> I'm instructing you to clone my fork because the [Pull Request](https://github.com/mspnp/multitenant-saas-guidance/pull/108)
> was not approved yet.

- Clone `https://github.com/ricardoserradas/multitenant-saas-guidance.git`
- Checkout the branch `riserrad/fix-pwsh-scripts-kv`

```powershell
# Go to the script folder
> cd multitenant-saas-guidance\scripts

# Create the Key Vault
.\Setup-KeyVault.ps1 -KeyVaultName <<key vault name>> -ResourceGroupName <<resource group name>> -Location <<location>>

# Add the Web App ID to the Access policies
# At this point, I needed to have my application already registered to the Azure Active Directory
.\Setup-KeyVault.ps1 -KeyVaultName <<key vault name>> -ApplicationIds @("<<Surveys app id>>", "<<Surveys.WebAPI app ID>>")

# Add the database connection string to the Key Vault
# At this point, I needed to have my Azure SQL database already created
.\Setup-KeyVault.ps1 `
-SubscriptionId 7cd9fc5c-e5ce-446d-9086-f6b0742565db `
-ResourceGroupName feat-flag-sample `
-KeyVaultName riserradff `
-KeyName Data--MainDatabaseConnectionString `
-KeyValue "<<connection string to the Azure SQL database>>"
```

### Improvements mapped

- [Provide guidance for generating certificate data for other platforms](https://github.com/MicrosoftDocs/architecture-center/issues/1416)
- [Fix missing parameters on pwsh script](https://github.com/mspnp/multitenant-saas-guidance/pull/108)
- [Adjusting key-vault.md to support updates on Setup-KeyVault.ps1](https://github.com/MicrosoftDocs/architecture-center/pull/1418)

## Use LocalDB for local SQL Development

Install SQL Server Data Tools to start a local development for your database.

Develop and add engineering practices to your database will also be covered
on this repo.

If you already have SSDT installed and you want to discover which instances
of LocalDB you have:

- Open the Command Prompt
- Type `sqllocaldb info`
- You'll get an output like this

```bash
> sqllocaldb info
MSSQLLocalDB
ProjectsV13
```

If you want to connect to ProjectsV13, for example, you can use the following
server address: `(localdb)\ProjectsV13`