using AuthenticationServer.Core.Request.User;
using AuthenticationServer.Database;
using AuthenticationServer.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AuthenticationServer.Core.Manager;

public class UserManager : UserManager<User>
{
    // TODO: Update to use UnitOfWork and UserStore
    private readonly ApplicationDbContext _context;
    private readonly RoleManager _roleManager;
    private readonly IUserClientManager _userClientManager;
    
    public UserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger, ApplicationDbContext context, RoleManager roleManager, IUserClientManager userClientManager) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        _context = context;
        _roleManager = roleManager;
        _userClientManager = userClientManager;
    }

    public async Task<Guid> CreateAsync(CreateUser request)
    {
        var user = new User() { UserName = request.UserName, Email = request.Email, Id = Guid.NewGuid() };
        var result = await CreateAsync(user, request.Password);
        
        if (request.ClientId is not null)
        {
            await _userClientManager.CreateUserClientAsync(user.Id, request.ClientId.Value);
        }
        
        // _context.UserRole.Add(new UserRole()
        // {
        //     UserId = user.Id,
        //     RoleId = role.Id
        // });
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public async Task DeleteAsync(Guid userId)
    {
        var user = await _context.User.Where(x => x.Id == userId).FirstAsync();
        _context.User.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetUserAsync(Guid userId)
    {
        var user = await _context.User.Where(x => x.Id == userId).FirstAsync();
        return user;
    }

    public async Task UpdateUserAsync(UpdateUser request)
    {
        var user = await _context.User.Where(x => x.Id == request.UserId).FirstAsync();
        _context.User.Update(user);
        user.Email = request.Email;
        user.UserName = request.UserName;
        await _context.SaveChangesAsync();
    }
}