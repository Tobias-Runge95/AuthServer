using AuthenticationServer.Database;

namespace AuthenticationServer.Core.Stores;

public interface IUnitOfWork
{
    IClientStore Clients { get; }
    IAccessTokenStore AccessTokens { get; }
    IClientScopeStore ClientScopes { get; }
    IScopeStore Scopes { get; }
    IRefreshTokenStore RefreshTokens { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext  _context;
    private IClientStore _clientStore;
    private IScopeStore _scopeStore;
    private IClientScopeStore _clientScopeStore;
    private IAccessTokenStore _accessTokenStore;
    private IRefreshTokenStore _refreshTokenStore;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IClientStore Clients
    {
        get
        {
            if (_clientStore is null)
            {
                _clientStore = new ClientStore(_context);
            }
            
            return _clientStore;
        }
    }

    public IAccessTokenStore AccessTokens
    {
        get
        {
            if (_accessTokenStore is null)
            {
                _accessTokenStore = new AccessTokenStore(_context);
            }
            return _accessTokenStore;
        }
    }

    public IClientScopeStore ClientScopes
    {
        get
        {
            if (_clientScopeStore is null)
            {
                _clientScopeStore =  new ClientScopeStore(_context);
            }
            return _clientScopeStore;
        }
    }

    public IScopeStore Scopes
    {
        get
        {
            if (_scopeStore is null)
            {
                _scopeStore = new ScopeStore(_context);
            }
            return _scopeStore;
        }
    }

    public IRefreshTokenStore RefreshTokens
    {
        get
        {
            if (_refreshTokenStore is null)
            {
                _refreshTokenStore =  new RefreshTokenStore(_context);
            }
            
            return _refreshTokenStore;
        }
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}