namespace AuthenticationServer.Database.Models;

public class Client
{
    public Guid Id { get; set; }
    public string ClientId { get; set; }
    public string ClientName { get; set; }
    public string ClientType { get; set; }
    public string ClientSecretHash { get; set; }
    public List<string> RedirectUris { get; set; }
    public List<string> AllowedGrantTypes { get; set; }
    public string JwksUri { get; set; }
    public string PublicKeyPem { get; set; }
    public Guid? ContactUserId { get; set; }
    public User ContactUser { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsEnabled { get; set; }
    public ICollection<UserClient> UserClients { get; set; }
    public List<AuthorizationCode> AuthorizationCodes { get; set; }
    public List<AccessToken> AccessTokens { get; set; }
    public List<RefreshToken> RefreshTokens { get; set; }
    public List<ClientScope> ClientScopes { get; set; }
    public List<UserRole> UserRoles { get; set; }
    public List<UserClaim> UserClaims { get; set; }
}