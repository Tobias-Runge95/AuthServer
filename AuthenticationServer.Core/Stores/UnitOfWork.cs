using AuthenticationServer.Database;

namespace AuthenticationServer.Core.Stores;

public interface IUnitOfWork
{
    IClientStore Clients { get; }
    IAccessTokenStore AccessTokens { get; }
    IClientScopeStore ClientScopes { get; }
    IScopeStore Scopes { get; }
    IRefreshTokenStore RefreshTokens { get; }
    IUserClientStore UserClients { get; }
    IApplicationUserStore Users { get; }
    IUserRoleStore UserRoles { get; }
    IRoleStore Roles { get; }
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
    private IUserClientStore  _userClientStore;
    private IApplicationUserStore  _applicationUserStore;
    private IUserRoleStore  _userRoleStore;
    private IRoleStore    _roleStore;
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

    public IApplicationUserStore Users
    {
        get
        {
            if (_applicationUserStore is null)
            {
                _applicationUserStore = new ApplicationUserStore(_context);
            }
            
            return _applicationUserStore;
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

    public IUserClientStore UserClients
    {
        get
        {
            if (_userClientStore is null)
            {
                _userClientStore =  new UserClientStore(_context);
            }
            
            return _userClientStore;
        }
    }

    public IUserRoleStore UserRoles
    {
        get
        {
            if (_userRoleStore is null)
            {
                _userRoleStore =  new UserRoleStore(_context);
            }
            return _userRoleStore;
        }
    }

    public IRoleStore Roles
    {
        get
        {
            if (_roleStore is null)
            {
                _roleStore =  new RoleStore(_context);
            }
            return _roleStore;
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}