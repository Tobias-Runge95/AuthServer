namespace AuthenticationServer.Core.Request.Client;

public class AddUserToClient
{
    public Guid UserId { get; set; }
    public Guid ClientId { get; set; }
}