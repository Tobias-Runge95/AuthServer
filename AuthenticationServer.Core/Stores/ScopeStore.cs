using AuthenticationServer.Database.Models;

namespace AuthenticationServer.Core.Stores;

public interface IScopeStore
{
    Task AddOneAsync(Scope scope);
    Task AddManyAsync(List<Scope> scopes);
    Task RemoveOneAsync(Guid id);
    Task RemoveManyAsync(List<Guid> ids);
    Task UpdateOneAsync(Scope scope);
    Task UpdateManyAsync(List<Scope> scopes);
    Task<Scope> GetOneAsync(Guid id);
    Task<List<Scope>> GetAllAsync();
    Task<List<Scope>> GetAllAsync(List<Guid> ids);
    Task<List<Scope>> GetAllAsync(List<string> names);
}

public class ScopeStore :  IScopeStore
{
    public Task AddOneAsync(Scope scope)
    {
        throw new NotImplementedException();
    }

    public Task AddManyAsync(List<Scope> scopes)
    {
        throw new NotImplementedException();
    }

    public Task RemoveOneAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveManyAsync(List<Guid> ids)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOneAsync(Scope scope)
    {
        throw new NotImplementedException();
    }

    public Task UpdateManyAsync(List<Scope> scopes)
    {
        throw new NotImplementedException();
    }

    public Task<Scope> GetOneAsync(Guid id)
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