using System;
using Microsoft.AspNet.SignalR;

namespace Messenger.Server.Custom
{
    public class MyConnectionFactory : IMyConnectionFactory
    {
        public string CreateConnectionId(IRequest request)
        {
            if (request.Cookies["srconnectionid"] != null)
            {
                return request.Cookies["srconnectionid"].ToString();
            }

            return Guid.NewGuid().ToString();
        }
    }
}