namespace AuthenticationServer.Core.Request.Client;

public class CreateClient
{
    public Guid Id { get; set; }
    public string ClientId { get; set; }
    public string ClientName { get; set; }
    public string ClientType { get; set; }
    public string ClientSecretHash { get; set; }
    public List<string> RedirectUris { get; set; }
    public List<string> AllowedGrantTypes { get; set; }
    public List<string> AllowedScopes { get; set; }
    public string JwksUri { get; set; }
    public string PublicKeyPem { get; set; }
    public bool IsEnabled { get; set; }
}