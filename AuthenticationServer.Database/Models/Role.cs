using Microsoft.AspNetCore.Identity;

namespace AuthenticationServer.Database.Models;

public class Role : IdentityRole<Guid>
{
    public List<UserRole> UserRoles { get; set; }
}