using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using Ninject;
using GradingBookProject.Data;
using GradingBookProject.Models;
using Ninject.Parameters;
using GradingBookProject.ViewModels;

namespace GradingBookProject.Forms
{
    /// <summary>
    /// Main form displaying all Years, Subjects and Grades for a logged in User.
    /// </summary>
    public partial class MainForm : Form
    {
        private YearsViewModel selectedYear = new YearsViewModel();
        private YearListItem selectedYearListItem;
        private string username;
        private HttpYearsRepository years;
        private HttpSubjectsRepository subjects;
        private HttpSubjectDetailsRepository grades;
        private HttpUsersRepository users;
        private HttpGroupsRepository groups;
        private HttpGroupDetailsRepository groupDetails;
        private int visitorGroupId;

        private bool visiting;

        private bool toCloseApp = false;

        /*-------------------------CONSTRUCTORS----------------------*/
        /// <summary>
        /// Initializes the form updates repositories and list of years.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Get id of current user.
            username = Globals.CurrentUser.username;
            visiting = false;

            // Initialize repositories.
            UpdateRepositories();
            
            //populate the list of Years
            UpdateYearList();
        }

        /// <summary>
        /// Initializes the form updates repositories and list of years.
        /// </summary>
        /// <param name="visitingUsername">Determines the user other than logged in to be viewed</param>
        /// <param name="_visitorGroupId">Determines the group id of a visitor</param>
        public MainForm(string visitingUsername, int _visitorGroupId) {
            InitializeComponent();

            username = visitingUsername;
            visiting = true;
            visitorGroupId = _visitorGroupId;

            menuStrip1.Visible = false;

            UpdateRepositories();

            UpdateYearList();
        }
        /*-----------------------------UPDATING FUNCTIONS-----------------------------*/
        /// <summary>
        /// Updates repositories.
        /// </summary>
        private  void UpdateRepositories() {
            years = new HttpYearsRepository();
            subjects = new HttpSubjectsRepository();
            grades = new HttpSubjectDetailsRepository();
            users = new HttpUsersRepository();
            groups = new HttpGroupsRepository();
            groupDetails = new HttpGroupDetailsRepository();
        }
        /// <summary>
        /// Updates Main Form.
        /// </summary>
        private void UpdateMainForm() {
            UpdateRepositories();
            UpdateYearList();
            UpdateTable();
        }

