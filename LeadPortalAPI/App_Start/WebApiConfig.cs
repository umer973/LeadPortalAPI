using LeadPortalAPI.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LeadPortalAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
          
            var JSON = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            JSON.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.MessageHandlers.Add(new WrappingHandler());

            config.Filters.Add(new Attributes.APIExceptionFilterAttribute());
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
