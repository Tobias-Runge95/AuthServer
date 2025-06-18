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
    public DbSet<Client> Clients { get; set; }
    public DbSet<Scope> Scopes { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<AccessToken> AccessTokens { get; set; }
    public DbSet<UserClient> UserClients { get; set; }
    public DbSet<AuthorizationCode> AuthorizationCodes { get; set; }
    public DbSet<AuthorizationCodeScope> AuthorizationCodeScopes { get; set; }
    public DbSet<AccessTokenScope> AccessTokenScopes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("identity");

        builder.Entity<Client>().HasMany<Role>().WithOne(x => x.Client).HasForeignKey(x => x.AppId);
        
        builder.Entity<Scope>()
            .HasKey(x => x.Id);
        
        builder.Entity<RefreshToken>()
            .HasKey(x => x.Id);
        
        builder.Entity<AccessToken>()
            .HasKey(x => x.Id);

        
        var client = builder.Entity<Client>();
        client.HasKey(x => x.Id);
        client
            .HasOne(c => c.ContactUser)
            .WithOne(u => u.ContactForClient)
            .HasForeignKey<Client>(c => c.ContactUserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        var userClient = builder.Entity<UserClient>();
        userClient.HasKey(sc => new { sc.UserId, sc.AppId });
        userClient
            .HasOne(sc => sc.User)
            .WithMany(s => s.UserClients)
            .HasForeignKey(sc => sc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        userClient
            .HasOne(sc => sc.Client)
            .WithMany(c => c.UserClients)
            .HasForeignKey(sc => sc.AppId)
            .OnDelete(DeleteBehavior.Cascade);

        var authorizationCode = builder.Entity<AuthorizationCode>();
        authorizationCode.HasKey(x => x.Id);
        authorizationCode
            .HasOne(c => c.Client)
            .WithMany(c => c.AuthorizationCodes)
            .HasForeignKey(c => c.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
        
        authorizationCode
            .HasOne(u => u.Subject)
            .WithMany(c => c.AuthorizationCodes)
            .HasForeignKey(c => c.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        var AuthorizationCodeScope = builder.Entity<AuthorizationCodeScope>();
        AuthorizationCodeScope.HasKey(x => new { x.AuthorizationCodeId, x.ScopeId });
        AuthorizationCodeScope
            .HasOne(ac => ac.AuthorizationCode)
            .WithMany(acs => acs.Scopes)
            .HasForeignKey(ac => ac.AuthorizationCodeId)
            .OnDelete(DeleteBehavior.Cascade);
        
        AuthorizationCodeScope
            .HasOne(ac => ac.Scope)
            .WithMany(acs => acs.AuthorizationCodeScopes)
            .HasForeignKey(ac => ac.ScopeId)
            .OnDelete(DeleteBehavior.Cascade);

        var accessTokenScope = builder.Entity<AccessTokenScope>();
        accessTokenScope.HasKey(x => new { x.AccessTokenId, x.ScopeId });
        accessTokenScope
            .HasOne(ac => ac.AccessToken)
            .WithMany(acs => acs.Scopes)
            .HasForeignKey(ac => ac.AccessTokenId)
            .OnDelete(DeleteBehavior.Cascade);
        
        accessTokenScope
            .HasOne(ac => ac.Scope)
            .WithMany(ats => ats.AccessTokenScopes)
            .HasForeignKey(ac => ac.ScopeId)
            .OnDelete(DeleteBehavior.Cascade);

        var accessToken = builder.Entity<AccessToken>();
        accessToken.HasKey(x => x.Id);
        accessToken
            .HasOne(c => c.Client)
            .WithMany(c => c.AccessTokens)
            .HasForeignKey(c => c.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
        
        accessToken
            .HasOne(c => c.Subject)
            .WithMany(c => c.AccessTokens)
            .HasForeignKey(c => c.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);
        
        var refreshToken = builder.Entity<RefreshToken>();
        refreshToken.HasKey(x => x.Id);
        refreshToken
            .HasOne(t => t.Client)
            .WithMany(c => c.RefreshTokens)
            .HasForeignKey(t => t.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
        
        refreshToken
            .HasOne(u => u.Subject)
            .WithMany(c => c.RefreshTokens)
            .HasForeignKey(u => u.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);
        
        var clientSCope =  builder.Entity<ClientScope>();
        clientSCope.HasKey(sc => new { sc.ClientId, sc.ScopeId });
        clientSCope.HasOne(sc => sc.Client)
            .WithMany(sc => sc.ClientScopes)
            .HasForeignKey(sc => sc.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
        
        clientSCope.HasOne(sc => sc.Scope)
            .WithMany(sc => sc.ClientScopes)
            .HasForeignKey(sc => sc.ScopeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}