﻿using System;
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
            FindUser();

            if (isAdmin)
            {
                btnAddYear.Enabled = true;
                btnLeave.Text = "Delete group";
            }
            UpdateYearsSource();
        }

        public async void UpdateYearsSource()
        {
            await SyncGroup();
            yearsBindingSource.Clear();
            foreach (var year in currGroup.Years)
            {
                yearsBindingSource.Add(year);
            }
            yersGridView.Update();
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

        }
    }
}
