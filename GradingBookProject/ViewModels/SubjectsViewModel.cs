using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GradingBookProject.ViewModels
{
    public class SubjectsViewModel : EntityViewModel
    {
        public string name { get; set; }
        public string sub_desc { get; set; }
        public int year_id { get; set; }
        public string teacher_mail { get; set; }

        public virtual ICollection<SubjectDetailsViewModel> SubjectDetails { get; set; }
        //public virtual Years Years { get; set; }
    }
}
