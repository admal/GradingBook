using System.Web.Http;
using AutoMapper;
using GradingBookProject.Models;
using GradingBookProject.ViewModels;

namespace GradingBookApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Users, UsersViewModel>();
                config.CreateMap<GroupDetails, GroupDetailsViewModel>();
            });

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            GlobalConfiguration.Configure(WebApiConfig.Register);   
        }
    }
}
