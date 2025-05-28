namespace AuthenticationServer.Database.Models;

public class UserApp
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid AppId { get; set; }
    public App App { get; set; }
    public DateTime Created { get; set; }
}