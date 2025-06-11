namespace AuthenticationServer.Core.DTO.Client;

public class ShortClientDTO
{
    public Guid Id { get; set; }
    public string ClientName { get; set; }
    public string ClientType { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsEnabled { get; set; }
}