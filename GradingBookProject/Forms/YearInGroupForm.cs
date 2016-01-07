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
    /// <summary>
    /// Form displaying a year of a group. Displays two lists, one users and second subjects.
    /// </summary>
    public partial class YearInGroupForm : Form
    {
        /// <summary>
        /// Id of a group the year belongs to.
        /// </summary>
        private int groupId;
        /// <summary>
        /// Id of a selected year.
        /// </summary>
        private int yearId;
        private HttpUsersRepository users;
        private HttpYearsRepository years;
        private HttpSubjectsRepository subjects;
        private HttpGroupDetailsRepository groupDetails;
        /// <summary>
        /// Determines wether the form is displayed by an admin.
        /// </summary>
        private bool isAdmin;

        /// <summary>
        /// Constructor for YearInGroup form. Assings repositories, disables buttons for non admin users.
        /// </summary>
        /// <param name="_groupId">Id of a group the year belongs to.</param>
        /// <param name="_yearId">Id of a selected year.</param>
        /// <param name="_isAdmin">Determines wether the form is displayed by an admin.</param>
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
        /// <summary>
        /// Opens a form for editing the clicked subject.
        /// </summary>
        /// <param name="sender">Subjects grid view.</param>
        /// <param name="e"></param>
        private void editSubject(object sender, DataGridViewCellEventArgs e)
        {
            if (isAdmin)
            {
                int idx = e.RowIndex;
                if (idx >= 0 && idx < subjectsBindingSource.Count)
                {

                    SubjectsViewModel subject = subjectsBindingSource[idx] as SubjectsViewModel;

                    var form = new SubjectForm(subject);
                    form.FormClosed += new FormClosedEventHandler(this.Form_Close);
                    form.ShowDialog();

                }
            }
        }
        /// <summary>
        /// Opens a form to display requested user.
        /// </summary>
        /// <param name="sender">Users grid view.</param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Opens a form for adding a subject.
        /// </summary>
        /// <param name="sender">Button for adding a subject</param>
        /// <param name="e"></param>
        private void AddSubject(object sender, EventArgs e)
        {
            var subjectForm = Program.GetKernel().Get<SubjectForm>(new ConstructorArgument("yearid", yearId));
            subjectForm.FormClosed += new FormClosedEventHandler(this.Form_Close);
            subjectForm.ShowDialog();

        }
        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender">Exit icon.</param>
        /// <param name="e"></param>
        private void Form_Close(object sender, FormClosedEventArgs e)
        {
            UpdateTables();
        }
        /// <summary>
        /// Updates both Users and Subjects tables.
        /// </summary>
        private async void UpdateTables() {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                await PopulateUserstable();
                await PopulateSubjectsTable();
            }
            finally {
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// Populates users table with data.
        /// </summary>
        private async Task PopulateUserstable(){


            var usersList = await users.GetUsersOfGroup(groupId);
           // var gds = await groupDetails.GetGroupDetailsForGroup(groupId);

            usersBindingSource.Clear();
            foreach (var user in usersList)
            {
                //var user = await users.GetOne(gd.user_id);

                usersBindingSource.Add(user);
            }
            usersGridView.Update();
        }
        /// <summary>
        /// Populates subjects table with data.
        /// </summary>
        private async Task PopulateSubjectsTable() {
     
            subjectsBindingSource.Clear();

            var subjectsList = await subjects.GetSubjects(await years.GetOne(yearId));

            foreach (var sub in subjectsList) {
                subjectsBindingSource.Add(sub);
            }
            subjectsGridView.Update();
        }
        /// <summary>
        /// Opens a form for editing the clicked year.
        /// </summary>
        /// <param name="sender">Button for editing a year.</param>
        /// <param name="e"></param>
        private async void  EditYearClick(object sender, EventArgs e)
        {
            var currYear = await years.GetOne(yearId);
            var form = new YearForm(currYear);
            form.ShowDialog();
            await Globals.UpdateCurrentUser();
        }
        /// <summary>
        /// Deletes Currently displayed year.
        /// </summary>
        /// <param name="sender">Button for deleting a year.</param>
        /// <param name="e"></param>
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
