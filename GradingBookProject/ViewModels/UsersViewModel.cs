using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using GradingBookProject.Data;

namespace GradingBookProject.ViewModels
{
    public class UsersViewModel : EntityViewModel
    {
        public string username { get; set; }
        public string passwd { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

        public virtual ICollection<GroupDetailsViewModel> GroupDetails { get; set; }
        public virtual ICollection<GroupsViewModel> Groups { get; set; }
        public virtual ICollection<YearsViewModel> Years { get; set; }

        public override string ToString()
        {
            return username;
        }
    }
}
