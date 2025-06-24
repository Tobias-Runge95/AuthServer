using Microsoft.AspNetCore.Identity;

namespace AuthenticationServer.Database.Models;

public class UserClaim: IdentityUserClaim<Guid>
{
    public Guid ClientId { get; set; }
    public Client Client { get; set; }
}