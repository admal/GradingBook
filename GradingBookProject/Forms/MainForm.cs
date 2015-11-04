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
        public MainForm()
        {
            InitializeComponent();
            //set default year to current
            selectedYear = System.DateTime.Today.Year;
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
            var selectedValue = int.Parse(cmb.SelectedItem.ToString());
            selectedYear = selectedValue;
            UpdateTable();
        }

        /// <summary>
        /// updates the table of subjects and grades according to the chosen year
        /// </summary>
        private void UpdateTable()
        {
            ClearTableMarks();

            tableMarks.ColumnCount = 2;
            //ninject
            var sRepo = Program.GetKernel().Get<ISubjectsRepository>();
            var subjects = sRepo.Subjects;
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
            }
                
        }

        private void ClearTableMarks()
        {
            tableMarks.Controls.Clear();
        }
    }
}
