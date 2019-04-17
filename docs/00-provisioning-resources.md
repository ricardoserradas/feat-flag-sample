# Provisioning Resources

> Target platform: Linux, MacOS, Windows

The resources we need for running this full sample can be created
with these ordered instructions.

First of all, let's create some variables to help us keep consistency
when naming and locating our resources. All these commands were run
using a PowerShell console.

```powershell
# Define a variable to store the Resource Group name
PS> $resourceGroupName = "MyResourceGroup"

# Define a variable to store the location we're creating the resources
PS> $resourcesLocation = "eastus"

# For a list of all Azure Locations, use
PS> az account list-locations
```

Now, let's make sure we're operating on the correct subscription:

```powershell
# Log in to your Azure Account
PS> az login

# List all your available subscriptions
PS> az account list

# Select a subscription to operate
PS> az account set -s <subscription-d>
```

## 01 - Resource Group

```powershell
PS>  az group create -n $resourceGroupName -l $resourcesLocation
```

## 02 - Service Plan

```powershell
PS> az appservice plan create -n <name> -g $resourceGroupName -l $resourcesLocation
```

Where:

- `<name>` is the App Service Plan name

## 03 - App Service

```powershell
PS> az webapp acreate -n <name> -p <plan> -g $resourceGroupName
```

Where:

- `<name>` is the Web App name

## 04 - Create Azure SQL Server

```powershell
PS> $sqlServerName = "<name>"
PS> az sql server create -n $sqlServerName -g $resourceGroupName -l $resourcesLocation -u <admin-user-name> -p <admin-password>
```

Where:

- `<name>` is the name for your Azure SQL Server
- `<admin-user-name>` is the login name you want as an administrator for the server
- `<admin-password>` is a strong password for the admin login

## 05 - Create Azure SQL Database

```powershell
PS> az sql db create -n <name> -g $resourceGroupName -s $sqlServerName
```

## Use LocalDB for local SQL Development

> Target platforms: Windows

Instead of using one central database instance for development purposes,
the recommendation is to provision your own sandbox and version the database
structure. This way, no matter what you do with the database schema, you'll not
impact the work other people are doing.

To do so, get started by installing
[SQL Server Data Tools](https://docs.microsoft.com/en-us/sql/ssdt/download-sql-server-data-tools-ssdt?view=sql-server-2017)
to have the tools and software to have your own lightweight local
SQL Server resources.

Develop and add engineering practices to your database will also be covered
on this repo.

If you already have SSDT installed and you want to discover which instances
of LocalDB you have:

- Open the Command Prompt
- Type `sqllocaldb info`
- You'll get an output like this

```powershell
PS> sqllocaldb info
MSSQLLocalDB
ProjectsV13
```

If you want to connect to ProjectsV13, for example, you can use the following
server address: `(localdb)\ProjectsV13`