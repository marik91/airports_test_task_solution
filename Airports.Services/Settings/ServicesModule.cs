using Airports.Services.QueryServices;
using Airports.Services.Repositories;
using Autofac;

namespace Airports.Services.Settings
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AirportsQueryService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<CountryQueryService>().AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<AirportsFeedRepository>().AsSelf().InstancePerRequest();
        }
    }
}