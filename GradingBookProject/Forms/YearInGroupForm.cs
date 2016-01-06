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

            usersGridView.CellDoubleClick += seeUser;
            subjectsGridView.CellDoubleClick += editSubject;

            UpdateTables();

            btnAddSubject.Click += AddSubject;
            if (!isAdmin)
            {
                btnAddSubject.Visible = false;
                btnDeleteYear.Visible = false;
                btnEditYear.Visible = false;
            }
        }

        private void editSubject(object sender, DataGridViewCellEventArgs e)
        {
            if (isAdmin)
            {
                int idx = e.RowIndex;
                if (idx >= 0 && idx < subjectsBindingSource.Count)
                {

                    SubjectsViewModel subject = subjectsBindingSource[idx] as SubjectsViewModel;

                    if (subject.id != null)
                    {
                        var form = new SubjectForm(subject);
                        form.FormClosed += new FormClosedEventHandler(this.Form_Close);
                        form.ShowDialog();
                    }

                }
            }
        }

        private void seeUser(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0 && idx < usersBindingSource.Count)
            {

                UsersViewModel user = usersBindingSource[idx] as UsersViewModel;

                var form = new MainForm(user.username, groupId);
                form.ShowDialog();
                
                
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
         
            var gds = await groupDetails.GetGroupDetailsForGroup(groupId);

            usersBindingSource.Clear();
            foreach (var gd in gds)
            {
                var user = await users.GetOne(gd.user_id);

                usersBindingSource.Add(user);
            }
            usersGridView.Update();
        }

        private async void PopulateSubjectsTable() {
     
            subjectsBindingSource.Clear();

            var subjectsList = await subjects.GetSubjects(await years.GetOne(yearId));

            foreach (var sub in subjectsList) {

                subjectsBindingSource.Add(sub);
            }
            subjectsGridView.Update();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void  EditYearClick(object sender, EventArgs e)
        {
            var currYear = await years.GetOne(yearId);
            var form = new YearForm(currYear);
            form.ShowDialog();
            await Globals.UpdateCurrentUser();
        }

        private async void DeleteYearClick(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Are you sure you want to delete this year?","Delete year",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            await years.DeleteOne(await years.GetOne(yearId));
            this.Close();
            await Globals.UpdateCurrentUser();
        }
    }
}