        /// <summary>
        /// Updates list of years. And Enables/Disables buttons
        /// </summary>
        private async void UpdateYearList(){
            listYear.Items.Clear();
            listYear.Sorted = false;
            //get list of years for user
            var yearsList = await years.GetYears(username);

            //Get groups from groupDetails using a username
            var tempUser = await users.GetUser(username);
            var groupDetailsList = await groupDetails.GetGroupDetailsForUser(tempUser.id);

            if ((yearsList != null && yearsList.Count != 0) || (groupDetailsList != null && groupDetailsList.Count != 0))
            {
                //If it is not a visitor display all years from usr and groups otherwise otherwise display only years form a group it is being visited from
                if (!visiting)
                {
                    listYear.Items.Add(new YearListItem("Users Years"));
                    // populate with current user years
                    foreach (var year in yearsList)
                    {
                        YearListItem item = new YearListItem(year.name, year.id);
                        listYear.Items.Add(item);
                    }
                    List<GroupsViewModel> userGroups = new List<GroupsViewModel>();
                    foreach (var groupDetail in groupDetailsList)
                    {
                        userGroups.Add(await groups.GetOne(groupDetail.group_id));
                    }

                    foreach (var group in userGroups)
                    {
                        var groupYears = await years.GetYearsOfGroup(group.id);
                        if (groupYears != null && groupYears.Count != 0)
                        {
                            //adding a separator with a name of the group
                            listYear.Items.Add(new YearListItem(group.name));
                            //listYear.Items.Add();
                            foreach (var year in groupYears)
                            {
                                YearListItem item;
                                if (group.owner_id == tempUser.id)
                                    item = new YearListItem(year.name, year.id, true, true);
                                else
                                    item = new YearListItem(year.name, year.id, true, false);

                                listYear.Items.Add(item);
                            }

                        }
                    }
                } //else: for displaying only years from common group
                else {
                    var groupYears = await years.GetYearsOfGroup(visitorGroupId);
                    foreach (var year in groupYears)
                    {
                        listYear.Items.Add(new YearListItem(year.name, year.id, true, false));
                    }
                }

                //Check if the form is being visited
                if (visiting)
                {
                    btnAddSubject.Enabled = false;
                    btnDeleteYear.Enabled = false;
                    btnEditYear.Enabled = false;
                    btnAddYear.Enabled = false;
                }
                else
                {
                    //check If a year is displayed by an Owner
                    if (selectedYearListItem != null)
                    {
                        if (selectedYearListItem.Owned)
                        {
                            btnAddSubject.Enabled = true;
                            btnDeleteYear.Enabled = true;
                            btnEditYear.Enabled = true;
                        }
                        else
                        {
                            btnAddSubject.Enabled = false;
                            btnDeleteYear.Enabled = false;
                            btnEditYear.Enabled = false;
                        }
                    }
                }

               if (selectedYearListItem != null)
                {
                    
                    listYear.SelectedIndex = listYear.Items.IndexOf(selectedYearListItem);
                }
                else
                {
                    listYear.SelectedIndex = 0;
                }
            }
            else
            {
                btnAddSubject.Enabled = false;
                btnDeleteYear.Enabled = false;
                btnEditYear.Enabled = false;
                if (visiting) {
                    btnAddYear.Enabled = false;
                }
            }
        }
        /*-----------------------------POPULATING FUNCTIONS-----------------------------*/
        /// <summary>
        /// set Year for which the subjects and grades are supposeed to be displayed
        /// </summary>
        /// <param name="sender">Chosen ComboBox element</param>
        /// <param name="e"></param>
        private async void listYearSelected(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            var selectedIndex = (int)cmb.SelectedIndex;
            var item= (YearListItem)cmb.SelectedItem;
            
            if (item.Clickable)
            {
                selectedYear = await years.GetOne(item.Id);
                selectedYearListItem = new YearListItem(item.ToString(), item.Id, item.Clickable, item.Owned);
                UpdateMainForm();
            }
            
        }

