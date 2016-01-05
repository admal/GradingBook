using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GradingBookProject.ViewModels
{
    /// <summary>
    /// Subjects view model for Subjects model.
    /// </summary>
    public class SubjectsViewModel : EntityViewModel
    {
        public string name { get; set; }
        public string sub_desc { get; set; }
        public int year_id { get; set; }
        public string teacher_mail { get; set; }

        /// <summary>
        /// Collection of subjectDetails
        /// </summary>
        public virtual ICollection<SubjectDetailsViewModel> SubjectDetails { get; set; }
    }
}
