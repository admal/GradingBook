using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GradingBookProject.Models;

namespace GradingBookProject.Forms
{
    public partial class GroupViewForm : Form
    {
        private Groups currGroup;
        private bool isAdmin;
        public GroupViewForm(Groups group, bool isAdmin = false)
        {
            InitializeComponent();

            this.isAdmin = isAdmin;
            currGroup = group;
            tbDesc.Text = group.description;
            lblUsername.Text = group.Users.ToString();
            foreach (var year in currGroup.Years)
            {
                yearsBindingSource.Add(year);
            }

            if (isAdmin)
            {
                tbDesc.Enabled = true;
                btnAddYear.Enabled = true;
            }


        }

        private void AddYearClick(object sender, EventArgs e)
        {
            var createYearForm = new YearForm(new Years());
            createYearForm.ShowDialog();
        }

        private void BackClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
