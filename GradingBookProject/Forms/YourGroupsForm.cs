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
            groupsGridView.CellDoubleClick += SeeGroupDetailsClick;
        }

        public async void UpdateGridView()
        {
            currUser = Globals.CurrentUser;
            var repo = new HttpGroupsRepository();
            groupsBindingSource.Clear();
            foreach (var groupDetail in currUser.GroupDetails)
            {
                var group = await repo.GetOne(groupDetail.group_id);
                groupsBindingSource.Add(group);
            }
            groupsGridView.Update();
        }


        private void EditGroupClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                GroupsViewModel group = groupsBindingSource[e.RowIndex] as GroupsViewModel;
                if (group.owner_id != Globals.CurrentUser.id)
                {
                    MessageBox.Show("Error: You are not the admin of this group!","Not enough priviliges",MessageBoxButtons.OK);
                    return;
                }

                var createForm = new CreateGroupForm(group, true);
                createForm.ShowDialog();
                UpdateGridView();
            }
        }

        void SeeGroupDetailsClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0 && idx < groupsBindingSource.Count)
            {
                GroupsViewModel currGroup = groupsBindingSource[idx] as GroupsViewModel;
                if (currGroup != null)
                {
                    var isAdmin = (currGroup.owner_id == Globals.CurrentUser.id);

                    var form = new GroupViewForm(currGroup, isAdmin);
                    form.Show();
                }
            }
        }

        private void BackClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewGroupClick(object sender, EventArgs e)
        {
            var createForm = new CreateGroupForm(new GroupsViewModel(), false);
            createForm.ShowDialog();

            UpdateGridView();
        }

    }
}
