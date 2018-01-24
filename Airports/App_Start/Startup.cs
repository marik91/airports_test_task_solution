using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Airports.Services.Settings;
using Autofac;
using Autofac.Integration.Mvc;
using Owin;

namespace Airports
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServicesModule>();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
            
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}