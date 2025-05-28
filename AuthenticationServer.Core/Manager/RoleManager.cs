using AuthenticationServer.Core.Request.Role;
using AuthenticationServer.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace AuthenticationServer.Core.Manager;

public interface IRoleManager
{
    Task CreateRole(CreateRole request, CancellationToken cancellationToken);
    Task<List<Role>> GetAllRoles(CancellationToken cancellationToken);
    Task DeleteRole(DeleteRole request, CancellationToken cancellationToken);
    Task UpdateRole(UpdateRole request, CancellationToken cancellationToken);
}

public class RoleManager : RoleManager<Role>, IRoleManager
{
    
    public RoleManager(IRoleStore<Role> store, IEnumerable<IRoleValidator<Role>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<Role>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
    {
    }

    public Task CreateRole(CreateRole request, CancellationToken cancellationToken)
    {
        CreateAsync(new Role
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        });
        
        return Task.CompletedTask;
    }

    public Task<List<Role>> GetAllRoles(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRole(DeleteRole request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task UpdateRole(UpdateRole request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}