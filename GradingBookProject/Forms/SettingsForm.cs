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
    public partial class SettingsForm : Form
    {
        private Users currUser;
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

        private void CancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveChangesClick(object sender, EventArgs e)
        {
            var validator = Program.GetKernel().Get<IStringValidator>();
            //var currUser = Globals.CurrentUser;

            var name = tbName.Text;
            var surname = tbSurname.Text;
            var email = tbEmail.Text;
            var username = tbUsername.Text;
            var passwd = tbPasswd.Text;
            var confPasswd = tbConfPasswd.Text;

            
            var repo = new UsersRepository();
            try
            {
                username = validator.ValidateUsername(username);
                if (username != currUser.username) //only edit if any changes were provided
                {
                    if (repo.userExists(username))
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
                repo.EditUser(currUser);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
