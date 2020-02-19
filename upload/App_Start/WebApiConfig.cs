using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {

        var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
        json.SerializerSettings.DateFormatHandling
        = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;

        var settings = config.Formatters.JsonFormatter.SerializerSettings;
        settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        settings.Formatting = Formatting.Indented;

        // Web API routes
        config.MapHttpAttributeRoutes();

        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );

    }
}