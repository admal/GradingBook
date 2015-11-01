using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GradingBookProject.Validation;

namespace GradingBookProject.Forms
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
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
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
