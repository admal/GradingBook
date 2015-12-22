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
using GradingBookProject.Models;

namespace GradingBookProject.Forms
{
    public partial class YourGroupsForm : Form
    {
        private Users currUser;
        public YourGroupsForm()
        {
            InitializeComponent();

            
        }

        public void UpdateGridView()
        {

        }


        private void EditGroupClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void SeeGroupDetailsClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BackClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewGroupClick(object sender, EventArgs e)
        {
        }

    }
}
