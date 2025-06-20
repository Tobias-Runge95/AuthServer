using AuthenticationServer.Core.Manager;
using AuthenticationServer.Database;
using AuthenticationServer.Database.Models;

namespace AuthenticationServer.Core.Stores;

public interface IRefreshTokenStore : IBaseStore<RefreshToken>
{
    
}

public class RefreshTokenStore :  BaseStore<RefreshToken>, IRefreshTokenStore
{
    public RefreshTokenStore(ApplicationDbContext db) : base(db)
    {
    }
}