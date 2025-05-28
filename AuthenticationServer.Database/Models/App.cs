namespace AuthenticationServer.Database.Models;

public class App
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string KeyName { get; set; }
    public ICollection<UserApp> UserApp { get; set; }
}