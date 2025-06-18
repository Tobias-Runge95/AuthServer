using AuthenticationServer.Database.Models;

namespace AuthenticationServer.Core.Stores;

public interface IUserStore
{
    Task<List<User>> GetAllUsersAsync();
    Task<User> GetUserAsync(Guid userId);
}

public class UserStore : IUserStore
{
    public Task<List<User>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}