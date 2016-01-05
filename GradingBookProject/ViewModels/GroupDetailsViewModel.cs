using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject.ViewModels
{
    /// <summary>
    /// View model that represents GroupDetails entity.
    /// </summary>
    public class GroupDetailsViewModel : EntityViewModel
    {
        public int user_id { get; set; }
        public int group_id { get; set; }
    }
}
