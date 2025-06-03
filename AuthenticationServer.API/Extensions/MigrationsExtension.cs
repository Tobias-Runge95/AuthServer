using AuthenticationServer.Database;
using AuthenticationServer.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServer.API.Extensions;

public static class MigrationsExtension
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using (IServiceScope scope = app.ApplicationServices.CreateScope())
        {
            using (ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
            {
                context.Database.Migrate();
            }
        }
    }
}