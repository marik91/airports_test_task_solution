using Airports.Services.QueryServices;
using Autofac;

namespace Airports.Services.Settings
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AirportsQueryService>().AsImplementedInterfaces().InstancePerRequest();
        }
    }
}