using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GradingBookProject.Data;
using GradingBookProject.Forms;
using Ninject;

namespace GradingBookProject
{
    static class Program
    {

        private static IKernel _kernel;

        public static IKernel GetKernel()
        {
            return _kernel;
        }
        public static void CreateBindings( )
        {
            _kernel.Bind<IUsersRepository>().To<UsersRepository>();
            //_kernel.Bind<IGbUnitOfWork>().To<GradingBookDbEntities>();
            _kernel.Bind<ISubjectsRepository>().To<SubjectsRepository>();
            _kernel.Bind<IYearsRepository>().To<YearsRepository>();
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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(_kernel.Get<LoginForm>());
        }

    }
}