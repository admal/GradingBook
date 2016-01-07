using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using GradingBookProject.Models;
using Newtonsoft.Json;

namespace GradingBookApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ActionApiGroupId",
                routeTemplate: "api/years/getByGroupId/{groupId}"
                );
            config.Routes.MapHttpRoute(
                  name: "ActionSubjectApiId",
                  routeTemplate: "api/subjects/{action}/{id}"
                  );
            config.Routes.MapHttpRoute(
                  name: "ActionGroupDetailsApiId",
                  routeTemplate: "api/groupdetails/{action}/{id}"
                  );
            config.Routes.MapHttpRoute(
                name: "DoubleParamAction",
                routeTemplate: "api/{controller}/{action}/{groupId}/{userId}"
                );
            /*config.Routes.MapHttpRoute(
                  name: "ActionGradeApiId",
                  routeTemplate: "api/subjectDetails/{action}/{id}"
                  );*/
            
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
