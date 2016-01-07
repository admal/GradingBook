using System;
using System.Windows.Forms;
using GradingBookProject.Data;
using GradingBookProject.ViewModels;
using Ninject;
using Ninject.Parameters;

namespace GradingBookProject.Forms
{
    /// <summary>
    /// Form to login to the application
    /// </summary>
    public partial class LoginForm : Form
    {
        /// <summary>
        /// Constructor of the form
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            tbPasswd.PasswordChar = '*';
        }
        /// <summary>
        /// Button click handler, opens RegisterForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveToRegisterForm(object sender, EventArgs e)
        {
            var regForm = Program.GetKernel().Get<RegistrationForm>();
            regForm.ShowDialog();
        }
        /// <summary>
        /// Button click hanlder, it checks provided user credentials and if are proper opens MainForm and refuses to open if not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LoginUser(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;

            var username = tbLogin.Text;
            var passwd = tbPasswd.Text;

            //var userRepo = new UsersRepository();
            //IUsersRepository userRepo = Program.GetKernel().Get<IUsersRepository>();
            HttpUsersRepository userRepo = new HttpUsersRepository();

            if (await userRepo.LoginUser(username, passwd)) //login success
            {
                var mainForm = Program.GetKernel().Get<MainForm>();
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Provided credentials are invalid!", 
                    "Error!", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
            this.Enabled = true;
        }
    }
}
