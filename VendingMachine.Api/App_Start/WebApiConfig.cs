using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Http.Cors;
using VendingMachine.Api.Common;
using VendingMachine.Api.Common.Validation;

namespace VendingMachine.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.Filters.Add(new ApiExceptionAttribute());
            config.Filters.Add(new ValidateModelAttribute());
            config.Filters.Add(new CheckModelForNullAttribute());

            var jsonSettings = config.Formatters.JsonFormatter.SerializerSettings;

            jsonSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            jsonSettings.NullValueHandling = NullValueHandling.Ignore;


            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            var cors = new EnableCorsAttribute("*", "*", "*", "*");
            config.EnableCors(cors);
        }
    }
}
