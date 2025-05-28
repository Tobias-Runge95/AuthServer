using Azure.Security.KeyVault.Keys.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationServer.Core.KeyVault;

public class AzureKeyVaultCryptoProviderFactory : CryptoProviderFactory
{
    private readonly CryptographyClient _cryptoClient;

    public AzureKeyVaultCryptoProviderFactory(CryptographyClient cryptoClient)
    {
        _cryptoClient = cryptoClient;
    }

    public override SignatureProvider CreateForSigning(SecurityKey key, string algorithm)
    {
        return new AzureKeyVaultSignatureProvider(_cryptoClient, key, algorithm, true);
    }
}