using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GradingBookProject.ViewModels;
using GradingBookProject.Data;
using GradingBookProject.Http;
using Ninject;
using Ninject.Parameters;

namespace GradingBookProject.Forms
{
    public partial class YearInGroupForm : Form
    {
        private int groupId;
        private int yearId;
        private HttpUsersRepository users;
        private HttpYearsRepository years;
        private HttpSubjectsRepository subjects;
        private HttpGroupDetailsRepository groupDetails;
        private bool isAdmin;

        public YearInGroupForm(int _groupId, int _yearId, bool _isAdmin)
        {
            InitializeComponent();  
            
            groupId = _groupId;
            yearId = _yearId;
            isAdmin = _isAdmin;

            users = new HttpUsersRepository();
            years = new HttpYearsRepository();
            subjects = new HttpSubjectsRepository();
            groupDetails = new HttpGroupDetailsRepository();

            UpdateTables();

            btnAddSubject.Click += AddSubject;
            if (!isAdmin)
            {
                btnAddSubject.Visible = false;
            }
        }

        private void AddSubject(object sender, EventArgs e)
        {
            var subjectForm = Program.GetKernel().Get<SubjectForm>(new ConstructorArgument("yearid", yearId));
            subjectForm.FormClosed += new FormClosedEventHandler(this.Form_Close);
            subjectForm.ShowDialog();

        }

        private void Form_Close(object sender, FormClosedEventArgs e)
        {
            UpdateTables();
        }

        private void UpdateTables() {
             PopulateUserstable();
             PopulateSubjectsTable();        
        }
        private async void PopulateUserstable(){
            usersGridView.Controls.Clear();
            //tableUsers.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            var gds = await groupDetails.GetGroupDetailsForGroup(groupId);

            foreach (var gd in gds)
            {
                var user = await users.GetOne(gd.user_id);
                var tempControl = new LinkLabel() { Text = user.name + " \"" + user.username + "\" " + user.surname};
                tempControl.Tag = user.username;
                tempControl.Anchor = AnchorStyles.Left;

                tempControl.LinkClicked += seeUsersProfile;

                //usersGridView.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
                usersGridView.Controls.Add(tempControl);
                
            }
        }

        private void seeUsersProfile(object sender, EventArgs e)
        {
            var control = (Control)sender;
            var username = (string)control.Tag;
            if (username != null)
            {
                var form = new MainForm(username);
                form.ShowDialog();
            }
        }

        private async void PopulateSubjectsTable() {
            subjectsGridView.Controls.Clear();
           // tableUsers.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            var subjectsList = await subjects.GetSubjects(await years.GetOne(yearId));

            foreach (var sub in subjectsList) {
                var tempControl = new LinkLabel() { Text = sub.name };
                tempControl.Tag = sub.id;
                tempControl.Anchor = AnchorStyles.Left;
                tempControl.LinkColor = Color.Black;
                if (isAdmin)
                {
                    tempControl.LinkColor = Color.Blue;
                    
                    tempControl.LinkClicked += EditSubject;
                }
                //subjectsGridView.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
                subjectsGridView.Controls.Add(tempControl);
            }
        }

        private async void EditSubject(object sender, EventArgs e)
        {
            var control = (Control)sender;
            var subjectId = (int)control.Tag;
            if (subjectId != null) { 
                var subject = await subjects.GetOne(subjectId);
                var form = new SubjectForm(subject);
                form.FormClosed += new FormClosedEventHandler(this.Form_Close);
                form.ShowDialog();
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
