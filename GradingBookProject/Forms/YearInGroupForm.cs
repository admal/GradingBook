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

        /// <summary>
        /// Form for Displaying a Year of a group
        /// </summary>
        /// <param name="_groupId">Id of a group, we diplay the Year of.</param>
        /// <param name="_yearId">Id of a Year being displayed</param>
        /// <param name="_isAdmin">Determines wether accessed as an Admin.</param>
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
            }
        }

        /// <summary>
        /// Event for editing a subject.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Contains a row information.</param>
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
        /// Event displaying the Main form for viewing a clicked user.
        /// </summary>
        /// <param name="sender"></param>
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
        /// Event For adding a subject to the displayed Year.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSubject(object sender, EventArgs e)
        {
            var subjectForm = Program.GetKernel().Get<SubjectForm>(new ConstructorArgument("yearid", yearId));
            subjectForm.FormClosed += new FormClosedEventHandler(this.Form_Close);
            subjectForm.ShowDialog();

        }
        /// <summary>
        /// Event for Closing a form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Close(object sender, FormClosedEventArgs e)
        {
            UpdateTables();
        }

        /// <summary>
        /// Updating both tables (subjects, users).
        /// </summary>
        private void UpdateTables() {
             PopulateUserstable();
             PopulateSubjectsTable();        
        }
        /// <summary>
        /// Populates a Users table.
        /// </summary>
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
        /// <summary>
        /// Populates a Subjects table.
        /// </summary>
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
    }
}
