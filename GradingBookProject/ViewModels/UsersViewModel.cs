using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using GradingBookProject.Data;
using GradingBookProject.Models;

namespace GradingBookProject.ViewModels
{
    public class UsersViewModel : EntityViewModel
    {
        public string username { get; set; }
        public string passwd { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    
       // public virtual ICollection<GroupDetailsViewModel> GroupDetails { get; set; }
        public async Task<ICollection<GroupDetailsViewModel>>  Details()
        {
            HttpGroupDetailsRepository repo = new HttpGroupDetailsRepository();
            return (await repo.GetAll()).ProjectTo<GroupDetailsViewModel>().ToList();
        }
        
        public override string ToString()
        {
            return username;
        }
    }
}
