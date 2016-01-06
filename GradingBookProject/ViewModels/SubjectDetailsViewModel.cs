using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject.ViewModels
{
    /// <summary>
    /// View Model representing SubjectDetails entity from database.
    /// </summary>
    public class SubjectDetailsViewModel : EntityViewModel
    {
        /// <summary>
        /// Id of a subject the grade belongs to.
        /// </summary>
        public int sub_id { get; set; }
        /// <summary>
        /// Brief description of the grade.
        /// </summary>
        public string grade_desc { get; set; }
        /// <summary>
        /// Weight of a grade.
        /// </summary>
        public int grade_weight { get; set; }
        /// <summary>
        /// Date of the grade.
        /// </summary>
        public Nullable<System.DateTime> grade_date { get; set; }
        /// <summary>
        /// Value of a grade.
        /// </summary>
        public double grade_value { get; set; }
        /// <summary>
        /// Id of a user the grade belongs to.
        /// </summary>
        public Nullable<int> user_id { get; set; }
    }
}
