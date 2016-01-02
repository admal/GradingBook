using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Models;

namespace GradingBookProject.ViewModels
{
    public class GroupsViewModel : EntityViewModel
    {
        public GroupsViewModel(Groups originalGroup)
        {
            this.id = originalGroup.id;
            this.name = originalGroup.name;
            this.created_at = originalGroup.created_at;
            this.owner_id = originalGroup.owner_id;
            
            //this.GroupDetails = originalGroup.GroupDetails
            //this.Years = new HashSet<YearsViewModel>();
        }
    
        //public int id { get; set; }
        public string name { get; set; }
        public int owner_id { get; set; }
        public System.DateTime created_at { get; set; }
        public string description { get; set; }
    
        
        public virtual ICollection<GroupDetailsViewModel> GroupDetails { get; set; }
        //public virtual UsersViewModel Users { get; set; }
        //public virtual ICollection<YearsViewModel> Years { get; set; }
    }
}
