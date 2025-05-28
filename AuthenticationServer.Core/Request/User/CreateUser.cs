namespace AuthenticationServer.Core.Request.User;

public class CreateUser
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
}