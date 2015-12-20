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
            
            //Task.Run(() => this.InitForm()).Wait();

            currUser = Globals.CurrentUser;
            
            UpdateGridView();
            groupsGridView.CellContentClick += EditGroupClick;
            groupsGridView.CellDoubleClick += SeeGroupDetailsClick;
            
        }

        public void UpdateGridView()
        {
            groupsBindingSource.Clear();
            foreach (var groupDetail in currUser.GroupDetails)
            {
                if (groupDetail.Groups.Users == null)
                    groupDetail.Groups.Users = currUser;
                if (groupDetail.Users == null)
                    groupDetail.Users = currUser;

                groupsBindingSource.Add(groupDetail.Groups);
            }
        }


        private void EditGroupClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView) sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Groups group = (Groups) groupsBindingSource[e.RowIndex];
                var createForm = new CreateGroupForm(group, true);
                createForm.Show();
            }
        }

        void SeeGroupDetailsClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIdx = e.RowIndex;
            if(rowIdx < 0)
                return;
            
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
            var newGroupForm = new CreateGroupForm(new Groups(), false);
            newGroupForm.ShowDialog();
        }

    }
}
