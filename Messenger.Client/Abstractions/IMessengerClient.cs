using Messenger.Common.Models;
using Microsoft.AspNet.SignalR.Client;

namespace Messenger.Client.Abstractions
{
    public interface IMessengerClient
    {
        void OpenConnection(string messengerHub);
        void SendMessage(Message message);
        void CloseConnection();
        IHubProxy Hub { get; set; }
        HubConnection HubConnection { get; set; }
    }
}