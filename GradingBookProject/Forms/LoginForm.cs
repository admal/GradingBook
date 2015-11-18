using System;
using System.Windows.Forms;
using GradingBookProject.Data;
using Ninject;

namespace GradingBookProject.Forms
{
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
        private void LoginUser(object sender, EventArgs e)
        {
            var username = tbLogin.Text;
            var passwd = tbPasswd.Text;

            var userRepo = new UsersRepository();

            if (userRepo.LoginUser(username, passwd)) //login success
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
        }
    }
}
