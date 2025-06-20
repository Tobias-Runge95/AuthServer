namespace AuthenticationServer.Core.Request.Client;

public class RotateClientSecretRequest
{
    public Guid Id { get; set; }
    public string NewSecret { get; set; }
    public string OldSecret { get; set; }
}