using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject.ViewModels
{
    /// <summary>
    /// Subject Details view model for Subject Details model.
    /// </summary>
    public class SubjectDetailsViewModel : EntityViewModel
    {
        public int sub_id { get; set; }
        public string grade_desc { get; set; }
        public int grade_weight { get; set; }
        public Nullable<System.DateTime> grade_date { get; set; }
        public double grade_value { get; set; }

        public Nullable<int> user_id { get; set; }
    }
}
