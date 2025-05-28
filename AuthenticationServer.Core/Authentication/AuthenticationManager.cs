using AuthenticationServer.Core.Request.Authentication;
using AuthenticationServer.Database.Models;

namespace AuthenticationServer.Core.Authentication;

public class AuthenticationManager
{
    private readonly ApplicationDbContext _dbContext;

    public AuthenticationManager(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Login(LoginRequest loginRequest)
    {
        
    }
}