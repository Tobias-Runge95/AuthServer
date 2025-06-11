using AuthenticationServer.Core.DTO.User;

namespace AuthenticationServer.Core.DTO.Client;

public class ClientDTO
{
    public Guid Id { get; set; }
    public string ClientName { get; set; }
    public string ClientType { get; set; }
    public List<string> RedirectUris { get; set; }
    public List<string> AllowedGrantTypes { get; set; }
    public List<string> AllowedScopes { get; set; }
}