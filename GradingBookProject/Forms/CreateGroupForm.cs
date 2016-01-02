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
    public partial class CreateGroupForm : Form
    {
        private GroupsViewModel currGroup;
        private bool edit;
        public CreateGroupForm(GroupsViewModel group, bool edit)
        {
            InitializeComponent();
            currGroup = group;
            this.edit = edit;
            usersDataView.UserDeletedRow += RemoveUser;

            if (edit)
            {
                tbTitle.Text = currGroup.name;
                tbDesc.Text = currGroup.description;

                //foreach (var groupDetail in currGroup.GroupDetails)
                //{
                //    usersBindingSource.Add(groupDetail.Users);
                //}
            }

        }

        private async void RemoveUser(object sender, DataGridViewRowEventArgs e)
        {
            HttpGroupDetailsRepository repo = new HttpGroupDetailsRepository();
            UsersViewModel user =  usersBindingSource[e.Row.Index] as UsersViewModel;
            await repo.RemoveDetail(user.id, currGroup.id);
        }

        private async void SaveChangesClick(object sender, EventArgs e)
        {
            IStringValidator validator = new Validator();
            if (!validator.IsNotEmpty(tbTitle.Text))
            {
                MessageBox.Show("Title can not be empty!");
                return;
            }
            HttpGroupDetailsRepository repo = new HttpGroupDetailsRepository();

            //ading users
            foreach (UsersViewModel user in usersBindingSource)
            {
                bool detailAlreadyExists = false;
                //foreach (var groupDetail in user.GroupDetails)
                //{
                //    if ((await repo.DetailExists(groupDetail))) //if given connection does not exist then add it
                //    {
                //        detailAlreadyExists = true;
                //        break;
                //    }
  
                //}
                if (!detailAlreadyExists)
                {
                    //await repo.AddOne(new GroupDetails()
                    //{
                    //    group_id = currGroup.id,
                    //    user_id = user.id
                    //});
                    currGroup.GroupDetails.Add(new GroupDetailsViewModel()
                    {
                        group_id = currGroup.id,
                        user_id = user.id
                    });
                }
            }
            HttpGroupsRepository groupRepo = new HttpGroupsRepository();

            currGroup.description = tbDesc.Text;
            currGroup.name = tbTitle.Text;

            if (edit)
            {
                //currGroup.Users = null;
                //await groupRepo.EditOne(currGroup);
                //this.Close();
            }
            else
            {
                //adding yourself to the group
                currGroup.GroupDetails.Add(new GroupDetailsViewModel()
                {
                    user_id = Globals.CurrentUser.id,
                    group_id = currGroup.id
                });
                //currGroup.Users = Globals.CurrentUser;
                var tmp = new GroupsViewModel()
                {
                    created_at = DateTime.Now,
                    GroupDetails = currGroup.GroupDetails,
                    name = currGroup.name,
                    owner_id = Globals.CurrentUser.id,
                    description = currGroup.description
                };
                //currGroup.created_at = DateTime.Now;

                await groupRepo.AddOne(tmp);
                this.Close();
            }

        }

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
            if (username == Globals.CurrentUser.username)
            {
                MessageBox.Show("You can not add yourself to group! (you are already in it)");
                return;
            }
            if (usersBindingSource.Cast<UsersViewModel>().Any(user => user.username == username))
            {
                MessageBox.Show("You have already added such a user!");
                return;
            }

            if (await repo.UserExists(username))
            {
                usersBindingSource.Add(await repo.GetUser(username));
            }
            else
            {
                MessageBox.Show("There is no such a user!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
