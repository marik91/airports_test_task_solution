using Airports.Domain.CommandHandler;
using Autofac;

namespace Airports.Domain.Settings
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AirportsCommandHandler>().AsImplementedInterfaces().InstancePerRequest();
        }
    }
}