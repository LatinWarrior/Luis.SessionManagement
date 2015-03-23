using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Luis.SessionManagement.WebApi.Handlers;
using Luis.SessionManagement.WebApi.Models;

namespace Luis.SessionManagement.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
                                    
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());                             

            // Deal with your dependencies here.
            builder.RegisterType<SessionHandler>().As<ISessionHandler>().InstancePerLifetimeScope();
            builder.RegisterType<PresenterHandler>().As<IPresenterHandler>().InstancePerLifetimeScope();
            builder.RegisterType<SessionPresenterHandler>().As<ISessionPresenterHandler>().InstancePerLifetimeScope();
            builder.Register(x => new SessionContext()).InstancePerLifetimeScope();

            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);
             
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            GlobalConfiguration.Configure(WebApiConfig.Register);

            AutoMapperConfig.RegisterMappings();
        }
    }
}
