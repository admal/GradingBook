using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GradingBookProject.Data;
using GradingBookProject.Validation;
using Ninject;

namespace GradingBookProject.Forms
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();

            tbPasswd.PasswordChar = '*';
            tbPasswdConfirm.PasswordChar = '*';
        }
        //----------------------------------------------
        //EVENT HANDLERS
        //----------------------------------------------

        //---------------
        //button click handlers
        //---------------


        /// <summary>
        /// Cancels adding a new user
        /// </summary>
        /// <param name="sender">Object that created the event </param>
        /// <param name="e">Event arguments</param>
        private void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Validates input data to registration
        /// </summary>
        /// <param name="sender">Object that created the event </param>
        /// <param name="e">Event arguments</param>
        private void ValidateData(object sender, EventArgs e)
        {
            IStringValidator val = new Validator();

            var username = tbUsername.Text;
            var password = tbPasswd.Text;
            var confirmPasswd = tbPasswdConfirm.Text;

            try
            {
                var validatedUsername = val.ValidateUsername(username);
                var validatedPasswd = val.ValidatePassword(password);

                val.ValidatePasswordConfirmation(password, confirmPasswd);

                //put proper user to database
                var uRepo = Program.GetKernel().Get<IUsersRepository>();
                uRepo.AddUser(new Users()
                {
                    passwd = validatedPasswd,
                    username = validatedUsername,
                    email = "desktopApp" //temporary mail (cant be basically null)
                });
                MessageBox.Show("User was created properly!", 
                    "Added user", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, 
                    "Error", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
