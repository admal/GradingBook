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

using GradingBookProject.Validation;
using GradingBookProject.ViewModels;

namespace GradingBookProject.Forms
{
    /// <summary>
    /// Form to create new group, it allows to put name and description of the group and add members to it.
    /// Form also allows us to edit already existing group.
    /// </summary>
    public partial class CreateGroupForm : Form
    {
        /// <summary>
        /// New group or currently loaded to edit
        /// </summary>
        private GroupsViewModel currGroup;
        /// <summary>
        /// Indicates if user edits group or creates new one
        /// </summary>
        private bool edit;
        /// <summary>
        /// Constructor
        /// If the group is edited it fills text boxes and lists with proper data.
        /// </summary>
        /// <param name="group">loaded group </param>
        /// <param name="edit">indicates if we edit a group or user creates new one</param>
        public CreateGroupForm(GroupsViewModel group, bool edit)
        {
            InitializeComponent();
            currGroup = group;
            this.edit = edit;
            //usersDataView.UserDeletedRow += RemoveUser;
            if (edit)
            {
                tbTitle.Text = currGroup.name;
                tbDesc.Text = currGroup.description;
                UpdateSource();
            }
            else
            {
                usersBindingSource.Add(Globals.CurrentUser);
            }
            //usersDataView.CellDoubleClick += SeeUsersProfile;
        }

        private void SeeUsersProfile(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            

            if (index >= 0 && index < usersBindingSource.Count) {
               UsersViewModel user =  usersBindingSource[index] as UsersViewModel;
               if (user != null) {
                   var form = new MainForm(user.username, currGroup.id);
                   form.ShowDialog();
               }
            }
        }
        /// <summary>
        /// Updates binding source.
        /// </summary>
        public async void UpdateSource()
        {
            var repo = new HttpUsersRepository();

            foreach (var groupDetail in currGroup.GroupDetails)
            {
                var user = await repo.GetOne(groupDetail.user_id);
                usersBindingSource.Add(user);
            }
            
        }

        //private async void RemoveUser(object sender, DataGridViewRowEventArgs e)
        //{
        //    HttpGroupDetailsRepository repo = new HttpGroupDetailsRepository();
        //    int currId = usersDataView.CurrentRow.Index;
        //    MessageBox.Show("Row: " + currId);
        //    //UsersViewModel user = usersBindingSource[currId] as UsersViewModel;
        //    //await repo.RemoveDetail(user.id, currGroup.id);
        //}
        /// <summary>
        /// Saves and validates provided data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SaveChangesClick(object sender, EventArgs e)
        {
            IStringValidator validator = new Validator();
            if (!validator.IsNotEmpty(tbTitle.Text))
            {
                MessageBox.Show("Title can not be empty!");
                return;
            }

            HttpGroupsRepository groupRepo = new HttpGroupsRepository();

            currGroup.description = tbDesc.Text;
            currGroup.name = tbTitle.Text;

            if (edit)
            {
                await UpdateUsers();
                await groupRepo.EditOne(currGroup);

                await Globals.UpdateCurrentUser();
                this.Close();
            }
            else
            {
                var detailRepo = new HttpGroupDetailsRepository();

                var newGroup = new GroupsViewModel()
                {
                    created_at = DateTime.Now,
                    GroupDetails = currGroup.GroupDetails,
                    name = currGroup.name,
                    owner_id = Globals.CurrentUser.id,
                    description = currGroup.description
                };

                GroupsViewModel retGroup = await groupRepo.AddOne(newGroup); //we need it to get created id
                
                currGroup.id = retGroup.id; 
                //adding users
                await UpdateUsers();

                await Globals.UpdateCurrentUser();

                this.Close();
            }

        }
        /// <summary>
        /// Updates added members added to the database.
        /// </summary>
        /// <returns></returns>
        private async Task UpdateUsers()
        {
            HttpGroupDetailsRepository repo = new HttpGroupDetailsRepository();
            ICollection<GroupDetailsViewModel> listOfDetails = new List<GroupDetailsViewModel>();
            var users = usersBindingSource.List.Cast<UsersViewModel>();
            
            //checking if creator is added to the group
            if (users.Count(u => u.id == currGroup.id) == 0) //if not add him and proper communicate
            {
                usersBindingSource.Add(Globals.CurrentUser);
                MessageBox.Show("You removed yourself from the group, you were added to it automatically!","Warning",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            //adding new users
            foreach (UsersViewModel user in usersBindingSource)
            {
                var newDetail = new GroupDetailsViewModel()
                {
                    user_id = user.id,
                    group_id = currGroup.id
                };
                listOfDetails.Add(newDetail);
                if (!(await repo.DetailExists(newDetail))) //if given connection does not exist then add it
                {
                    var detailRepo = new HttpGroupDetailsRepository();
                    await detailRepo.AddOne(newDetail);
                   // currGroup.GroupDetails.Add(newDetail); //synchronize current group with db
                }
            }
            HttpGroupsRepository groupsRepo = new HttpGroupsRepository();
            var actualGroup = await groupsRepo.GetOne(currGroup.id); //actual group to synchronize from db
            foreach (var detail in actualGroup.GroupDetails)
            {
                if (listOfDetails.Count(d => d.group_id == detail.group_id && d.user_id == detail.user_id) == 0) //if currGroup does not contain any of detail then delete it from db
                {
                    await repo.DeleteOne(detail);
                }
            }
        }
        /// <summary>
        /// Adds user to binding source and also validates the added user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddUserClick(object sender, EventArgs e)
        {
            HttpUsersRepository repo = new HttpUsersRepository();
            IStringValidator validator = new Validator();
            string username = tbUser.Text;
            if (!validator.IsNotEmpty(username))
            {
                MessageBox.Show("Provide username!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if (username == Globals.CurrentUser.username)
            //{
            //    MessageBox.Show("You can not add yourself to group! (you are already in it)");
            //    return;
            //}
            if (usersBindingSource.Cast<UsersViewModel>().Any(user => user.username == username))
            {
                MessageBox.Show("You have already added such a user!");
                return;
            }

            if (await repo.UserExists(username))
            {
                var user = await repo.GetUser(username);
                usersBindingSource.Add(user);
            }
            else
            {
                MessageBox.Show("There is no such a user!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Leaves the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
