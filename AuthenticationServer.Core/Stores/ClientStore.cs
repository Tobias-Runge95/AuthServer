using AuthenticationServer.Core.Manager;
using AuthenticationServer.Core.Request.Client;
using AuthenticationServer.Database;
using AuthenticationServer.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServer.Core.Stores;

public interface IClientStore : IBaseStore<Client>
{
    Task<Client> GetAsync(Guid id);
    Task<List<Client>> GetAllAsync();
    Task<bool> ContainsAtLeastOneValidRedirectUri(Guid id);
    Task RotateClientSecretAsync(string secret, Guid clientId);
    Task<List<User>> GetAllClientUsersAsync(Guid clientId);
    
}

public class ClientStore : BaseStore<Client>, IClientStore
{
    public ClientStore(ApplicationDbContext db) : base(db)
    {
    }

    // public async Task AddAsync(Client client)
    // {
    //     await _db.Clients.AddAsync(client);
    //     await _db.SaveChangesAsync();
    // }
    //
    // public async Task AddManyAsync(List<Client> clients)
    // {
    //     await _db.Clients.AddRangeAsync(clients);
    //     await _db.SaveChangesAsync();
    // }
    //
    // public async Task RemoveAsync(Client client)
    // {
    //     _db.Clients.Remove(client);
    //     await _db.SaveChangesAsync();
    // }
    //
    // public async Task RemoveManyAsync(List<Client> clients)
    // {
    //     _db.Clients.RemoveRange(clients);
    //     await _db.SaveChangesAsync();
    // }
    //
    // public async Task UpdateAsync(Client client)
    // {
    //     _db.Clients.Update(client);
    //     await _db.SaveChangesAsync();
    // }
    //
    // public async Task UpdateManyAsync(List<Client> clients)
    // {
    //     _db.Clients.UpdateRange(clients);
    //     await _db.SaveChangesAsync();
    // }

    public async Task<Client> GetAsync(Guid id)
    {
        return await _db.Clients
            .Where(c => c.Id == id)
            .Include(x => x.ClientScopes)
            .ThenInclude(cs => cs.Scope)
            .Include(c => c.UserClients)
            .ThenInclude(uc => uc.User)
            .FirstOrDefaultAsync() ?? throw new InvalidOperationException();
    }

    public async Task<List<Client>> GetAllAsync()
    {
        return await _db.Clients.AsNoTracking().ToListAsync();
    }

    public async Task<bool> ContainsAtLeastOneValidRedirectUri(Guid id)
    {
        return await _db.Clients.Where(x => x.Id == id).AnyAsync(x => x.RedirectUris.Count > 0);
    }

    public async Task RotateClientSecretAsync(string secret, Guid clientId)
    {
        var client = await _db.Clients.FirstOrDefaultAsync(c => c.Id == clientId);
        _db.Clients.Update(client);
        client.ClientSecretHash = secret;
        await _db.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllClientUsersAsync(Guid clientId)
    {
        return await _db.UserClients
            .Where(uc => uc.AppId == clientId)
            .Select(uc => uc.User)
            .ToListAsync();
    }
}