using AuthenticationServer.Core.Authentication;
using AuthenticationServer.Core.Factories;
using AuthenticationServer.Core.KeyVault;
using AuthenticationServer.Core.Manager;
using AuthenticationServer.Core.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationServer.Core;

public static class Startup
{
    public static IServiceCollection Register(this IServiceCollection service)
    {
        return service
            .AddTransient<RoleManager>()
            .AddTransient<UserManager>()
            .AddTransient<IAuthManager, AuthManager>()
            .AddScoped<IUserClientManager, UserClientManager>()
            .AddScoped<AuthenticationManager>()
            .AddTransient<ICryptographyClientFactory, CryptographyClientFactory>()
            .AddTransient<TokenService>()
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .RegisterStores();
    }

    private static IServiceCollection RegisterStores(this IServiceCollection service)
    {
        return service
            .AddScoped<IAccessTokenStore, AccessTokenStore>()
            .AddScoped<IClientScopeStore, ClientScopeStore>()
            .AddScoped<IClientStore, ClientStore>()
            .AddScoped<IRefreshTokenStore, RefreshTokenStore>()
            .AddScoped<IScopeStore, ScopeStore>();
    }
}