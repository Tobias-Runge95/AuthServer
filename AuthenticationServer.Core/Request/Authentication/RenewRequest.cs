namespace AuthenticationServer.Core.Request.Authentication;

public class RenewRequest
{
    public Guid UserId { get; set; }
    public string RenewToken { get; set; }
}