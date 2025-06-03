using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using Microsoft.Extensions.Configuration;

namespace AuthenticationServer.Core.Factories;

public interface ICryptographyClientFactory
{
    CryptographyClient CreateClient();
}

public class CryptographyClientFactory : ICryptographyClientFactory
{
    private readonly ClientSecretCredential _credential;
    private readonly KeyClient _keyClient;
    private readonly IConfiguration _configuration;
    
    public CryptographyClientFactory( KeyClient keyClient, IConfiguration configuration)
    {
        _credential = new ClientSecretCredential(
            _configuration["KeyVault:TenantId"],
            _configuration["KeyVault:ClientId"],
            _configuration["KeyVault:Secret"]
        );
        _keyClient = keyClient;
        _configuration = configuration;
    }
    
    public CryptographyClient CreateClient()
    {
        var key = _keyClient.GetKey(_configuration["KeyVault:KeyName"]).Value;
        return new CryptographyClient(key.Id, _credential);
    }
}