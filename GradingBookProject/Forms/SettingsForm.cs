using System;
using System.Windows.Forms;
using GradingBookProject.Data;
using GradingBookProject.Models;
using GradingBookProject.Validation;
using Ninject;

namespace GradingBookProject.Forms
{
    /// <summary>
    /// Window to edit user's credentials
    /// </summary>
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// Currenlty logged user
        /// </summary>
        private Users currUser;
        /// <summary>
        /// Form constructor
        /// </summary>
        /// <param name="user">User that is logged in</param>
        public SettingsForm(Users user)
        {
            currUser = user;
            InitializeComponent();

            tbName.Text = currUser.name;
            tbSurname.Text = currUser.surname;
            tbEmail.Text = currUser.email;
            tbUsername.Text = currUser.username;

            tbPasswd.PasswordChar = '*';
            tbConfPasswd.PasswordChar = '*';

            tbPasswd.Text = "xxx";
            tbConfPasswd.Text = "xxx";
        }
        /// <summary>
        /// Button click handler, cancels provided data and closes form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Validates given data and modifies user's credentials
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SaveChangesClick(object sender, EventArgs e)
        {
            var validator = Program.GetKernel().Get<IStringValidator>();
            //var currUser = Globals.CurrentUser;

            var name = tbName.Text;
            var surname = tbSurname.Text;
            var email = tbEmail.Text;
            var username = tbUsername.Text;
            var passwd = tbPasswd.Text;
            var confPasswd = tbConfPasswd.Text;


            //var repo = new UsersRepository();
            //IUsersRepository repo = Program.GetKernel().Get<IUsersRepository>();
            HttpUsersRepository repo = new HttpUsersRepository();
           
            try
            {
                username = validator.ValidateUsername(username);
                if (username != currUser.username) //only edit if any changes were provided
                {
                    if (await repo.UserExists(username))
                    {
                        MessageBox.Show("Such a user already exists!");
                        return;
                    }
                    currUser.username = username;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            currUser.name = name;
            currUser.surname = surname;
            if(email != "") //if was not provided do not let to
            {
                if (validator.isValidMail(email))
                {
                    currUser.email = email;
                }
                else
                {
                    MessageBox.Show("Not valid email was provided!");
                    return;
                }
            }

            try
            {
                if (passwd != "xxx") //it means that nth was changed
                {   
                    passwd = validator.ValidatePassword(passwd);
                    confPasswd = validator.ValidatePassword(confPasswd);

                    if (validator.ValidatePasswordConfirmation(passwd, confPasswd))
                    {
                        currUser.passwd = passwd;
                    }

                }
                await repo.EditOne(currUser);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
