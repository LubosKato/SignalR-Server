using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Microsoft.AspNet.SignalR.Hubs;

namespace Messenger.Server.IoC
{
    internal class WindosrIoC : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();

            container.Register(Classes.FromThisAssembly().BasedOn(typeof(IHub)).LifestyleTransient());
            var signalRDependencyResolver = new SignalRDependencyResolver(container);
            Microsoft.AspNet.SignalR.GlobalHost.DependencyResolver = signalRDependencyResolver;

            container.Register(
                Component.For<IUserServiceFactory>().AsFactory()
            );
        }
    }
}