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
        private int userid;
        private IYearsRepository years;
        private ISubjectsRepository subjects;
        private IGradesRepository grades;

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
            //UpdateTable();
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
                listYear.SelectedIndex = 0;
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
            UpdateTable();
        }

        /// <summary>
        /// updates the table of subjects and grades according to the chosen year
        /// </summary>
        private void UpdateTable()
        {
            //clear table
            ClearTableMarks();

            //populate the Marks table with db records check if there are subjects on chosen year
            if(years.Years(userid).Count() != 0 && subjects.Subjects(selectedYear).Count() != 0){
                //get current user and his subjects on chosen year
                var subjectsEnumerated = subjects.Subjects(selectedYear);

                //transfer subjects to an array of strings
                string[] subjectsArray = new string[subjectsEnumerated.ToArray().Length];
                for (int i = 0; i < subjectsEnumerated.ToArray().Length; i++)
                {
                    subjectsArray[i] = subjectsEnumerated.ElementAt(i).name;
                }

                //populate the Marks table with subjects
                tableMarks.RowCount = subjectsArray.Length;
                for (int i = 0; i < subjectsArray.Length; i++)
                {
                    tableMarks.Controls.Add(new Label() { 
                        Text = subjectsArray[i], Anchor = AnchorStyles.Left, AutoSize = false },0,i);
                    tableMarks.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
                    //tableMarks.Controls[i].Height = 20;
                }
                /////////////////////////////
                //get user grades
                int currRow = 0;
                foreach (var subject in subjects.Subjects(selectedYear))
                {
                    string gradesArray = "";

                    //it compiles with new model //editor: Adam
                    foreach (var g in subject.SubjectDetails)
                    {
                        gradesArray = g.Grades.value + ", " + gradesArray;
                    }
                    ///////////////////////////////////

                    tableMarks.Controls.Add(new Label()
                            {
                                Text = gradesArray,
                                Anchor = AnchorStyles.Left,
                                AutoSize = false
                            }, 1, currRow);

                    currRow++;
                }
            }
            //////////////////////////////////////////
            //populate the Marks table with grades
            foreach (var rowMarks in tableMarks.Controls)
            {
            
            }


        }

        private void ClearTableMarks()
        {
            tableMarks.Controls.Clear();
            this.tableMarks.ColumnCount = 2;
            this.tableMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.AutoSize));
            this.tableMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.AutoSize));
        }


        /*----------------------------- MENU STRIP ---------------------------*/

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            MessageBox.Show("Current version: A0.1");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            Application.Exit();
        }

        /*----------------------------- CRUDs Year---------------------------*/

        private void btnAddYear_Click(object sender, EventArgs e)
        {
            var yearForm = Program.GetKernel().Get<YearForm>();
            yearForm.ShowDialog();
            UpdateMainForm();
        }

        private void btnDeleteYear_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the currently selected year?", "Delete a Year", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                years.DeleteYear(years.Year(selectedYear, userid), userid);
                UpdateMainForm();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void btnEditYear_Click(object sender, EventArgs e)
        {
            var yearForm = Program.GetKernel().Get<YearForm>(new ConstructorArgument("year", years.Year(selectedYear, userid)));
            yearForm.ShowDialog();
            UpdateMainForm();
        }
        
    }
}
