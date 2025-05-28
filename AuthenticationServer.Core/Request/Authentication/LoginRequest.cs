namespace AuthenticationServer.Core.Request.Authentication;

public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public byte[] PubKey { get; set; }
    public string AppName { get; set; }
}