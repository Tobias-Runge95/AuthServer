using Microsoft.AspNetCore.Identity;

namespace AuthenticationServer.Database.Models;

public class User : IdentityUser<Guid>
{
    public bool LoggedIn { get; set; }
    public ICollection<UserClient> UserClients { get; set; }
    public List<AuthorizationCode> AuthorizationCodes { get; set; }
    public List<AccessToken> AccessTokens { get; set; }
    public List<RefreshToken> RefreshTokens { get; set; }
}