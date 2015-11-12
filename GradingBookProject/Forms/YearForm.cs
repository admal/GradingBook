using GradingBookProject.Data;
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
    public partial class YearForm : Form
    {
        private YearsRepository years;
        private bool edit = false;

        public YearForm()
        {
            InitializeComponent();
            txtYearStart.Text = DateTime.Now.ToString("d");
            txtYearEnd.Text = DateTime.Now.AddDays(100).ToString("d");
        }

        public YearForm(Years year)
        {
            InitializeComponent();
            txtYearDesc.Text = year.year_desc;
            txtYearEnd.Text = year.end_date.ToString();
            txtYearStart.Text = year.start.ToString();
            txtYearName.Text = year.name;
            edit = true;
        }

        private void btnYearSave_Click(object sender, EventArgs e)
        {
            

        }
    }
}
