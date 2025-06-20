using AuthenticationServer.Core.Manager;
using AuthenticationServer.Core.Request.Client;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationServer.API.Controller;

[Controller, Route("client")]
public class ClientController : ControllerBase
{
    private readonly IClientManager _clientManager;

    public ClientController(IClientManager clientManager)
    {
        _clientManager = clientManager;
    }

    [HttpPost("/create")]
    public async Task<IActionResult> CreateClient(CreateClient request)
    {
        await _clientManager.CreateAsync(request);
        return Created();
    }

    [HttpPatch("/enable")]
    public async Task<IActionResult> EnableClient(EnableClient request)
    {
        await _clientManager.ActivateClient(request);
        return Ok();
    }

    [HttpGet("/get/{clientId}")]
    public async Task<IActionResult> GetClient(Guid clientId)
    {
        var client = await _clientManager.GetClientAsync(clientId);
        return Ok(client);
    }

    [HttpPatch("/update")]
    public async Task<IActionResult> UpdateClient(UpdateClient request)
    {
        await _clientManager.UpdateAsync(request);
        return NoContent();
    }

    [HttpDelete("/delete")]
    public async Task<IActionResult> DeleteClient(DeleteClient request)
    {
        await _clientManager.DeleteAsync(request);
        return NoContent();
    }

    [HttpGet("/get-all")]
    public async Task<IActionResult> GetAllClients()
    {
        var clients = await _clientManager.GetAllClients();
        return Ok(clients);
    }

    [HttpPost("/rotate-secret")]
    public async Task<IActionResult> RotateSecret(RotateClientSecretRequest request)
    {
        await _clientManager.RotateClientSecretAsync(request);
        return NoContent();
    }

    [HttpGet("/jwks")]
    public async Task<IActionResult> GetJwks()
    {
        
        return Ok();
    }

    [HttpPost("/{clientId}/users")]
    public async Task<IActionResult> GetUsers(Guid clientId)
    {
        var users = await _clientManager.GetClientUsersAsync(clientId);
        return Ok(users);
    }

    [HttpPost("/add")]
    public async Task<IActionResult> AddUserToClient(AddUserToClient request)
    {
        await _clientManager.AssignUserToClientAsync(request.UserId, request.ClientId);
        return Ok();
    }
}