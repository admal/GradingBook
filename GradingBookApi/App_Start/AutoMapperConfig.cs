﻿using AutoMapper;
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
                config.CreateMap<Years, YearsViewModel>()
                    .ForMember(dest => dest.groupName, 
                    opt => opt.MapFrom(src => src.Groups==null? null : src.Groups.name ));
                config.CreateMap<Subjects, SubjectsViewModel>();
                config.CreateMap<SubjectDetails, SubjectDetailsViewModel>();

                config.CreateMap<Groups, ShowGroupViewModel>()
                    .ForMember(dest => dest.ownerName, opt => opt.MapFrom(src => src.Users.username));

                config.CreateMap<GroupDetails, ShowGroupDetailViewModel>()
                    .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.Users.username));

                config.CreateMap<Groups, GroupInYearViewModel>()
                    .ForMember(dest => dest.groupName, opt => opt.MapFrom(src => src.name))
                    .ForMember(dest => dest.ownerName, opt => opt.MapFrom(src => src.Users.username));

                config.CreateMap<Years, ShowYearViewModel>()
                    .ForMember(dest => dest.group, opt => opt.MapFrom(src => src.Groups))
                    .ForMember(dest => dest.Subjects, opt => opt.MapFrom(dest => dest.Subjects));
            });
        }
    }
}