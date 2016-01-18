using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GradingBookProject.ViewModels
{
    /// <summary>
    /// View Model that represents Subjects entity from database.
    /// </summary>
    public class SubjectsViewModel : EntityViewModel
    {
        /// <summary>
        /// Name of the Subject.
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Brief description of the subject.
        /// </summary>
        public string sub_desc { get; set; }
        /// <summary>
        /// Id of a year that the subject belongs to.
        /// </summary>
        public int year_id { get; set; }
        /// <summary>
        /// Subject teacher's email address.
        /// </summary>
        public string teacher_mail { get; set; }
       // public Nullable<double> final_grade { get; set; }

        /// <summary>
        /// Collection of grades belonging to the subject.
        /// </summary>
        public virtual ICollection<SubjectDetailsViewModel> SubjectDetails { get; set; }
    }
}
