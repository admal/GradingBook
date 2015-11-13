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
        private Years yearChanged;

        public YearForm(Years year)
        {
            InitializeComponent();
            years = new YearsRepository();
            //u => u.username == user.username
            if ((yearChanged = years.Years.FirstOrDefault(y => y.id == year.id)) != null)
            {
                InitializeComponent();
                txtYearDesc.Text = yearChanged.year_desc;
                txtYearEnd.Text = yearChanged.end_date.ToString();
                txtYearStart.Text = yearChanged.start.ToString();
                txtYearName.Text = yearChanged.name;
            }
            
        }

        public YearForm()
        {
            InitializeComponent();
            txtYearStart.Text = DateTime.Now.ToString("d");
            txtYearEnd.Text = DateTime.Now.AddDays(100).ToString("d");
        }

        private void btnYearSave_Click(object sender, EventArgs e)
        {

           
        }
    }
}
