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
        private Years yearLocal;
        private int userid = Globals.CurrentUser.id;

        public YearForm(Years year)
        {
            InitializeComponent();
            years = new YearsRepository();
            //u => u.username == user.username
            if ((yearLocal = years.Years(year.user_id).FirstOrDefault(y => y.id == year.id)) != null)
            {
                txtYearDesc.Text = yearLocal.year_desc;
                txtYearEnd.Text = yearLocal.end_date.ToString();
                txtYearStart.Text = yearLocal.start.ToString();
                txtYearName.Text = yearLocal.name;
                edit = true;
            }
            
        }

        public YearForm()
        {
            InitializeComponent();
            years = new YearsRepository();
            txtYearStart.Text = DateTime.Now.ToString("d");
            txtYearEnd.Text = DateTime.Now.AddDays(100).ToString("d");
            yearLocal = new Years();
        }

        private void btnYearSave_Click(object sender, EventArgs e)
        {
            yearLocal.start = DateTime.Parse(txtYearStart.Text);
            yearLocal.end_date = DateTime.Parse(txtYearEnd.Text);
            yearLocal.name = txtYearName.Text;
            yearLocal.year_desc = txtYearDesc.Text;

            if (edit)
            {
                years.UpdateYear(yearLocal);
            }
            else {
                years.AddYear(yearLocal, userid);
            }
            
            DialogResult dialogResult = MessageBox.Show("Changes saved successfuly.", "Year", MessageBoxButtons.OK);
        }

        private void btnYearCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
