using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using AutoMapper;
using upload.App_Start;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace upload
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(c=>c.AddProfile<MappingProfile>());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //http://localhost:49533/api/?type=json
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
            new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));
            //http://localhost:49533/api/?type=xml
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
            new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));
        }
    }
}
