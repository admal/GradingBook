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

namespace GradingBookProject.Forms
{
    public partial class tmpForm : Form
    {
        private Users user = Globals.CurrentUser;
        public tmpForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var r = new Random();
            int grade = r.Next(1, 6);
            var repo = new GradesRepository();
            
            //user.Years.First().Subjects.First().SubjectDetails.Add(new SubjectDetails()
            //{
            //    Grades = 
            //});
        }


    }
}
