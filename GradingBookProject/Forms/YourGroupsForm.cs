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
using GradingBookProject.ViewModels;


namespace GradingBookProject.Forms
{
    public partial class YourGroupsForm : Form
    {
        private UsersViewModel currUser;
        public YourGroupsForm()
        {
            InitializeComponent();
            currUser = Globals.CurrentUser;
            UpdateGridView();
            groupsGridView.CellContentClick += EditGroupClick;
        }

        public void UpdateGridView()
        {
            //foreach (var groupDetail in currUser)
            //{
            //    groupsBindingSource.Add(groupDetail.Groups);
            //}
        }


        private void EditGroupClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                GroupsViewModel group = groupsBindingSource[e.RowIndex] as GroupsViewModel;
                var createForm = new CreateGroupForm(group, true);
                createForm.ShowDialog();
            }
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
            var createForm = new CreateGroupForm(new GroupsViewModel(), false);
            createForm.ShowDialog();
        }

    }
}
