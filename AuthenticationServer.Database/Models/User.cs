using Microsoft.AspNetCore.Identity;

namespace AuthenticationServer.Database.Models;

public class User : IdentityUser<Guid>
{
    public bool LoggedIn { get; set; }
    public ICollection<UserApp> UserApp { get; set; }
}