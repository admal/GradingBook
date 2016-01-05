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
        /// <summary>
        /// Currently loaded group
        /// </summary>
        private GroupsViewModel currGroup;
        /// <summary>
        /// Indicates if currently logged user is the administartor of the loaded group.
        /// </summary>
        private bool isAdmin;
        /// <summary>
        /// Constructor fills text boxes, labels and lists wit the proper data.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="isAdmin"></param>
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
        /// <summary>
        /// Opens form with subjects and users of the group for clicked year.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SeeYearDetails(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0 && idx < yearsBindingSource.Count)
            {
                YearsViewModel year = yearsBindingSource[idx] as YearsViewModel;
                //show form
                var form = new YearInGroupForm((int)year.group_id, year.id, isAdmin);
                form.ShowDialog();
            }
        }
        /// <summary>
        /// Updates binding source.
        /// </summary>
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
        /// <summary>
        /// Synchronizes current group with actual group from database.
        /// </summary>
        /// <returns></returns>
        public async Task SyncGroup()
        {
            HttpGroupsRepository repo = new HttpGroupsRepository();

            currGroup = await repo.GetOne(currGroup.id);
        }
        /// <summary>
        /// Finds owner of the group and puts data to proper text boxes.
        /// </summary>
        private async void FindUser()
        {
            var usersRepo = new HttpUserRequestService();
            var owner = await usersRepo.GetOne(currGroup.owner_id);
            lblUsername.Text = owner.username;   
        }
        /// <summary>
        /// Opens form to create a new year.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddYearClick(object sender, EventArgs e)
        {
            var form = new YearForm(currGroup);
            form.ShowDialog();
            UpdateYearsSource();
        }
        /// <summary>
        /// Goes back to previous form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackClick(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Handles click of the leave/delete group button.
        /// If the user is the administartor he can delete it.
        /// Otherwise user can leave it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Deletes current group.
        /// </summary>
        /// <returns></returns>
        private async Task DeleteGroup()
        {
            var repo = new HttpGroupsRepository();
            await repo.DeleteOne(currGroup);
        }
        /// <summary>
        /// Current user leaves the group.
        /// </summary>
        /// <returns></returns>
        private async Task LeaveGroup()
        {
            var currDetail = currGroup.GroupDetails.FirstOrDefault(d => d.user_id == Globals.CurrentUser.id);
            var repo = new HttpGroupDetailsRepository();
            await repo.DeleteOne(currDetail);
        }
    }
}
