using AuthenticationServer.Database;
using AuthenticationServer.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServer.Core.Stores;

public interface IApplicationUserStore
{
    Task<User> GetUserAsync(Guid userId);
    Task<User> GetUserAsync(string userName);
    Task<User> GetUserByEmailAsync(string email);
}

public class ApplicationUserStore : IApplicationUserStore
{
    private readonly ApplicationDbContext _context;

    public ApplicationUserStore(ApplicationDbContext context)
    {
        _context = context;
    }


    public Task<User> GetUserAsync(Guid userId)
    {
        return _context.User
            .Where(u => u.Id == userId)
            .Include(u => u.ContactForClient)
            .Include(uc => uc.UserClients)
            .FirstOrDefaultAsync()!;
    }

    public Task<User> GetUserAsync(string userName)
    {
        return _context.User.FirstOrDefaultAsync(u => u.UserName == userName)!;
    }

    public Task<User> GetUserByEmailAsync(string email)
    {
        return _context.User.FirstOrDefaultAsync(u => u.Email == email)!;
    }
}