using Microsoft.AspNet.SignalR;

namespace Messenger.Server.Custom
{
    public interface IMyConnectionFactory
    {
        string CreateConnectionId(IRequest request);
    }
}