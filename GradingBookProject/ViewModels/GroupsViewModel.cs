using System.Collections.Generic;


namespace GradingBookProject.ViewModels
{
    /// <summary>
    /// View model that represents Groups entity from  the database.
    /// </summary>
    public class GroupsViewModel : EntityViewModel
    {
        public GroupsViewModel()
        {
            GroupDetails = new List<GroupDetailsViewModel>();
            Years = new List<YearsViewModel>();
        }
        /// <summary>
        /// Name of the grouop
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Id of the group's owner.
        /// </summary>
        public int owner_id { get; set; }
        /// <summary>
        /// Date when the group was created.
        /// </summary>
        public System.DateTime created_at { get; set; }
        /// <summary>
        /// Description of the group.
        /// </summary>
        public string description { get; set; }
        
        /// <summary>
        /// All members of the group.
        /// </summary>
        public virtual ICollection<GroupDetailsViewModel> GroupDetails { get; set; }
        /// <summary>
        /// Years common for all users in the group.
        /// </summary>
        public virtual ICollection<YearsViewModel> Years { get; set; }
    }
}
