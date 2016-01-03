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
                config.CreateMap<Groups, GroupsViewModel>();
                config.CreateMap<Years, YearsViewModel>();
                config.CreateMap<Subjects, SubjectsViewModel>();
                config.CreateMap<SubjectDetails, SubjectDetailsViewModel>();
            });

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            GlobalConfiguration.Configure(WebApiConfig.Register);   
        }
    }
}
