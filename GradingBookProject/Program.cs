using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GradingBookApi.Models;
using GradingBookProject.Data;
using GradingBookProject.Forms;
using GradingBookProject.Http;
using GradingBookProject.Validation;
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
            //part just to show that it works
            HttpRequestService<Users> usersService = new HttpRequestService<Users>();
            //show all
            var users = usersService.GetAll().Result;
            string s = "";
            foreach (var user in users)
            {
                s += user.username + ", ";
            }
            MessageBox.Show(s);

            //show one
            var user1 = usersService.GetOne(1).Result;
            MessageBox.Show(user1.id+ " " +user1.username);
            //add new user
            var toAdd = new Users()
            {
                username = "AddedUser",
                email = "example@gmail.com",
                passwd = "passwd"
            };
            var ret = usersService.PostOne(toAdd).Result;
            
            //show new user
            users = usersService.GetAll().Result;
            //s = ret.id +"."+ ret.username + "|  ";
            s = "";
            foreach (var user in users)
            {
                s += user.username + ", ";
            }
            MessageBox.Show(s);

            //update user
            var editUser = users[0];
            editUser.username = "Edited";
            usersService.UpdateOne(editUser.id, editUser);

            users = usersService.GetAll().Result;
            //s = ret.id +"."+ ret.username + "|  ";
            s = "";
            foreach (var user in users)
            {
                s += user.username + ", ";
            }
            MessageBox.Show(s);

            ////////////////////////////////////
            Globals.CurrentUser = null;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(_kernel.Get<LoginForm>());
        }

    }
}