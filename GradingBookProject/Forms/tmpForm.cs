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
using Ninject;
using Ninject.Parameters;

namespace GradingBookProject.Forms
{
    public partial class tmpForm : Form
    {
        private Users user = null;
        public tmpForm()
        {
            InitializeComponent();

            var repo = new UsersRepository();
            user = repo.Users.FirstOrDefault(u => Globals.CurrentUser.id == u.id);
            if (user == null) //if error occured close the form
            {
                MessageBox.Show("Error: Unknown error occured!");
                this.Close();
            }
            var sub = user.Years.First().Subjects.First();
            CreateGradesLabels(sub);

        }
        /// <summary>
        /// Creates link labels with grade values.
        /// </summary>
        /// <param name="sub">Subject with grades to show</param>
        private void CreateGradesLabels(Subjects sub)
        {
            var panel = new FlowLayoutPanel();
            panel.Name = "panel" + sub.id;

            this.Controls.Add(panel);
            foreach (var grade in sub.SubjectDetails)
            {
                var lbl = new LinkLabel();
                lbl.Name = grade.id.ToString();
                lbl.Text = grade.grade_value.ToString();
                lbl.LinkClicked += ShowGradePanel;
                lbl.Tag = new Point(grade.id, sub.id); //just 2d vector
                lbl.AutoSize = true;
                panel.Controls.Add(lbl);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                //var r = new Random();
                //int grade = r.Next(2, 5);
                var subject = user.Years.First().Subjects.First();

                //SubjectDetails gradeS = new SubjectDetails()
                //{
                //    sub_id = subject.id,
                //    grade_value = grade
                //};

                //var repo = new GradesRepository();
                //repo.AddGrade(gradeS);

                //var lbl = new LinkLabel();
                //lbl.Text = grade.ToString();
                //lbl.LinkClicked += ShowGradePanel;

                //lbl.Tag = gradeS.id;
                //lbl.AutoSize = true;

                //this.Controls.Find("panel1", true).First().Controls.Add(lbl);
                //Refresh();
            AddGradeToSubject(subject);
 
        }
        /// <summary>
        /// Calls edit form for grade
        /// </summary>
        /// <param name="sub">Subject to which grade will be added</param>
        private void AddGradeToSubject(Subjects sub)
        {
            SubjectDetails grade = new SubjectDetails()
            {
                sub_id = sub.id
            };

            var editForm = new EditGradeForm(grade, true);
            editForm.ShowDialog();
        }
        /// <summary>
        /// Method that handles click on grade label. Left click shows edit grade form to edit given grade.
        /// Right click deletes given grade.
        /// </summary>
        /// <param name="sender">Clicked object</param>
        /// <param name="e">Event parameters</param>
        void ShowGradePanel(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var lblSender = sender as LinkLabel;
            var data = (Point)lblSender.Tag;

            var gradesPanel = this.Controls.Find("panel"+data.Y, true).First() as FlowLayoutPanel;

            var repo = new GradesRepository();
            var g = repo.GetGrade(data.X);
            if (e.Button == MouseButtons.Left)
            {
                if(g == null)
                    MessageBox.Show("Test");
                //var editForm = Program.GetKernel().Get<EditGradeForm>(new ConstructorArgument("grade", g));
                var editForm = new EditGradeForm(g);
                editForm.ShowDialog();
            }
            else if (e.Button == MouseButtons.Right)
            {
                repo.DeleteGrade(g);
                gradesPanel.Controls.Remove(lblSender);
                Refresh();
            }
        }

        public void RefreshForm()
        {
            var controls = this.Controls.OfType<FlowLayoutPanel>().ToList();
            controls.Clear();

            CreateGradesLabels(user.Years.First().Subjects.First());
        }


    }
}
