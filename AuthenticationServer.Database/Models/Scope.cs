namespace AuthenticationServer.Database.Models;

public class Scope
{
    public Guid Id { get; set; }

    public string Name { get; set; } 
    public string Description { get; set; } 
    public List<AuthorizationCodeScope> AuthorizationCodeScopes { get; set; }
    public List<AccessTokenScope> AccessTokenScopes { get; set; }
    public List<ClientScope> ClientScopes { get; set; }
}