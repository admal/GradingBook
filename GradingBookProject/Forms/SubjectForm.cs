using GradingBookProject.Data;
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

namespace GradingBookProject.Forms
{
    public partial class SubjectForm : Form
    {
        private int userid = Globals.CurrentUser.id;
        private SubjectsRepository subjects;
        private YearsRepository years;
        private Subjects subjectLocal;
        private bool edit = false;
        
        /// <summary>
        /// Constructor taking existing Subject and filling in the form.
        /// </summary>
        /// <param name="subject">Subject to edit.</param>
        public SubjectForm(Subjects subject)
        {
            InitializeComponent();
            subjects = new SubjectsRepository();
            years = new YearsRepository();

            if ((subjectLocal = subjects.Subject(subject.year_id, subject.id)) != null)
            {
                txtSubjectDesc.Text = subjectLocal.sub_desc;
                txtSubjectEmail.Text = subjectLocal.teacher_mail;
                txtSubjectName.Text = subjectLocal.name;

                edit = true;
            }
        }

        /// <summary>
        /// Pure form for adding a new subject.
        /// </summary>
        /// <param name="yearid"></param>
        public SubjectForm(int yearid) {
            InitializeComponent();
            subjects = new SubjectsRepository();
            years = new YearsRepository();
            subjectLocal = new Subjects();
            subjectLocal.year_id = yearid;
        }

        // Saves the data input or edited.
        private void btnSubjectSave_Click(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            subjectLocal.name = txtSubjectName.Text;
            subjectLocal.teacher_mail = txtSubjectEmail.Text;

            // Validating the mail
            if (!(validator.isValidMail(subjectLocal.teacher_mail)) && validator.IsNotEmpty(subjectLocal.teacher_mail))
            {
                MessageBox.Show("Incorrect email. Needs to be in form: \" name@example.com \"", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            subjectLocal.sub_desc = txtSubjectDesc.Text;

            // Depending on whether adding or editing a Subject differen action performed.
            if (edit)
            {
                subjects.UpdateSubject(subjectLocal, subjectLocal.year_id);
                DialogResult dialogResult = MessageBox.Show("Changes saved successfuly.", "Subject", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                subjects.AddSubject(subjectLocal, subjectLocal.year_id);
                DialogResult dialogResult = MessageBox.Show("Subject added successfuly.", "Subject", MessageBoxButtons.OK);
                this.Close();
            }

        }

        private void btnSubjectCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubjectDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the currently selected Subject?", "Delete a Subject", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                subjects.DeleteSubject(subjects.Subject(subjectLocal.year_id, subjectLocal.id), subjectLocal.year_id);
                MessageBox.Show("Subject deleted successfuly", "Delete a Subject", MessageBoxButtons.OK);
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }
    }
}
