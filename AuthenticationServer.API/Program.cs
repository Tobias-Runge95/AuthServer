using AuthenticationServer.API.Extensions;
using AuthenticationServer.Core;
using AuthenticationServer.Core.Authentication;
using AuthenticationServer.Core.Factories;
using AuthenticationServer.Database.Models;
using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddAzureClients(azureBuilder =>
{
    azureBuilder.AddKeyClient(new Uri($"https://authserver.vault.azure.net/"));
    // azureBuilder.AddCryptographyClient(new Uri($"https://authserver.vault.azure.net/"));
    azureBuilder.UseCredential(new ClientSecretCredential(
        tenantId: builder.Configuration["KeyVault:TenantId"],
        clientId: builder.Configuration["KeyVault:ClientId"], 
        clientSecret: builder.Configuration["KeyVault:Secret"]
    ));
});
// await CryptographyClientExtension.RegisterCryptographyClient(builder);
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddUserManager<UserManager<User>>()
    .AddRoles<Role>()
    .AddRoleManager<RoleManager<Role>>()
    .AddRoleStore<RoleStore<Role, ApplicationDbContext, Guid>>()
    .AddUserStore<UserStore<User, IdentityRole<Guid>, ApplicationDbContext, Guid>>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddTransient<ICryptographyClientFactory, CryptographyClientFactory>();
builder.Services.Register();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
