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
using Ninject;
using GradingBookProject.Data;
using Ninject.Parameters;

namespace GradingBookProject.Forms
{
    public partial class MainForm : Form
    {
        //private static int defaultYear = 0;
        private int selectedYear;
        private YearListItem selectedYearListItem;
        private int userid;
        private IYearsRepository years;
        private ISubjectsRepository subjects;
        private IGradesRepository grades;

        private bool toCloseApp = true;
        public MainForm()
        {
            InitializeComponent();
            // Get id of current user.
            userid = Globals.CurrentUser.id;
            
            // Initialize repositories.
            UpdateRepositories();
            
            //populate the list of Years
            UpdateYearList();
        }
        /*-----------------------------UPDATING FUNCTIONS-----------------------------*/
        private  void UpdateRepositories() {
            years = new YearsRepository();
            subjects = new SubjectsRepository();
            grades = new GradesRepository();
        }

        private void UpdateMainForm() {
            UpdateRepositories();
            UpdateYearList();
            UpdateTable();
        }   

        private void UpdateYearList(){
            listYear.Items.Clear();
            foreach (var year in years.Years(userid))
            {
                YearListItem item = new YearListItem(year.name, year.id);
                listYear.Items.Add(item);
            }

            if (listYear.Items.Count != 0)
            {
                if (selectedYearListItem != null)
                {
                    listYear.SelectedIndex = listYear.Items.IndexOf(selectedYearListItem);
                }
                else
                {
                    listYear.SelectedIndex = 0;
                }
            }
        }
        /*-----------------------------POPULATING FUNCTIONS-----------------------------*/
        /// <summary>
        /// set Year for which the subjects and grades are supposeed to be displayed
        /// </summary>
        /// <param name="sender">Chosen ComboBox element</param>
        /// <param name="e"></param>
        private void listYearSelected(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            var selectedIndex = (int)cmb.SelectedIndex;
            var item= (YearListItem)cmb.SelectedItem;
            //TEMPORARY parsing the selected value and subtrackting 1 to reflect index
            //selectedYear = int.Parse(cmb.SelectedItem.ToString());
            selectedYear = item.Id;
            selectedYearListItem = new YearListItem(item.ToString(), item.Id);
            UpdateTable();
        }

