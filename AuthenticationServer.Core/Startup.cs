using AuthenticationServer.Core.Authentication;
using AuthenticationServer.Core.Factories;
using AuthenticationServer.Core.KeyVault;
using AuthenticationServer.Core.Manager;
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
            .AddScoped<AuthenticationManager>()
            .AddTransient<ICryptographyClientFactory, CryptographyClientFactory>()
            .AddTransient<TokenService>();
    }
}