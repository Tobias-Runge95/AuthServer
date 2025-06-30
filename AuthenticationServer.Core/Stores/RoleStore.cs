using AuthenticationServer.Core.Manager;
using AuthenticationServer.Database;
using AuthenticationServer.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServer.Core.Stores;

public interface IRoleStore : IBaseStore<Role>
{
    Task<Role> FindByNameAsync(string name, Guid clientId, CancellationToken cancellationToken);
    Task<Role> FindByIdAsync(Guid roleId, CancellationToken cancellationToken);
    Task<List<Role>> GetAllRolesAsync(CancellationToken cancellationToken);
}

public class RoleStore : BaseStore<Role>, IRoleStore
{
    public RoleStore(ApplicationDbContext db) : base(db)
    {
    }

    public async Task<Role> FindByNameAsync(string name, Guid clientId, CancellationToken cancellationToken)
    {
        return await _db.UserRole
            .Where(ur => ur.ClientId == clientId && ur.Role.Name == name)
            .Select(ur => ur.Role)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidOperationException();
    }

    public async Task<Role> FindByIdAsync(Guid roleId, CancellationToken cancellationToken)
    {
        return await _db.Role
            .FirstOrDefaultAsync(r => r.Id == roleId, cancellationToken) ?? throw new InvalidOperationException();
    }

    public async Task<List<Role>> GetAllRolesAsync(CancellationToken cancellationToken)
    {
        return await _db.Role.ToListAsync(cancellationToken);
    }
}