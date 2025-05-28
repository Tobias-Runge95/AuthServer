using AuthenticationServer.Core.Authentication;
using AuthenticationServer.Core.Manager;
using AuthenticationServer.Core.Request.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationServer.API.Controller;

[Controller, Route("api/[controller]")]
public class UserController : ControllerBase
{
    private UserManager _userManager;

    public UserController(UserManager userManager)
    {
        _userManager = userManager;
    }
    
    
}