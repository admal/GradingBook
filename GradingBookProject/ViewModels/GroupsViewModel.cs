using System.Collections.Generic;


namespace GradingBookProject.ViewModels
{
    public class GroupsViewModel : EntityViewModel
    {
        public GroupsViewModel()
        {
            GroupDetails = new List<GroupDetailsViewModel>();
            Years = new List<YearsViewModel>();
        }
        public string name { get; set; }
        public int owner_id { get; set; }
        public System.DateTime created_at { get; set; }
        public string description { get; set; }
    
        
        public virtual ICollection<GroupDetailsViewModel> GroupDetails { get; set; }
        public virtual ICollection<YearsViewModel> Years { get; set; }
    }
}
