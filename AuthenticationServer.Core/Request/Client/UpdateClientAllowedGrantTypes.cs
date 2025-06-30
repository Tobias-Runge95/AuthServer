namespace AuthenticationServer.Core.Request.Client;

public class UpdateClientAllowedGrantTypes
{
    public Guid ClientId { get; set; }
    public List<string> AllowedGrantTypes { get; set; }
}