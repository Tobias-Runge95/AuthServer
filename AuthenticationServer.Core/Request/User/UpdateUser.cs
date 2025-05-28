namespace AuthenticationServer.Core.Request.User;

public class UpdateUser
{
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
}