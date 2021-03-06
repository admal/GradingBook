﻿using GradingBookProject.Data;
using GradingBookProject.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GradingBookProject.Models;
using GradingBookProject.ViewModels;
using GradingBookProject.Maths;

namespace GradingBookProject.Forms
{
    /// <summary>
    /// Form for Adding or Editing a Year to the database.
    /// </summary>
    public partial class YearForm : Form
    {
        /// <summary>
        /// Comparator for comparing Years
        /// </summary>
        private Comparator comparator = new Comparator();
        /// <summary>
        /// Validator for checking user input.
        /// </summary>
        private Validator validator = new Validator();
        /// <summary>
        /// Repository of Years of current user.
        /// </summary>
        private HttpYearsRepository yearsRepo;
        /// <summary>
        /// Determines wether we edit a Year or add a new one.
        /// </summary>
        private bool edit = false;
        /// <summary>
        /// Local variable for storing a input/edit Year.
        /// </summary>
        private YearsViewModel yearLocal;
        /// <summary>
        /// Current user.
        /// </summary>
        private int userid = Globals.CurrentUser.id;
        /// <summary>
        /// Group to which we add year. By default is null.
        /// </summary>
        private GroupsViewModel currGroup = null;
        /// <summary>
        /// Constructor taking existing Year and filling in the form.
        /// </summary>
        /// <param name="year">Year to edit.</param>
        public YearForm(YearsViewModel year)
        {
            InitializeComponent();
            LoadData(year);
        }
        /// <summary>
        /// Loads data from given year to a form.
        /// <param name="year">Year to be displayed</param>
        /// </summary>
        private async void LoadData(YearsViewModel year) {

            yearsRepo = new HttpYearsRepository();
            if ((yearLocal = await yearsRepo.GetOne(year.id)) != null)
            {
                txtYearDesc.Text = yearLocal.year_desc;
                txtYearEnd.Text = yearLocal.end_date.ToString("yyyy-MM-dd");
                txtYearStart.Text = yearLocal.start.ToString("yyyy-MM-dd");
                txtYearName.Text = yearLocal.name;
                edit = true;
            }
        }
        /// <summary>
        /// Default constructor for Year Form
        /// </summary>
        public YearForm()
        {
            InitializeComponent();
            yearsRepo = new HttpYearsRepository();
            txtYearStart.Text = DateTime.Now.ToString("d");
            txtYearEnd.Text = DateTime.Now.AddDays(100).ToString("d");
            yearLocal = new YearsViewModel();
            //yearLocal.user_id = Globals.CurrentUser.id;
        }
        /// <summary>
        /// Constructor taking group to which year is assigned.
        /// </summary>
        /// <param name="group"></param>
        public YearForm(GroupsViewModel group) : this()
        {
            currGroup = group;
        }
        /// <summary>
        /// Saves either a new Year to database or edited existing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnYearSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            // Validating the dates.
            if (!(validator.isValidDate(txtYearStart.Text)) || !(validator.isValidDate(txtYearEnd.Text))){
                MessageBox.Show("Incorrect date. Needs to be in form: \" year-month-day \"", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(validator.IsNotEmpty(txtYearName.Text))) {
                MessageBox.Show("Name of the year can not be empty.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            yearLocal.start = DateTime.Parse(txtYearStart.Text);
            yearLocal.end_date = DateTime.Parse(txtYearEnd.Text);

            if (!(yearLocal.end_date == comparator.isLater(yearLocal.start, yearLocal.end_date))) {
                MessageBox.Show("Year end has to be later than the start", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            yearLocal.name = txtYearName.Text;
            yearLocal.year_desc = txtYearDesc.Text;
            

            try
            {
                if (currGroup != null)//determines if year belongs to group or to the user
                {
                    yearLocal.group_id = currGroup.id;
                }
                else
                {
                    yearLocal.user_id = Globals.CurrentUser.id;

                }
                // Depending on whether you add or edit a Year different operation is called.
                if (edit)
                    await yearsRepo.EditOne(yearLocal);
                else
                {

                    await yearsRepo.AddOne(yearLocal); 
                }

                DialogResult dialogResult = MessageBox.Show("Changes saved successfuly.", "Year", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception exception){
                MessageBox.Show(exception.Message,
                     "Error",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            
            }
            this.Cursor = Cursors.Default;
            this.Enabled = true;

        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYearCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
