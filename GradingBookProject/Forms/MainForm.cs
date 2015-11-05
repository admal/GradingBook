using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using GradingBookProject.Data;

namespace GradingBookProject.Forms
{
    public partial class MainForm : Form
    {
        //private static int defaultYear = 0;
        private int selectedYear;
        Users user;
        public MainForm()
        {
            InitializeComponent();
            user = Globals.CurrentUser;
           
            foreach(var year in user.Years){
                listYear.Items.Add(year.id);
            }

            if (listYear.Items.Count != 0)
            {
                listYear.SelectedIndex = 0;
            }

        }

        /// <summary>
        /// set Year for which the subjects and grades are supposeed to be displayed
        /// </summary>
        /// <param name="sender">Chosen ComboBox element</param>
        /// <param name="e"></param>
        private void listYearSelected(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            var selectedIndex = cmb.SelectedIndex;

            //TEMPORARY parsing the selected value and subtrackting 1 to reflect index
            //selectedYear = int.Parse(cmb.SelectedItem.ToString());
            selectedYear = selectedIndex;
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
            if(user.Years.Count != 0 && user.Years.ElementAt(selectedYear).Subjects.Count != 0){
                //get current user and his subjects on chosen year
                var subjects = user.Years.ElementAt(selectedYear).Subjects;
            
                //transfer subjects to an array of strings
                string[] subjectsArray = new string[subjects.ToArray().Length];
                for (int i = 0; i < subjects.ToArray().Length; i++)
                {
                    subjectsArray[i] = subjects.ElementAt(i).name;
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
                foreach (var subject in user.Years.ElementAt(selectedYear).Subjects)
                {

                    //var grades = user.Years.ElementAt(selectedYear).Subjects.ElementAt(0).Grades;
                    string gradesArray = "";
                    foreach (var g in subject.Grades)
                    {
                        gradesArray = g.value + ", " + gradesArray;
                    }

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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
    }
}
