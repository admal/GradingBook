using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GradingBookProject.Data;
using GradingBookProject.Models;
using GradingBookProject.Validation;
using GradingBookProject.ViewModels;

namespace GradingBookProject.Forms
{

    /// <summary>
    /// Form for editing given grade
    /// </summary>
    public partial class EditGradeForm : Form
    {
        /// <summary>
        /// Http repository for managing grades.
        /// </summary>
        private HttpSubjectDetailsRepository grades;
        /// <summary>
        /// Grade to edit
        /// </summary>
        private SubjectDetailsViewModel grade;
        /// <summary>
        /// Specifies if we edit new added grade or edit existing one
        /// </summary>
        private bool addGrade;
        /// <summary>
        /// Constructor of the form
        /// </summary>
        /// <param name="_grade">grade to edit/add</param>
        /// <param name="add">specifies if provided grade is a new or existing one</param>
        public EditGradeForm(SubjectDetailsViewModel _grade, bool add = false)
        {
            grades = new HttpSubjectDetailsRepository();
            this.grade = _grade;
            addGrade = add;
            InitializeComponent();


            tbGrade.Text = grade.grade_value.ToString("F1");
            tbWeight.Text = grade.grade_weight.ToString();
            tbDesc.Text = grade.grade_desc;
            date.Enabled = false;
            if (grade.grade_date != null)
                date.Value = grade.grade_date.Value;

            if (addGrade)
                btnDelete.Enabled = false;

        }
        /// <summary>
        /// Button click handler, it cancels all provided changes and closes form
        /// </summary>
        /// <param name="sender">sender of the event</param>
        /// <param name="e">event parameters</param>
        private void CancelChanges(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Button click handler, it deletes existing grade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DeleteClick(object sender, EventArgs e)
        {
             DialogResult result = MessageBox.Show("Are you sure you want to delete given grade?","Delete grade?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                await grades.DeleteOne(grade);
                this.Close();
            }
        }
        /// <summary>
        /// Button cick handler, it saves all provided changes and create all edit grade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SaveClick(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            var g = grade;
            try
            {
                if (!(validator.IsNotEmpty(tbGrade.Text)
                      && validator.IsNotEmpty(tbWeight.Text)))
                {
                    MessageBox.Show("All inputs must be filled", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                float val = validator.ValidateNumber(tbGrade.Text);
                if (!validator.ValidateGrade(val))
                {
                    MessageBox.Show("Given value is not a proper grade, [2, 5]!","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                g.grade_value = val;
                val = (int)validator.ValidateNumber(tbWeight.Text);
                if (val > 0)
                    g.grade_weight = (int)val;
                else
                {
                    MessageBox.Show("Given value is not a proper weight!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            g.grade_desc = tbDesc.Text;
            if (addGrade) //set date when it was added
            {
                g.grade_date = DateTime.Now;
            }

            var result = MessageBox.Show("Are you sure you want to save changes?", "Save changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (!addGrade)
                        await grades.EditOne(g);
                    else
                        await grades.AddOne(g);
                    this.Close();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
