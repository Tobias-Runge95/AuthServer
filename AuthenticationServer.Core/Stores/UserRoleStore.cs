using AuthenticationServer.Core.Manager;
using AuthenticationServer.Database;
using AuthenticationServer.Database.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationServer.Core.Stores;

public interface IUserRoleStore : IBaseStore<UserRole>
{
    
}

public class UserRoleStore : BaseStore<UserRole>, IUserRoleStore
{
    public UserRoleStore(ApplicationDbContext db) : base(db)
    {
    }
}
