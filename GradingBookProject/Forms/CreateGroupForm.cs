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
using GradingBookProject.Validation;

namespace GradingBookProject.Forms
{
    public partial class CreateGroupForm : Form
    {
        private Groups currGroup;
        private bool edit = false;

        public CreateGroupForm(Groups group, bool edit)
        {
            InitializeComponent();

            currGroup = group;
            this.edit = edit;

            if (edit)
            {
                tbTitle.Text = group.name;
                tbDesc.Text = group.description;
                foreach (var groupDetail in group.GroupDetails)
                {
                    if (groupDetail.Users == null)
                        groupDetail.Users = Globals.CurrentUser;

                    usersBindingSource.Add(groupDetail.Users);
                }
            }
        }

        private async void SaveChangesClick(object sender, EventArgs e)
        {
            HttpGroupsRepository repo = new HttpGroupsRepository();
            //validate data
            IStringValidator validator = new Validator();
            if (!validator.IsNotEmpty(tbTitle.Text))
            {
                MessageBox.Show("Provide name of the group!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (usersBindingSource.Count == 0)
            {
                MessageBox.Show("Provide some users to the group!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;                   
            }
            currGroup.created_at = DateTime.Now;
            currGroup.description = tbDesc.Text;
            currGroup.name = tbTitle.Text;
            currGroup.owner_id = Globals.CurrentUser.id;
            currGroup.Users = null;
            

            foreach (Users user in usersBindingSource)
            {
                currGroup.GroupDetails.Add(new GroupDetails()
                {
                    // Groups = currGroup,
                    group_id = currGroup.id,
                    user_id = user.id,
                    //Users = user
                });
            }
            currGroup.GroupDetails.Add(new GroupDetails()
            {
                group_id = currGroup.id,
                user_id = Globals.CurrentUser.id
            });

            if (edit)
            {
                try
                {
                    await repo.EditGroup(currGroup);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unknown error occured!: " + ex.Message);
                    return;
                }
               
            }
            else
            {
                try
                {
                    await repo.AddGroup(currGroup);
                    MessageBox.Show("Was saved succesfully!","Success!",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    var parent = Parent as YourGroupsForm;
                    parent.UpdateGridView();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unknown error occured!: " + ex.Message);
                    return;
                }

            }
        }

        private async void AddUserClick(object sender, EventArgs e)
        {
            HttpUsersRepository repo = new HttpUsersRepository();
            IStringValidator validator = new Validator();
            string username = tbUser.Text;
            if (!validator.IsNotEmpty(username))
            {
                MessageBox.Show("Provide username!","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (username == Globals.CurrentUser.username)
            {
                MessageBox.Show("You can not add yourself to group! (you are already in it)");
                return;
            }
            if (usersBindingSource.Cast<Users>().Any(user => user.username == username))
            {
                MessageBox.Show("You have already added such a user!");
                return;
            }

            if (await repo.userExists(username))
            {
                usersBindingSource.Add(await repo.GetUser(username));
            }
            else
            {
                MessageBox.Show("There is no such a user!","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

    }
}
