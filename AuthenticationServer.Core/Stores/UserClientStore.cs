using AuthenticationServer.Core.Manager;
using AuthenticationServer.Database;
using AuthenticationServer.Database.Models;

namespace AuthenticationServer.Core.Stores;

public interface IUserClientStore : IBaseStore<UserClient>
{
    
}

public class UserClientStore : BaseStore<UserClient>, IUserClientStore
{
    public UserClientStore(ApplicationDbContext db) : base(db)
    {
    }
}