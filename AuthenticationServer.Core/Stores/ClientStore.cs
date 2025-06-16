using AuthenticationServer.Database;
using AuthenticationServer.Database.Models;

namespace AuthenticationServer.Core.Stores;

public interface IClientStore
{
    Task AddAsync(Client client);
    Task AddManyAsync(List<Client> clients);
    Task RemoveAsync(Client client);
    Task RemoveManyAsync(List<Client> clients);
    Task UpdateAsync(Client client);
    Task UpdateManyAsync(List<Client> clients);
    Task<Client> GetAsync(Guid id);
    Task<List<Client>> GetAllAsync();
    Task<bool> ContainsAtLeastOneValidRedirectUri(Guid id);
    
    // --- ClientScope
    Task AddAsync(ClientScope clientScope);
    Task AddManyAsync(List<ClientScope> clientScopes);
    Task RemoveAsync(ClientScope clientScope);
    Task RemoveManyAsync(List<ClientScope> clientScopes);
    Task<ClientScope> GetClientScopeAsync(Guid id);
    Task<List<ClientScope>> GetAllClientScopesAsync();
}

public class ClientStore : IClientStore
{
    private readonly ApplicationDbContext _db;

    public ClientStore(ApplicationDbContext db)
    {
        _db = db;
    }

    public Task AddAsync(Client client)
    {
        throw new NotImplementedException();
    }

    public Task AddManyAsync(List<Client> clients)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Client client)
    {
        throw new NotImplementedException();
    }

    public Task RemoveManyAsync(List<Client> clients)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Client client)
    {
        throw new NotImplementedException();
    }

    public Task UpdateManyAsync(List<Client> clients)
    {
        throw new NotImplementedException();
    }

    public Task<Client> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Client>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ContainsAtLeastOneValidRedirectUri(Guid id)
    {
        throw new NotImplementedException();
    }

    // --- ClientScope
    
    public Task AddAsync(ClientScope clientScope)
    {
        throw new NotImplementedException();
    }

    public Task AddManyAsync(List<ClientScope> clientScopes)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(ClientScope clientScope)
    {
        throw new NotImplementedException();
    }

    public Task RemoveManyAsync(List<ClientScope> clientScopes)
    {
        throw new NotImplementedException();
    }

    public Task<ClientScope> GetClientScopeAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ClientScope>> GetAllClientScopesAsync()
    {
        throw new NotImplementedException();
    }
}