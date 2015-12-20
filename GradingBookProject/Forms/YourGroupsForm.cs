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
    public partial class YourGroupsForm : Form
    {
        private Users currUser;
        public YourGroupsForm()
        {
            InitializeComponent();

            currUser = Globals.CurrentUser;

            var usersGroups = new List<Groups>();
            foreach (var groupDetail in currUser.GroupDetails)
            {
                groupsBindingSource.Add(groupDetail.Groups);
            }
            groupsGridView.CellDoubleClick += SeeGroupDetailsClick;
            
        }

        void SeeGroupDetailsClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIdx = e.RowIndex;
            Groups group = (Groups) groupsBindingSource[rowIdx];

            var seeGroupForm = new GroupViewForm(group);
            seeGroupForm.Show();
        }

        private void BackClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewGroupClick(object sender, EventArgs e)
        {
            var newGroupForm = new CreateGroupForm();
            newGroupForm.ShowDialog();
        }
        
        


    }
}
