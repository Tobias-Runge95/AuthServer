using AuthenticationServer.Core.Manager;
using AuthenticationServer.Core.Request.Role;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationServer.API.Controller;

[Controller, Route("api/[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly IRoleManager _roleManager;

    public AuthorizationController(RoleManager roleManager)
    {
        _roleManager = roleManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] CreateRole request, CancellationToken cancellationToken)
    {
        await _roleManager.CreateRole(request, cancellationToken);
        return Created();
    }
    
    [HttpPatch]
    public async Task<IActionResult> UpdateRole([FromBody] UpdateRole request, CancellationToken cancellationToken)
    {
        await _roleManager.UpdateRole(request, cancellationToken);

        return NoContent();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllRoles(CancellationToken cancellationToken)
    {
        var result = await _roleManager.GetAllRoles(cancellationToken);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteRole([FromBody] DeleteRole request, CancellationToken cancellationToken)
    {
        await _roleManager.DeleteRole(request, cancellationToken);
        return NoContent();
    }
}