        /// <summary>
        /// updates the table of subjects and grades according to the chosen year
        /// </summary>
        private void UpdateTable()
        {
            //clear table
            ClearTableMarks();
            tableMarks.AutoSize = true;
            //populate the Marks table with db records check if there are subjects on chosen year
            if (years.Years(userid).Count() != 0 && years.Year(selectedYear, userid) != null && subjects.Subjects(selectedYear).Count() != 0)
            {
                //get current user and his subjects on chosen year
                var subjectsEnumerated = subjects.Subjects(selectedYear);
                //var row = 0;
                //var percentHeight = 100/subjectsEnumerated.Count();
                foreach (var subject in subjectsEnumerated)
                {
                    tableMarks.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    LinkLabel temp;
                    tableMarks.Controls.Add(temp = new LinkLabel()
                    {
                        Text = subject.name,
                        Anchor = AnchorStyles.Left,
                        AutoSize = true,//false
                        ActiveLinkColor = Color.Black,
                        LinkBehavior = LinkBehavior.NeverUnderline,
                        Tag = subject.id
                    });
                    temp.Click += new System.EventHandler(this.Subject_Click);

                    CreateGradesLabels(subject);

                    tableMarks.Controls.Add(new Label()
                    {
                        Text = CalculateAverage(subject).ToString(),
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
                    btn.Click+=AddGradeClick;
                    tableMarks.Controls.Add(btn);
                    tableMarks.RowCount++;
                }

            }
            
        }

        /// <summary>
        /// Calculates the weighted average from marks of a given subject.
        /// </summary>
        /// <param name="subject">Subject id.</param>
        /// <returns>WeightAverage from marks</returns>
        private double CalculateAverage(Subjects subject)
        {
            SubjectDetails[] data = grades.SubjectGrades(subject.id).ToArray();
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

        void AddGradeClick(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var subId = (int) btn.Tag;
            var sub = subjects.GetSubject(subId);
            AddGradeToSubject(sub);
        }

        private void ClearTableMarks()
        {
            tableMarks.Controls.Clear();
            this.tableMarks.ColumnCount = 4;
            this.tableMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent,20));
            this.tableMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 50));
            this.tableMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 10));
            this.tableMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 20));
        }


        /*----------------------------- MENU STRIP ---------------------------*/

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            MessageBox.Show("Current version: A0.1");
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

        private void btnAddYear_Click(object sender, EventArgs e)
        {
            var yearForm = Program.GetKernel().Get<YearForm>();
            yearForm.FormClosed += new FormClosedEventHandler(this.Form_Close);
            yearForm.ShowDialog();
        }



        private void btnDeleteYear_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the currently selected year?", "Delete a Year", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                years.DeleteYear(years.Year(selectedYear, userid), userid);
                selectedYearListItem = null;
                UpdateMainForm();
                //exception after removing a year we move to next existing

            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void btnEditYear_Click(object sender, EventArgs e)
        {
            var yearForm = Program.GetKernel().Get<YearForm>(new ConstructorArgument("year", years.Year(selectedYear, userid)));
            yearForm.FormClosed += new FormClosedEventHandler(Form_Close);
            yearForm.ShowDialog();
            selectedYearListItem.Name(years.Year(selectedYear, userid).name);
        }

        /*----------------------------- CRUDs Subject---------------------------*/

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            var subjectForm = Program.GetKernel().Get<SubjectForm>(new ConstructorArgument("yearid", selectedYear));
            subjectForm.FormClosed += new FormClosedEventHandler(this.Form_Close);
            subjectForm.ShowDialog();
        }            

        private void Subject_Click(object sender, EventArgs e) 
        {
            LinkLabel link = (LinkLabel)sender;
            int subjectid = (int)link.Tag;
            var subjectForm = Program.GetKernel().Get<SubjectForm>(new ConstructorArgument("subject", 
                subjects.Subject(selectedYear, subjectid)));
            subjectForm.FormClosed += new FormClosedEventHandler(this.Form_Close);
            subjectForm.ShowDialog();
        }

        private void SettingsClick(object sender, EventArgs e)
        {
            var settingsForm =
            Program.GetKernel().Get<SettingsForm>(new ConstructorArgument("user", Globals.CurrentUser));
            settingsForm.ShowDialog();
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
        private void CreateGradesLabels(Subjects sub)
        {
            var panel = new FlowLayoutPanel(); //panel with grades
            panel.Name = "panel" + sub.id; //set name of the panel to: "panel+subId"
            panel.AutoSize = true;
            tableMarks.Controls.Add(panel); //add panel to tableMarks in proper position
            //this.Controls.Add(panel);
            foreach (var grade in sub.SubjectDetails) //populate with labels panel
            {
                var lbl = new LinkLabel();
                lbl.Name = grade.id.ToString();
                lbl.Text = grade.grade_value.ToString();
                lbl.LinkClicked += ShowGradePanel; //event handler of click
                lbl.Tag = new Point(grade.id, sub.id); //just 2d vector with id of grade and subject //tmp solution
                lbl.AutoSize = true;
                panel.Controls.Add(lbl);
            }
        }


        /// <summary>
        /// Calls edit form for grade
        /// </summary>
        /// <param name="sub">Subject to which grade will be added</param>
        private void AddGradeToSubject(Subjects sub)
        {
            SubjectDetails grade = new SubjectDetails()
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
        private void ShowGradePanel(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var lblSender = sender as LinkLabel;
            var data = (Point)lblSender.Tag;

            var gradesPanel = this.Controls.Find("panel" + data.Y, true).First() as FlowLayoutPanel;

            var repo = new GradesRepository();
            var g = repo.GetGrade(data.X);
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
                repo.DeleteGrade(g);
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
            toCloseApp = true;
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
