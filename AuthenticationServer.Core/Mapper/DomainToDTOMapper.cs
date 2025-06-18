using AuthenticationServer.Core.DTO.Client;
using AuthenticationServer.Core.DTO.Scope;
using AuthenticationServer.Database.Models;

namespace AuthenticationServer.Core.Mapper;

public static class DomainToDTOMapper
{
    public static ScopeDTO MapToScopeDTO(this Scope scope)
    {
        return new ScopeDTO
        {
            Id = scope.Id,
            Name = scope.Name,
            Description = scope.Description
        };
    }

    public static ClientDTO MapToClientDTO(this Client client)
    {
        var scopeDTOs = new List<ScopeDTO>();
        foreach (ClientScope clientScope in client.ClientScopes)
        {
            scopeDTOs.Add(clientScope.Scope.MapToScopeDTO());
        }

        return new ClientDTO
        {
            Id = client.Id,
            AllowedGrantTypes = client.AllowedGrantTypes,
            ClientName = client.ClientName,
            ClientType = client.ClientType,
            RedirectUris = client.RedirectUris,
            AllowedScopes = scopeDTOs
        };
    }

    public static ShortClientDTO MapToShortClientDTO(this Client client)
    {
        return new ShortClientDTO
        {
            ClientName = client.ClientName,
            ClientType = client.ClientType,
            Id = client.Id,
            CreatedAt = client.CreatedAt,
            IsEnabled = client.IsEnabled,
        };
    }
}