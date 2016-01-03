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
using GradingBookProject.Models;
using GradingBookProject.ViewModels;

namespace GradingBookProject.Forms
{
    /// <summary>
    /// Form for Editing/Adding/Deleting a Subject to the database.
    /// </summary>
    public partial class SubjectForm : Form
    {
        /// <summary>
        /// Validator for checking user input.
        /// </summary>
        Validator validator = new Validator();
        /// <summary>
        /// Current user.
        /// </summary>
        private int userid = Globals.CurrentUser.id;
        /// <summary>
        /// HttpRepository of Subjects of current user.
        /// </summary>
        private HttpSubjectsRepository subjects;
        /// <summary>
        /// Local variable for storing an Edited/Added/Deleted Subject.
        /// </summary>
        private SubjectsViewModel subjectLocal;
        /// <summary>
        /// Determines wether we Add or Edit a Subject.
        /// </summary>
        private bool edit = false;
        
        /// <summary>
        /// Constructor taking existing Subject and filling in the form.
        /// </summary>
        /// <param name="subject">Subject to edit.</param>
        public SubjectForm(SubjectsViewModel subject)
        {
            InitializeComponent();
            LoadData(subject);
            btnSubjectDelete.Enabled = true;
        }
        /// <summary>
        /// Loads data from given subject to a form.
        /// </summary>
        /// <param name="subject">Subject to be displayed</param>
        private async void LoadData(SubjectsViewModel subject)
        {
            subjects = new HttpSubjectsRepository();
            if ((subjectLocal = await subjects.GetOne(subject.id)) != null)
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
        /// <param name="yearid">Id of a Year for which we get Subjects.</param>
        public SubjectForm(int yearid) {
            InitializeComponent();
            subjects = new HttpSubjectsRepository();
            subjectLocal = new SubjectsViewModel();
            subjectLocal.year_id = yearid;
            btnSubjectDelete.Enabled = false;
        }

        /// <summary>
        /// Saves the edited or new Subject.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
 
        private async void btnSubjectSave_Click(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            subjectLocal.name = txtSubjectName.Text;
            subjectLocal.teacher_mail = txtSubjectEmail.Text;

            // Validating the mail
            if (validator.IsNotEmpty(subjectLocal.teacher_mail))
            {
                if (!(validator.isValidMail(subjectLocal.teacher_mail)))
                {
                    MessageBox.Show("Incorrect email. Needs to be in form: \" name@example.com \"", "Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!validator.IsNotEmpty(txtSubjectName.Text)) {
                MessageBox.Show("Name of the subject can not be empty.", "Error!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            subjectLocal.sub_desc = txtSubjectDesc.Text;

            try
            {
                // Depending on whether adding or editing a Subject differen action performed.
                if (edit)
                {
                    await subjects.EditOne(subjectLocal);
                    DialogResult dialogResult = MessageBox.Show("Changes saved successfuly.", "Subject", MessageBoxButtons.OK);
                    this.Close();
                }
                else
                {
                    await subjects.AddOne(subjectLocal);
                    DialogResult dialogResult = MessageBox.Show("Subject added successfuly.", "Subject", MessageBoxButtons.OK);
                    this.Close();
                }
            }
            catch (Exception exception) {
                MessageBox.Show(exception.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Exits a form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubjectCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Deletes a Subject from a database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSubjectDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the currently selected Subject?", "Delete a Subject", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    await subjects.DeleteOne(subjectLocal);
                    MessageBox.Show("Subject deleted successfuly", "Delete a Subject", MessageBoxButtons.OK);
                    this.Close();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }
    }
}
