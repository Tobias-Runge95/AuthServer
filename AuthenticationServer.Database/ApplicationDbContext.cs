using AuthenticationServer.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServer.Database;

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

        builder.Entity<Client>().HasMany<Role>().WithOne(x => x.Client).HasForeignKey(x => x.AppId);
        builder.Entity<UserClient>()
            .HasKey(sc => new { sc.UserId, sc.AppId });

        builder.Entity<UserClient>()
            .HasOne(sc => sc.User)
            .WithMany(s => s.UserClients)
            .HasForeignKey(sc => sc.UserId);

        builder.Entity<UserClient>()
            .HasOne(sc => sc.Client)
            .WithMany(c => c.UserClients)
            .HasForeignKey(sc => sc.AppId);
        
        builder.Entity<AuthorizationCode>()
            .HasOne(c => c.Client)
            .WithMany(c => c.AuthorizationCodes)
            .HasForeignKey(c => c.ClientId);
        
        builder.Entity<AuthorizationCode>()
            .HasOne(u => u.Subject)
            .WithMany(c => c.AuthorizationCodes)
            .HasForeignKey(c => c.SubjectId);
        
        builder.Entity<AuthorizationCodeScope>()
            .HasOne(ac => ac.AuthorizationCode)
            .WithMany(acs => acs.Scopes)
            .HasForeignKey(ac => ac.AuthorizationCodeId);
        
        builder.Entity<AuthorizationCodeScope>()
            .HasOne(ac => ac.Scope)
            .WithMany(acs => acs.AuthorizationCodeScopes)
            .HasForeignKey(ac => ac.ScopeId);
        
        builder.Entity<AccessTokenScope>()
            .HasOne(ac => ac.AccessToken)
            .WithMany(acs => acs.Scopes)
            .HasForeignKey(ac => ac.AccessTokenId);
        
        builder.Entity<AccessTokenScope>()
            .HasOne(ac => ac.Scope)
            .WithMany(ats => ats.AccessTokenScopes)
            .HasForeignKey(ac => ac.ScopeId);
        
        builder.Entity<AccessToken>()
            .HasOne(c => c.Client)
            .WithMany(c => c.AccessTokens)
            .HasForeignKey(c => c.ClientId);
        
        builder.Entity<AccessToken>()
            .HasOne(c => c.Subject)
            .WithMany(c => c.AccessTokens)
            .HasForeignKey(c => c.SubjectId);
        
        builder.Entity<RefreshToken>()
            .HasOne(t => t.Client)
            .WithMany(c => c.RefreshTokens)
            .HasForeignKey(t => t.ClientId);
        
        builder.Entity<RefreshToken>()
            .HasOne(u => u.Subject)
            .WithMany(c => c.RefreshTokens)
            .HasForeignKey(u => u.SubjectId);
    }
}