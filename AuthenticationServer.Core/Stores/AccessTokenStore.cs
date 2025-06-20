using AuthenticationServer.Core.Manager;
using AuthenticationServer.Database;
using AuthenticationServer.Database.Models;

namespace AuthenticationServer.Core.Stores;

public interface IAccessTokenStore : IBaseStore<AccessToken>
{
    
}

public class AccessTokenStore : BaseStore<AccessToken>, IAccessTokenStore
{
    public AccessTokenStore(ApplicationDbContext db) : base(db)
    {
    }
}