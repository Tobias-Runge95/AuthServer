using Microsoft.AspNetCore.Identity;

namespace AuthenticationServer.Database.Models;

public class Role : IdentityRole<Guid>
{
    public Guid AppId { get; set; }
    public App App { get; set; }
}