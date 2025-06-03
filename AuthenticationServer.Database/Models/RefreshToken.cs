namespace AuthenticationServer.Database.Models;

public class RefreshToken
{
    public Guid Id { get; set; }

    public string Token { get; set; }
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
    public Guid? SubjectId { get; set; }
    public User? Subject { get; set; }
    
    public DateTime IssuedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool Revoked { get; set; }
}