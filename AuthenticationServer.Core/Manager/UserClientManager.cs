using AuthenticationServer.Database;
using AuthenticationServer.Database.Models;

namespace AuthenticationServer.Core.Manager;

public interface IUserClientManager
{
    Task CreateUserClientAsync(Guid userId, Guid clientId);
}

public class UserClientManager : IUserClientManager
{
    private readonly ApplicationDbContext _context;

    public UserClientManager(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateUserClientAsync(Guid userId, Guid clientId)
    {
        await _context.UserClients.AddAsync(new UserClient
        {
            UserId = userId,
            AppId = clientId,
            Created = DateTime.Now,
        });
        await _context.SaveChangesAsync();
    }
}