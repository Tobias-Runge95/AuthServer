namespace AuthenticationServer.Database.Models;

public class AccessToken
{
    public Guid Id { get; set; }

    public string TokenId { get; set; }               // JTI (JWT ID)
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    public Guid? SubjectId { get; set; }
    public User? Subject { get; set; }           // optional bei client_credentials

    // public List<string> Scopes { get; set; } = new();
    public DateTime IssuedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public List<AccessTokenScope> Scopes { get; set; }
    public bool Revoked { get; set; } = false;
}