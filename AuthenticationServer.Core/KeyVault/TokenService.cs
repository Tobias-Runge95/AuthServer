using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using AuthenticationServer.Core.Factories;
using AuthenticationServer.Core.Responses.Auth;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationServer.Core.KeyVault;

public class TokenService
{
    private readonly KeyClient _keyClient;
    private readonly ICryptographyClientFactory _cryptographyClientFactory;

    public TokenService(KeyClient keyClient, ICryptographyClientFactory cryptographyClientFactory)
    {
        _keyClient = keyClient;
        _cryptographyClientFactory = cryptographyClientFactory;
    }

    public async Task<LoginResponse> GenerateTokensAsync(IEnumerable<Claim> claims)
    {
        var keyVaultKey = await _keyClient.GetKeyAsync("RollplayHelper");
        var dummyKey = new RsaSecurityKey(RSA.Create()) { KeyId = keyVaultKey.Value.Id.ToString() };
        var cryptographyClient = _cryptographyClientFactory.CreateClient();
        var factory = new AzureKeyVaultCryptoProviderFactory(cryptographyClient);

        var signingCredentials = new SigningCredentials(dummyKey, SecurityAlgorithms.RsaSha256)
        {
            CryptoProviderFactory = factory
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(30),
            Issuer = "RPH",
            SigningCredentials = signingCredentials
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        string jwt = tokenHandler.WriteToken(token);
        return new LoginResponse{AuthToken = jwt, RenewToken = RenewToken()};
    }

    private string RenewToken()
    {
        var randomBytes = RandomNumberGenerator.GetBytes(32);
        return Convert.ToBase64String(randomBytes)
            .Replace('+', '-')  // für URL-Sicherheit
            .Replace('/', '_')  // "
            .Replace("=", "");
    }
}