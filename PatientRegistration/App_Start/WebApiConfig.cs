using System.Web.Http;
using Microsoft.Practices.Unity;
using PatientRegistration.Models;
using PatientRegistration.Resolver;


namespace PatientRegistration
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IPatientRepository, PatientRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
           // GlobalConfiguration.Configuration.DependencyResolver = new  UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
