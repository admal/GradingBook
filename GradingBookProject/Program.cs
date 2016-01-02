﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using GradingBookProject.Data;
using GradingBookProject.Forms;
using GradingBookProject.Http;
using GradingBookProject.Models;
using GradingBookProject.Validation;
using GradingBookProject.ViewModels;
using Ninject;

namespace GradingBookProject
{
    static class Program
    {
        /// <summary>
        /// Ninject kernel to inject objects to interfaces
        /// </summary>
        private static IKernel _kernel;

        /// <summary>
        /// Get Ninject kernel
        /// </summary>
        /// <returns>Ninject kernel</returns>
        public static IKernel GetKernel()
        {
            return _kernel;
        }
        /// <summary>
        /// Create all bindings between interfaces and classes
        /// </summary>
        public static void CreateBindings( )
        {
            //_kernel.Bind<IUsersRepository>().To<UsersRepository>();
            _kernel.Bind<IUsersRepository>().To<UsersRepository>();
            //_kernel.Bind<IGbUnitOfWork>().To<GradingBookDbEntities>();
            _kernel.Bind<ISubjectsRepository>().To<SubjectsRepository>();
            _kernel.Bind<IYearsRepository>().To<YearsRepository>();
            _kernel.Bind<IGradesRepository>().To<GradesRepository>();
            _kernel.Bind<IStringValidator>().To<Validator>();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _kernel = new StandardKernel();
            CreateBindings();
            
            Globals.CurrentUser = null;

            Mapper.Initialize(config =>
            {
                config.CreateMap<Users, UsersViewModel>();
                config.CreateMap<GroupDetails, GroupDetailsViewModel>();
            });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(_kernel.Get<LoginForm>());
        }

    }
}