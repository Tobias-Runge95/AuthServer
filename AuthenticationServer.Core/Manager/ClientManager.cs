using AuthenticationServer.Core.DTO.Client;
using AuthenticationServer.Core.DTO.User;
using AuthenticationServer.Core.Mapper;
using AuthenticationServer.Core.Request.Client;
using AuthenticationServer.Core.Request.User;
using AuthenticationServer.Core.Stores;
using AuthenticationServer.Database;
using AuthenticationServer.Database.Models;

namespace AuthenticationServer.Core.Manager;

public interface IClientManager
{
    Task<Guid> CreateAsync(CreateClient request);
    Task UpdateAsync(UpdateClient request);
    Task DeleteAsync(DeleteClient request);
    Task<ClientDTO> GetClientAsync(Guid clientId);
    Task<List<ShortClientDTO>> GetAllClients();
    Task ActivateClient(EnableClient  request);
    
    // --- Sicherheit
    Task RotateClientSecretAsync(RotateClientSecretRequest  request);

    // --- Benutzerzuordnung
    Task<List<ShortUserDTO>> GetClientUsersAsync(Guid clientId);
    Task AssignUserToClientAsync(Guid clientId, Guid userId);
    Task RemoveUserFromClientAsync(Guid clientId, Guid userId);

    // --- Validierung (intern)
    Task<bool> ValidateRedirectUriAsync(Guid clientId, string redirectUri); 
    
    // --- ClientScope
    Task CreateClientScopeAsync(Guid clientId, Guid scopeId);
    Task CreateClientScopeAsync(Guid clientId, string scopeName);
    Task CreateClientScopesAsync(Guid clientId, List<ClientScope> scopes);
    Task<ClientScope> GetClientScopeAsync(Guid clientId, Guid scopeId);
    Task<List<ClientScope>> GetAllClientScopes();
    Task RemoveClientScopeAsync(Guid clientId, Guid scopeId);
}

public class ClientManager : IClientManager
{
    // private readonly IClientStore _clientStore;
    // private readonly IScopeStore _scopeStore;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserClientManager  _userClientManager;
//IClientStore clientStore, IScopeStore scopeStore, 
    public ClientManager(IUserClientManager userClientManager, IUnitOfWork unitOfWork)
    {
        // _clientStore = clientStore;
        // _scopeStore = scopeStore;
        _userClientManager = userClientManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> CreateAsync(CreateClient request)
    {
        var scopes = await _unitOfWork.Scopes.GetAllAsync(request.AllowedScopes);
        var clientScopes = new List<ClientScope>();
        
        var client = new Client
        {
            Id = Guid.NewGuid(),
            ClientId = request.ClientName,
            ClientName = request.ClientName,
            ClientType = request.ClientType,
            AllowedGrantTypes = request.AllowedGrantTypes,
            RedirectUris = request.RedirectUris,
            CreatedAt = DateTime.UtcNow
        };
        if (request.ClientType == "confidential")
        {
            client.ClientSecretHash = request.ClientSecretHash;
        }
        foreach (var scope in scopes)
        {
            var clientScope = new ClientScope
            {
                ClientId = client.Id,
                ScopeId = scope.Id,
            };
            clientScopes.Add(clientScope);
        }
        await _unitOfWork.Clients.AddAsync(client);
        await _unitOfWork.ClientScopes.AddManyAsync(clientScopes);

        return client.Id;
    }

    public Task UpdateAsync(UpdateClient request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(DeleteClient request)
    {
        throw new NotImplementedException();
    }

    public async Task<ClientDTO> GetClientAsync(Guid clientId)
    {
        var client = await _unitOfWork.Clients.GetAsync(clientId);

        return client.MapToClientDTO();
    }

    public async Task<List<ShortClientDTO>> GetAllClients()
    {
        var clients = await _unitOfWork.Clients.GetAllAsync();
        
        return clients.Select(x => x.MapToShortClientDTO()).ToList();
    }

    public Task ActivateClient(EnableClient request)
    {
        throw new NotImplementedException();
    }

    public async Task RotateClientSecretAsync(RotateClientSecretRequest  request)
    {


        await _unitOfWork.Clients.RotateClientSecretAsync(request.NewSecret, request.Id);
    }

    public Task<List<ShortUserDTO>> GetClientUsersAsync(Guid clientId)
    {
        throw new NotImplementedException();
    }

    public Task AssignUserToClientAsync(Guid clientId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveUserFromClientAsync(Guid clientId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ValidateRedirectUriAsync(Guid clientId, string redirectUri)
    {
        throw new NotImplementedException();
    }

    public Task CreateClientScopeAsync(Guid clientId, Guid scopeId)
    {
        throw new NotImplementedException();
    }

    public Task CreateClientScopeAsync(Guid clientId, string scopeName)
    {
        throw new NotImplementedException();
    }

    public Task CreateClientScopesAsync(Guid clientId, List<ClientScope> scopes)
    {
        throw new NotImplementedException();
    }

    public Task<ClientScope> GetClientScopeAsync(Guid clientId, Guid scopeId)
    {
        throw new NotImplementedException();
    }

    public Task<List<ClientScope>> GetAllClientScopes()
    {
        throw new NotImplementedException();
    }

    public Task RemoveClientScopeAsync(Guid clientId, Guid scopeId)
    {
        throw new NotImplementedException();
    }
}