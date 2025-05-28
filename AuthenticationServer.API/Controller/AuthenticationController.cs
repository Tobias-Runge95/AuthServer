using AuthenticationServer.Core.Manager;
using AuthenticationServer.Core.Request.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = AuthenticationServer.Core.Request.Authentication.LoginRequest;

namespace AuthenticationServer.API.Controller;

[Controller]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthManager _authManager;

    public AuthenticationController(IAuthManager authManager)
    {
        _authManager = authManager;
    }
    
    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        return Ok(await _authManager.Login(loginRequest));
    }
    
    [Authorize(Policy = "Logedin")]
    [HttpDelete("/logout")]
    public async Task<IActionResult> Logout([FromBody] LogoutRequest logoutRequest)
    {
        await _authManager.Logout(logoutRequest);
        return NoContent();
    }

    [Authorize(Policy = "Logedin")]
    [HttpPatch("/renew")]
    public async Task<IActionResult> Renew([FromBody] RenewRequest renewRequest)
    {
        return Ok(await _authManager.RenewToken(renewRequest));
    }
}