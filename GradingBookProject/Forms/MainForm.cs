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
        private int selectedYear;
        Users user;
        public MainForm()
        {
            InitializeComponent();
            user = Globals.CurrentUser;
            //set default year to current
            selectedYear = System.DateTime.Today.Year;
            foreach(var year in user.Years){
                listYear.Items.Add(year.id);
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
            var chosenYear = int.Parse(cmb.SelectedItem.ToString());
            UpdateTable(chosenYear);
        }

        /// <summary>
        /// updates the table of subjects and grades according to the chosen year
        /// </summary>
        private void UpdateTable(int chosenYear)
        {
            //clear table
            ClearTableMarks();

            //get current user and his subjects on chosen year
            var subjects = user.Years.ElementAt(chosenYear-1).Subjects;
            
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
                    Text = subjectsArray[i], Anchor = AnchorStyles.Left, AutoSize = true },0,i);
                tableMarks.Controls[i].Height = 20;
            }

            //AddRandomDataForChecking();

        }

        private void AddRandomDataForChecking()
        {
            var yRepo = Program.GetKernel().Get<IYearsRepository>();
            Years year = new Years();
            year.start = DateTime.Now;
            year.end_date = DateTime.Now;
            year.name = "semester 1";
            yRepo.AddYear(year);
            MessageBox.Show(year.start.ToString());
        }

        private void ClearTableMarks()
        {
            tableMarks.Controls.Clear();
            tableMarks.ColumnCount = 2;
           
        }
    }
}
