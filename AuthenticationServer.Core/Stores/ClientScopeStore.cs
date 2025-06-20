

using AuthenticationServer.Core.Manager;
using AuthenticationServer.Database;
using AuthenticationServer.Database.Models;

public interface IClientScopeStore :  IBaseStore<ClientScope>
{
    Task<ClientScope> GetAsync(Guid id);
    Task<List<ClientScope>> GetAllAsync();
    Task<List<ClientScope>> GetAllByClientId(Guid clientId);
}

public class ClientScopeStore : BaseStore<ClientScope>, IClientScopeStore
{
    public ClientScopeStore(ApplicationDbContext db) : base(db)
    {
    }

    public Task<ClientScope> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ClientScope>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<ClientScope>> GetAllByClientId(Guid clientId)
    {
        throw new NotImplementedException();
    }
}