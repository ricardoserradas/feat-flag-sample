# Full Feature Flag sample (with DevOps practices applied)

I'm creating this repo with the idea of having a full sample of Feature Flags
in action. By action, I mean having:

- A Web App with a feature to be implemented
- Feature Flag coding already in place
- ARM templates for deploying the sample infrastructure
- Good engineering practices
- A step-by-step tutorial for you to *feel* the benefits of the technique

For you to have all the resources set up for this set of samples,
see [Provisioning Resources](docs/00-provisioning-resources.md).

## Engineering practices reference

- [Use Azure Key Vault to protect application secrets](docs/01-key-vault.md)

## Components Health

|Component|Build Status|
|---------|------------|
|Docs|[![Build Status](https://dev.azure.com/serradas-msft/Feature-Flag-Sample/_apis/build/status/ricardoserradas.markdown-lint?branchName=master)](https://dev.azure.com/serradas-msft/Feature-Flag-Sample/_build/latest?definitionId=52&branchName=master)|
|Web App|[![Build Status](https://dev.azure.com/serradas-msft/Feature-Flag-Sample/_apis/build/status/ricardoserradas.feat-flag-sample?branchName=master)](https://dev.azure.com/serradas-msft/Feature-Flag-Sample/_build/latest?definitionId=51&branchName=master)|