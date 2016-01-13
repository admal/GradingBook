using AutoMapper;
using GradingBookApi.ApiViewModels;
using GradingBookProject.Models;
using GradingBookProject.ViewModels;

namespace GradingBookApi.App_Start
{
    /// <summary>
    /// Configuration class of the Automapper.
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Creates all proper mappings between model and viewmodels.
        /// </summary>
        public static void Register()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Users, UsersViewModel>();
                config.CreateMap<GroupDetails, GroupDetailsViewModel>();
                config.CreateMap<Groups, GroupsViewModel>();
                config.CreateMap<Years, YearsViewModel>();
                config.CreateMap<Subjects, SubjectsViewModel>();
                config.CreateMap<SubjectDetails, SubjectDetailsViewModel>();

                config.CreateMap<Groups, ShowGroupViewModel>()
                    .ForMember(dest => dest.ownerName, opt => opt.MapFrom(src => src.Users.name));
            });
        }
    }
}