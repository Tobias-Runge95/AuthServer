namespace AuthenticationServer.Database.Models;

public class AuthorizationCodeScope
{
    public Guid AuthorizationCodeId { get; set; }
    public AuthorizationCode AuthorizationCode { get; set; }
    public Guid ScopeId { get; set; }
    public Scope Scope { get; set; }
}