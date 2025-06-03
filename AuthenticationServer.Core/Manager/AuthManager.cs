using System.Security.Claims;
using AuthenticationServer.Core.KeyVault;
using AuthenticationServer.Core.Request.Authentication;
using AuthenticationServer.Core.Responses.Auth;
using AuthenticationServer.Database;
using AuthenticationServer.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServer.Core.Manager;

public interface IAuthManager
{
    Task<LoginResponse> Login(LoginRequest loginRequest);
    Task Logout(LogoutRequest logoutRequest);
    Task<LoginResponse> RenewToken(RenewRequest renewRequest);
}

public class AuthManager : IAuthManager
{
    private readonly ApplicationDbContext  _context;
    private readonly UserManager _userManager;
    private readonly TokenService _tokenService;

    public AuthManager(ApplicationDbContext context, UserManager userManager, TokenService tokenService)
    {
        _context = context;
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<LoginResponse> Login(LoginRequest loginRequest)
    {
        var user =  await _userManager.FindByEmailAsync(loginRequest.Email);
        if (user is null)
        {
            throw new Exception("User not found");
        }
        
        bool isPasswordValid = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
        if (!isPasswordValid)
        {
            throw new Exception("Invalid password");
        }

        var claims = await GetClaims(user);
        var token = await _tokenService.GenerateTokensAsync(claims);
        await _context.UserTokens.AddAsync(new UserToken()
            { LoginProvider = "API", Name = "Renew", UserId = user.Id, Value = token.RenewToken });
        await _context.SaveChangesAsync();
        token.UserId = user.Id;
        return token;
    }

    public async Task Logout(LogoutRequest logoutRequest)
    {
        var userToken = await _context.UserTokens.Where(x => x.UserId == logoutRequest.UserId).FirstAsync();
        _context.UserTokens.Remove(userToken);
        await _context.SaveChangesAsync();
    }

    public async Task<LoginResponse> RenewToken(RenewRequest renewRequest)
    {
        var user = await _userManager.GetUserAsync(renewRequest.UserId);
        var userToken = await _context.UserTokens.Where(x => x.UserId == user.Id).FirstAsync();
        if (userToken is null)
        {
            throw new Exception("No Token found");
        }
        var claims = await GetClaims(user);
        var token = await _tokenService.GenerateTokensAsync(claims);
        await _context.UserTokens.AddAsync(new UserToken()
            { LoginProvider = "API", Name = "Renew", UserId = user.Id, Value = token.RenewToken });
        await _context.SaveChangesAsync();
        token.UserId = user.Id;
        return token;
    }

    private async Task<List<Claim>> GetClaims(User user)
    {
        var claims = await _userManager.GetClaimsAsync(user);
        claims.Add(new Claim(ClaimTypes.Role, "Logedin"));
        var roles = await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        
        return claims.ToList();
    }
}