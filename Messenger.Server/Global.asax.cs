using Castle.Windsor;
using System;
using System.Web.Http;
using Messenger.Server.IoC;

namespace Messenger.Server
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            new WindsorContainer().Install(new WindosrIoC());

        //    // Make long polling connections wait a maximum of 110 seconds for a
        //    // response. When that time expires, trigger a timeout command and
        //    // make the client reconnect.
        //    GlobalHost.Configuration.ConnectionTimeout = TimeSpan.FromSeconds(110);//110

        //    // Wait a maximum of 30 seconds after a transport connection is lost
        //    // before raising the Disconnected event to terminate the SignalR connection.
        //    GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(30);//30

        //    // For transports other than long polling, send a keepalive packet every
        //    // 10 seconds. 
        //    // This value must be no more than 1/3 of the DisconnectTimeout value.
        //    GlobalHost.Configuration.KeepAlive = TimeSpan.FromSeconds(10);

        //    GlobalHost.DependencyResolver.Register(typeof(IMyConnectionFactory),() => new MyConnectionFactory());
        }
    }
}