using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GradingBookProject.Http;
using GradingBookProject.ViewModels;


namespace GradingBookProject.Forms
{
    public partial class GroupViewForm : Form
    {
        public GroupViewForm(GroupsViewModel group, bool isAdmin = false)
        {
            InitializeComponent();
        }

        private void AddYearClick(object sender, EventArgs e)
        {
        }

        private void BackClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void LeaveGroupClick(object sender, EventArgs e)
        {

        }
    }
}
