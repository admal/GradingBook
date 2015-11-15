using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GradingBookProject.Data;
using GradingBookProject.Forms;
using GradingBookProject.Validation;
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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(_kernel.Get<LoginForm>());
        }

    }
}