using Microsoft.AspNetCore.Identity;

namespace AuthenticationServer.Database.Models;

public class User : IdentityUser<Guid>
{
    public bool LoggedIn { get; set; }
    public string Name { get; set; }
    public Guid? ClientId { get; set; }
    public Client ContactForClient { get; set; }
    public ICollection<UserClient> UserClients { get; set; }
    public List<AuthorizationCode> AuthorizationCodes { get; set; }
    public List<AccessToken> AccessTokens { get; set; }
    public List<RefreshToken> RefreshTokens { get; set; }
    public List<UserRole> UserRoles { get; set; }
}