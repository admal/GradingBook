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
using GradingBookProject.Validation;

namespace GradingBookProject.Forms
{
    public partial class EditGradeForm : Form
    {
        private SubjectDetails grade;
        private bool addGrade;
        public EditGradeForm(SubjectDetails _grade, bool add = false)
        {
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

        private void CancelChanges(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteClick(object sender, EventArgs e)
        {
             DialogResult result = MessageBox.Show("Are you sure you want to delete given grade?","Delete grade?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var repo = new GradesRepository();
                repo.DeleteGrade(grade);
                this.Close();
            }
        }

        private void SaveClick(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            var g = grade;
            try
            {
                if (!(validator.IsNotEmpty(tbGrade.Text)
                      && validator.IsNotEmpty(tbWeight.Text)))
                {
                    MessageBox.Show("All inputs must be filles", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                float val = validator.ValidateNumber(tbGrade.Text);
                if (!validator.ValidateGrade(val))
                {
                    MessageBox.Show("Given value is not a proper grade!","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            }
            g.grade_desc = tbDesc.Text;
            if (addGrade) //set date when it was added
            {
                g.grade_date = new DateTime();
            }

            var result = MessageBox.Show("Are you sure you want to save changes?", "Save changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var repo = new GradesRepository();
                if(!addGrade)
                    repo.UpdateGrade(g);
                else
                    repo.AddGrade(g);
                this.Close();
            }
        }
    }
}
