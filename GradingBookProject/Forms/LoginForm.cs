﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GradingBookProject.Data;
using Ninject;

namespace GradingBookProject.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void MoveToRegisterForm(object sender, EventArgs e)
        {
            var regForm = Program.GetKernel().Get<RegistrationForm>();
            regForm.ShowDialog();
        }

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
               // this.Close();
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
