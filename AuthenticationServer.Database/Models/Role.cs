using Microsoft.AspNetCore.Identity;

namespace AuthenticationServer.Database.Models;

public class Role : IdentityRole<Guid>
{
    public Guid AppId { get; set; }
    public Client Client { get; set; }
}