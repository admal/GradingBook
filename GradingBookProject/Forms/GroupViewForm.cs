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
using GradingBookProject.Http;
using GradingBookProject.ViewModels;


namespace GradingBookProject.Forms
{
    public partial class GroupViewForm : Form
    {
        private GroupsViewModel currGroup;
        private bool isAdmin;
        public GroupViewForm(GroupsViewModel group, bool isAdmin = false)
        {
            InitializeComponent();

            this.currGroup = group;
            this.isAdmin = isAdmin;

            lblTitle.Text = group.name;
            this.Name = group.name;
            tbDesc.Text = group.description;

            yearsGridView.CellDoubleClick += SeeYearDetails;

            FindUser();

            if (isAdmin)
            {
                btnAddYear.Enabled = true;
                btnLeave.Text = "Delete group";
            }
            UpdateYearsSource();
        }

        void SeeYearDetails(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0 && idx < yearsBindingSource.Count)
            {
                YearsViewModel year = yearsBindingSource[idx] as YearsViewModel;
                MessageBox.Show("Year: " + year.name);
                //show form
            }
        }

        public async void UpdateYearsSource()
        {
            await SyncGroup();
            yearsBindingSource.Clear();
            foreach (var year in currGroup.Years)
            {
                yearsBindingSource.Add(year);
            }
            yearsGridView.Update();
        }

        public async Task SyncGroup()
        {
            HttpGroupsRepository repo = new HttpGroupsRepository();

            currGroup = await repo.GetOne(currGroup.id);
        }
        private async void FindUser()
        {
            var usersRepo = new HttpUserRequestService();
            var owner = await usersRepo.GetOne(currGroup.owner_id);
            lblUsername.Text = owner.username;   
        }
        private void AddYearClick(object sender, EventArgs e)
        {
            var form = new YearForm(currGroup);
            form.ShowDialog();
            UpdateYearsSource();
        }

        private void BackClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void LeaveGroupClick(object sender, EventArgs e)
        {
            var question = isAdmin ? "delete" : "leave";

            var result = MessageBox.Show("Are you sure you want to "+question+" the group?", "Delete group",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            if (isAdmin)
            {
                await DeleteGroup();
            }
            else
            {
                await LeaveGroup();

            }
            await Globals.UpdateCurrentUser();
            Close();
        }

        private async Task DeleteGroup()
        {
            var repo = new HttpGroupsRepository();
            await repo.DeleteOne(currGroup);
        }

        private async Task LeaveGroup()
        {
            var currDetail = currGroup.GroupDetails.FirstOrDefault(d => d.user_id == Globals.CurrentUser.id);
            var repo = new HttpGroupDetailsRepository();
            await repo.DeleteOne(currDetail);
        }
    }
}
