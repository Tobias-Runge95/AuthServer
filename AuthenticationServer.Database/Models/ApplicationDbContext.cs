using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServer.Database.Models;

public class ApplicationDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> User { get; set; }
    public DbSet<UserLogins> UserLogins { get; set; }
    public DbSet<UserToken> UserTokens { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    public DbSet<UserClaim> UserClaim { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("identity");

        builder.Entity<App>().HasMany<Role>().WithOne(x => x.App).HasForeignKey(x => x.AppId);
        builder.Entity<UserApp>()
            .HasKey(sc => new { sc.UserId, sc.AppId });

        builder.Entity<UserApp>()
            .HasOne(sc => sc.User)
            .WithMany(s => s.UserApp)
            .HasForeignKey(sc => sc.UserId);

        builder.Entity<UserApp>()
            .HasOne(sc => sc.App)
            .WithMany(c => c.UserApp)
            .HasForeignKey(sc => sc.AppId);
    }
}