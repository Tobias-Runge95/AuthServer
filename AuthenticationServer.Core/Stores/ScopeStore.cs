using AuthenticationServer.Core.Manager;
using AuthenticationServer.Database;
using AuthenticationServer.Database.Models;

namespace AuthenticationServer.Core.Stores;

public interface IScopeStore :  IBaseStore<Scope>
{
    Task<Scope> GetAsync(Guid id);
    Task<Scope>  GetAsync(string name);
    Task<List<Scope>> GetAllAsync();
    Task<List<Scope>> GetAllAsync(List<Guid> ids);
    Task<List<Scope>> GetAllAsync(List<string> names);
}

public class ScopeStore : BaseStore<Scope>, IScopeStore
{
    public ScopeStore(ApplicationDbContext db) : base(db)
    {
    }

    public Task<Scope> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Scope> GetAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<List<Scope>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Scope>> GetAllAsync(List<Guid> ids)
    {
        throw new NotImplementedException();
    }

    public Task<List<Scope>> GetAllAsync(List<string> names)
    {
        throw new NotImplementedException();
    }
}