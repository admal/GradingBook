using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GradingBookApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                  name: "ActionApiId",
                  routeTemplate: "api/subjects/{action}/{id}"
                  ); 
            config.Routes.MapHttpRoute(
                name: "ActionApiUsername",
                routeTemplate: "api/{controller}/{action}/{username}"
                );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}
