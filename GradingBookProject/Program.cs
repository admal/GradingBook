using System;

using System.Windows.Forms;
using GradingBookProject.Data;
using GradingBookProject.Forms;
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