        /// <summary>
        /// updates the table of subjects and grades according to the chosen year
        /// </summary>
        private async void UpdateTable()
        {
            //clear table
            ClearTableMarks();
            tableMarks.AutoSize = true;
            var yearsList = await years.GetYears(username);
            if (selectedYear != null)
            {
                var subjectsList = await subjects.GetSubjects(selectedYear);
                //populate the Marks table with db records check if there are subjects on chosen year
                if ((yearsList != null && yearsList.Count() != 0 ) || subjectsList != null)
                {

                    if (subjectsList != null)
                    {
                        //var row = 0;
                        //var percentHeight = 100/subjectsEnumerated.Count();
                        foreach (var subject in subjectsList)
                        {
                            tableMarks.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                            LinkLabel temp;

                            temp = new LinkLabel()
                            {
                                Text = subject.name,
                                Anchor = AnchorStyles.Left,
                                AutoSize = true,//false
                                ActiveLinkColor = Color.Black,
                                LinkBehavior = LinkBehavior.NeverUnderline,
                                Tag = subject.id
                            };
                            if (visiting || !selectedYearListItem.Owned)
                            {
                                temp.Enabled = false;
                            }

                            tableMarks.Controls.Add(temp);
                            temp.Click += new System.EventHandler(this.Subject_Click);

                            CreateGradesLabels(subject);

                            //Get grades of a user to calculate the average
                            var gradesList = await grades.GetSubjectDetails(subject);
                            List<SubjectDetailsViewModel> gradesOfUser = new List<SubjectDetailsViewModel>();
                            var currUser = await users.GetUser(username);
                            foreach (var grade in gradesList)
                            {
                                if (grade.user_id == currUser.id)
                                    gradesOfUser.Add(grade);
                            }

                            var avg = CalculateAverage(gradesOfUser.ToArray());

                            tableMarks.Controls.Add(new Label()
                                {
                                    Text = avg.ToString(),
                                    Anchor = AnchorStyles.Left,
                                    AutoSize = true,
                                });
                            var btn = new Button()
                                {
                                    Text = "Add",
                                    Anchor = AnchorStyles.Left,
                                    AutoSize = true,
                                    Tag = subject.id,
                                };

                            if (visiting)
                            {
                                btn.Enabled = false;
                            }

                            btn.Click += AddGradeClick;
                            tableMarks.Controls.Add(btn);
                            tableMarks.RowCount++;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Calculates the weighted average from marks of a given subject.
        /// </summary>
        /// <param name="data">Array of grades.</param>
        /// <returns>WeightAverage from marks.</returns>
        private double CalculateAverage(SubjectDetailsViewModel[] data)
        {

            if (data.Length != 0)
            {
                double sumTop = 0;
                double sumBot = 0;
                foreach (var grade in data)
                {
                    sumTop = sumTop + (grade.grade_value * grade.grade_weight);
                    sumBot = sumBot + (grade.grade_weight);
                }

                return Math.Round((sumTop / sumBot), 2);
            }

            return 0;
        }

        private async void AddGradeClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var subId = (int) btn.Tag;
            var sub = await subjects.GetOne(subId);
           
            AddGradeToSubject(sub);
        }
        /// <summary>
        /// Clears the Table and sets titles for columns.
        /// </summary>
        private void ClearTableMarks()
        {
            tableMarks.Controls.Clear();
            this.tableMarks.ColumnCount = 4;
            this.tableMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent,20));
            this.tableMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 50));
            this.tableMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 10));
            this.tableMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 20));

            tableMarks.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.AutoSize));
            tableMarks.RowCount++;
            tableMarks.Controls.Add(new Label() { Text = "Subject", Anchor = AnchorStyles.Left}, 0, 0);
            tableMarks.Controls.Add(new Label() { Text = "Grades", Anchor = AnchorStyles.None }, 1, 0);
            tableMarks.Controls.Add(new Label() { Text = "Average", Anchor = AnchorStyles.Left }, 2, 0);
            tableMarks.Controls.Add(new Label() { Text = "" }, 3, 0);
        }


        /*----------------------------- MENU STRIP ---------------------------*/
        /// <summary>
        /// Displays current version of a program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            MessageBox.Show("Current version: B1.3");
        }


        /// <summary>
        /// General method to update the form on changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Close(object sender, EventArgs e)
        {
            UpdateMainForm();
        }

        /*----------------------------- CRUDs Year---------------------------*/
        /// <summary>
        /// Opens a Form for adding a Year.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddYear_Click(object sender, EventArgs e)
        {
            var yearForm = Program.GetKernel().Get<YearForm>();
            yearForm.FormClosed += new FormClosedEventHandler(this.Form_Close);
            yearForm.ShowDialog();
        }


        /// <summary>
        /// Deletes a currently selected Year.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDeleteYear_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the currently selected year?", "Delete a Year", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                await years.DeleteOne(selectedYear);
                
                selectedYearListItem = null;
                UpdateMainForm();
                //exception after removing a year we move to next existing

            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }
        /// <summary>
        /// Opens a Form for Editing a Year (Injects itself into the form).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditYear_Click(object sender, EventArgs e)
        {
            var yearForm = Program.GetKernel().Get<YearForm>(new ConstructorArgument("year", selectedYear));
            yearForm.FormClosed += new FormClosedEventHandler(Form_Close);
            yearForm.ShowDialog();
            selectedYearListItem.Name(selectedYear.name);
        }

        /*----------------------------- CRUDs Subject---------------------------*/
        /// <summary>
        /// Opens a Form for adding a Subject.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            var subjectForm = Program.GetKernel().Get<SubjectForm>(new ConstructorArgument("yearid", selectedYear.id));
            subjectForm.FormClosed += new FormClosedEventHandler(this.Form_Close);
            subjectForm.ShowDialog();
        }            
        /// <summary>
        /// Opens a form for editing a Subject.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Subject_Click(object sender, EventArgs e) 
        {
            LinkLabel link = (LinkLabel)sender;
            int subjectid = (int)link.Tag;
            var subject = await subjects.GetOne(subjectid);
            var subjectForm = Program.GetKernel().Get<SubjectForm>(new ConstructorArgument("subject", subject));
            subjectForm.FormClosed += new FormClosedEventHandler(this.Form_Close);
            subjectForm.ShowDialog();
        }

        private void SettingsClick(object sender, EventArgs e)
        {
            var settingsForm =
            Program.GetKernel().Get<SettingsForm>(new ConstructorArgument("user", Globals.CurrentUser));
            settingsForm.ShowDialog();
        }
        private void SeeGroupsMenuClick(object sender, EventArgs e)
        {
            var groupForm = new YourGroupsForm();
            groupForm.FormClosed += new FormClosedEventHandler(this.Form_Close);
            groupForm.Show();
        }

        /*
         * ===============================================
         * Grades Author: Adam
         * ===============================================
         */


        /// <summary>
        /// Creates link labels with grade values.
        /// </summary>
        /// <param name="sub">Subject with grades to show</param>
        private async void CreateGradesLabels(SubjectsViewModel sub)
        {
            var panel = new FlowLayoutPanel(); //panel with grades
            panel.Name = "panel" + sub.id; //set name of the panel to: "panel+subId"
            panel.AutoSize = true;
            tableMarks.Controls.Add(panel); //add panel to tableMarks in proper position
            //this.Controls.Add(panel);
            if (sub.SubjectDetails == null)
            {
                return;
            }
            var user =await users.GetUser(username);
            foreach (var grade in sub.SubjectDetails) //populate with labels panel
            {
                if (grade.user_id == user.id)
                {
                    var lbl = new LinkLabel();
                    lbl.Name = grade.id.ToString();
                    lbl.Text = grade.grade_value.ToString();
                    lbl.LinkClicked += ShowGradePanel; //event handler of click
                    lbl.Tag = new Point(grade.id, sub.id); //just 2d vector with id of grade and subject //tmp solution
                    lbl.AutoSize = true;
                    if (visiting)
                    {
                        lbl.Enabled = false;
                    }
                    panel.Controls.Add(lbl);
                }
            }
        }


        /// <summary>
        /// Calls edit form for grade
        /// </summary>
        /// <param name="sub">Subject to which grade will be added</param>
        private void AddGradeToSubject(SubjectsViewModel sub)
        {
            SubjectDetailsViewModel grade = new SubjectDetailsViewModel()
            {
                sub_id = sub.id,
                grade_weight = 1
            };

            var editForm = new EditGradeForm(grade, true);
            editForm.ShowDialog();
            UpdateMainForm();
        }
        /// <summary>
        /// Method that handles click on grade label. Left click shows edit grade form to edit given grade.
        /// Right click deletes given grade.
        /// </summary>
        /// <param name="sender">Clicked object</param>
        /// <param name="e">Event parameters</param>
        private async void ShowGradePanel(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var lblSender = sender as LinkLabel;
            var data = (Point)lblSender.Tag;

            var gradesPanel = this.Controls.Find("panel" + data.Y, true).First() as FlowLayoutPanel;

            var repo = new HttpSubjectDetailsRepository();
            var g = await repo.GetOne(data.X);
            //var g = repo.GetGrade(data.X);
            if (e.Button == MouseButtons.Left)
            {
                if (g == null)
                    MessageBox.Show("Test");
                //var editForm = Program.GetKernel().Get<EditGradeForm>(new ConstructorArgument("grade", g));
                var editForm = new EditGradeForm(g);
                editForm.ShowDialog();
                UpdateMainForm();
            }
            else if (e.Button == MouseButtons.Right)
            {
                await repo.DeleteOne(g);
                //repo.DeleteGrade(g);
                //gradesPanel.Controls.Remove(lblSender);
                //Refresh();
                UpdateMainForm();
            }
        }

        private void ExitClick(object sender, EventArgs e)
        {
            //ToolStripMenuItem item = (ToolStripMenuItem)sender;
            //if(toCloseApp)
            //    Application.Exit();
            if (visiting)
            {
                toCloseApp = false;

            }
            else
            {
                toCloseApp = true;
            }
            this.Close();
        }
        private void ExitIconClick(object sender, FormClosedEventArgs e)
        {
            //toCloseApp = true;
            if(toCloseApp)
                Application.Exit();
        }

        private void LogoutClick(object sender, EventArgs e)
        {
            toCloseApp = false;
            Globals.CurrentUser = null;
            
            var openForms = Application.OpenForms;
            openForms.OfType<LoginForm>().First().Show(); //show login form
            this.Close();
        }



    }
}
