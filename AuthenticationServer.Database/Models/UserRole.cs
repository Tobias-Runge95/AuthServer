using Microsoft.AspNetCore.Identity;

namespace AuthenticationServer.Database.Models;

public class UserRole : IdentityUserRole<Guid>
{
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
}