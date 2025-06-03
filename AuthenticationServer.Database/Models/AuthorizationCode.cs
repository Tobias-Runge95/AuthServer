namespace AuthenticationServer.Database.Models;

public class AuthorizationCode
{
    public Guid Id { get; set; }
    public string Code { get; set; }                  // zufällig generierter String
    public string RedirectUri { get; set; }
    public Guid? ClientId { get; set; }
    public Client? Client { get; set; }
    public Guid? SubjectId { get; set; }
    public User? Subject { get; set; }             // User ID (von Identity User)
    public DateTime ExpiresAt { get; set; }
    public ICollection<AuthorizationCodeScope> Scopes { get; set; }
    public List<string> RequestedScopes { get; set; } = new();
}