using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject.ViewModels
{
    public class YearsViewModel : EntityViewModel
    {
        public string name { get; set; }
        public System.DateTime start { get; set; }
        public System.DateTime end_date { get; set; }
        public string year_desc { get; set; }
        public int user_id { get; set; }
        public Nullable<int> group_id { get; set; }

        //public virtual GroupsViewModel Groups { get; set; }
        public virtual ICollection<SubjectsViewModel> Subjects { get; set; }
        //public virtual UsersViewModel Users { get; set; }
    }
}
