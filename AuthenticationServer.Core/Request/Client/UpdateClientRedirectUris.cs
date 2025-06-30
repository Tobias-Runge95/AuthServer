namespace AuthenticationServer.Core.Request.Client;

public class UpdateClientRedirectUris
{
    public Guid ClientId { get; set; }
    public List<string> RedirectUris { get; set; }
}