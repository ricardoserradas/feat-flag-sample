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

I'm adding [this practice](https://docs.microsoft.com/en-us/azure/architecture/multitenant-identity/key-vault)
to the application. However, this tutorial only supports using PowerShell
for you to get started. Evaluating two options:

- Adapting the [Setup-KeyVault.ps1](./Setup-KeyVault.ps1) script to support
PowerShell Core
- Creating special [scripts/instructions](./How-to-get-cert-unix.md) for generating the certificate and
obtaining its info from a Unix environment.