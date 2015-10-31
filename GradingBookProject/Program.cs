using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GradingBookProject.Forms;
using Ninject;

namespace GradingBookProject
{
    static class Program
    {

        private static IKernel _kernel;
        public static void CreateBindings( )
        {
            //generated method
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _kernel = new StandardKernel();
            CreateBindings();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(_kernel.Get<LoginForm>());
        }

    }
}