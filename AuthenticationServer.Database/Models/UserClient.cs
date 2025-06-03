namespace AuthenticationServer.Database.Models;

public class UserClient
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid AppId { get; set; }
    public Client Client { get; set; }
    public DateTime Created { get; set; }
}