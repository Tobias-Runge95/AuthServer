using AuthenticationServer.Core.Request.User;
using AuthenticationServer.Core.Stores;
using AuthenticationServer.Database;
using AuthenticationServer.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AuthenticationServer.Core.Manager;

public class UserManager : UserManager<User>
{
    private readonly RoleManager _roleManager;
    private readonly IUnitOfWork _unitOfWork;
    
    public UserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor, 
        IPasswordHasher<User> passwordHasher, IEnumerable<IUserValidator<User>> userValidators, 
        IEnumerable<IPasswordValidator<User>> passwordValidators, ILookupNormalizer keyNormalizer, 
        IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<User>> logger,
        RoleManager roleManager, IUnitOfWork unitOfWork) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        _roleManager = roleManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> CreateAsync(CreateUser request)
    {
        var user = new User() { UserName = request.UserName, Email = request.Email, Id = Guid.NewGuid(), PhoneNumber = request.Phone, Name = request.Name};
        var result = await CreateAsync(user, request.Password);
        
        if (request.ClientId is not null)
        {
            await _unitOfWork.UserClients.AddAsync(new UserClient { AppId = request.ClientId.Value, UserId = user.Id });
        }
        var roles = new List<UserRole>();
        foreach (var role in request.Roles)
        {
            var roleResult = await _roleManager.FindByNameAsync(role);
            if (roleResult is not null)
            {
               roles.Add(new UserRole { RoleId = roleResult.Id, UserId = user.Id }); 
            }
        }
        await _unitOfWork.UserRoles.AddManyAsync(roles);
        await _unitOfWork.SaveChangesAsync();
        return user.Id;
    }

    public async Task DeleteAsync(Guid userId)
    {
        var user = await _unitOfWork.Users.GetUserAsync(userId);
        await Store.DeleteAsync(user, CancellationToken.None);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<User> GetUserAsync(Guid userId)
    {
        var user = await _unitOfWork.Users.GetUserAsync(userId);
        return user;
    }

    public async Task UpdateUserAsync(UpdateUser request)
    {
        var user = await _unitOfWork.Users.GetUserAsync(request.UserId);
        var mappings = new List<(string? value, Action<string> setter)>
        {
            (user.UserName, v => user.UserName = v),
            (user.Email, v => user.Email = v),
            (user.PhoneNumber, v => user.PhoneNumber = v),
            (user.Name, v => user.Name = v)
        };

        foreach (var (value, setter) in mappings)
        {
            if (value != null)
                setter(value);
        }
        await Store.UpdateAsync(user, CancellationToken.None);
        await _unitOfWork.SaveChangesAsync();
    }
}