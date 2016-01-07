using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;

using Owin;
using Messenger.Server;
using Messenger.Server.Custom;

[assembly: OwinStartup(typeof(Startup))]
namespace Messenger.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var hubConfiguration = new HubConfiguration
            {
                EnableJavaScriptProxies = false,
                EnableJSONP = true
            };

            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR(hubConfiguration);


            GlobalHost.HubPipeline.RequireAuthentication();

            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new SignalRContractResolver();
            var serializer = JsonSerializer.Create(settings);
            GlobalHost.DependencyResolver.Register(typeof(JsonSerializer), () => serializer);   

        }
    }
}
