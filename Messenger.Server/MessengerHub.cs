using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Messenger.Common.Models;
using Messenger.Server.Custom;
using Messenger.Server.Security;

namespace Messenger.Server
{
    public class MessengerHub : Hub
    {

        private readonly IUserService _userService;
        
        public MessengerHub(IUserService userService)
        {
            _userService = userService;
        }

        public void Send(Message message)
        {
            Clients.Group(message.Who.ToString()).broadcastMessage(
                new
                {
                    message.Title, 
                    message.Content,
                    Type = message.Type.ToString().ToCamelCase(),
                    message.Who,
                    message.Sender
                }
            );
        }

        public override Task OnConnected()
        {
            var user = _userService.GetCurrentUser();
            
            Groups.Add(Context.ConnectionId, user.Id.ToString());

            if (user.Team != null)
            {
                var teamId = user.Team.Id;
                
                Groups.Add(Context.ConnectionId, teamId.ToString());
            }

            return base.OnConnected();
        }
    }
}