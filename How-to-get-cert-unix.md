# [In progress] How to generate certificate on Unix

[This tutorial](https://docs.microsoft.com/en-us/azure/architecture/multitenant-identity/key-vault)
only supports the procedure of adding Key Vault practices using
a PowerShell script. The idea is to also support Unix platforms.

## Generating the files

```bash
# Generating the RSA 2048 bit private key
openssl genrsa 2048 > <app name>.key

# Generating the x509 certificate using sha1 valid for 1000 days
openssl req -new -x509 -nodes -sha1 -days 1000 -key <app name>.key > <app name>-pub.cer

# Combining the cert and private key on a pkcs12 archive (p12 format)
openssl pkcs12 -export -in <app name>-pub.cer -inkey <app name>.key -out <app name>-cert-key.p12

# Combining the cert and private key on a pkcs12 archive (pfx format)
openssl pkcs12 -export -in <app name>-pub.cer -inkey <app name>.key -out <app name>-cert-key.pfx
```

## Extracting info from the files

```bash
# value
# Getting information from the public key (Base64 encoded)
openssl x509 -in <app name>-pub.cer -outform der | base64

# customKeyIdentifier
# Getting the thumbprint of the public key (Base64 encoded)
openssl x509 -in <app name>-pub.cer -noout -sha256 -fingerprint | base64

# keyId
# Generate a unique id
uuidgen | awk '{print tolower($0)}'
```

## Fill in this JSON with the information you now have

```json
"keyCredentials": [
    {
    "type": "AsymmetricX509Cert",
    "usage": "Verify",
    "keyId": "[keyId]",
    "customKeyIdentifier": "[customKeyIdentifier]",
    "value": "[value]"
    }
],
```