using AuthenticationServer.Core.Request.Client;
using AuthenticationServer.Core.Request.User;

namespace AuthenticationServer.Core.Manager;

public interface IClientManager
{
    Task<Guid> CreateAsync(CreateClient request);
    Task UpdateAsync(UpdateClient request);
    Task DeleteAsync(DeleteClient request);
}

public class ClientManager : IClientManager
{
    public Task<Guid> CreateAsync(CreateClient request)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateClient request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(DeleteClient request)
    {
        throw new NotImplementedException();
    }
}