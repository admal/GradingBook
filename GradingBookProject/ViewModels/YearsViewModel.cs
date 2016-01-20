using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject.ViewModels
{
    /// <summary>
    /// View Model that represents Years entity from database.
    /// </summary>
    public class YearsViewModel : EntityViewModel
    {
        /// <summary>
        /// Name of the year.
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Date of when the year starts.
        /// </summary>
        public System.DateTime start { get; set; }
        /// <summary>
        /// Date of when the year ends.
        /// </summary>
        public System.DateTime end_date { get; set; }
        /// <summary>
        /// Brief description of the year.
        /// </summary>
        public string year_desc { get; set; }
        /// <summary>
        /// Id of a user the year belongs to.
        /// </summary>
        public Nullable<int> user_id { get; set; }
        /// <summary>
        /// Id of a group the year belongs to.
        /// </summary>
        public Nullable<int> group_id { get; set; }
        /// <summary>
        /// Name of the group that year belongs to (null if it does not belong)
        /// </summary>
        public string groupName { get; set; }

        /// <summary>
        /// Collection of subjects belonging to the year.
        /// </summary>
        public virtual ICollection<SubjectsViewModel> Subjects { get; set; }
    }
}
