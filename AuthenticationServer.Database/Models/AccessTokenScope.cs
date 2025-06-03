namespace AuthenticationServer.Database.Models;

public class AccessTokenScope
{
    public Guid AccessTokenId { get; set; }
    public AccessToken AccessToken { get; set; }
    public Guid ScopeId { get; set; }
    public Scope Scope { get; set; }
}