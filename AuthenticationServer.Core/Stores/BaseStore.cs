using AuthenticationServer.Database;

namespace AuthenticationServer.Core.Manager;

public interface IBaseStore<TEntity>
{
    Task AddAsync(TEntity entity);
    Task AddManyAsync(List<TEntity> entities);
    Task RemoveAsync(TEntity entity);
    Task RemoveManyAsync(List<TEntity> entities);
    Task UpdateAsync(TEntity entity);
    Task UpdateManyAsync(List<TEntity> entities);
}

public class BaseStore<TEntity> : IBaseStore<TEntity> where TEntity: class
{
    internal readonly ApplicationDbContext _db;

    public BaseStore(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(TEntity entity)
    {
        
    }

    public async Task AddManyAsync(List<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveManyAsync(List<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateManyAsync(List<TEntity> entities)
    {
        throw new NotImplementedException();
    }
}