using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using GradingBookProject.Data;

namespace GradingBookProject.ViewModels
{
    /// <summary>
    /// View model that represents Users entity from the database.
    /// </summary>
    public class UsersViewModel : EntityViewModel
    {
        /// <summary>
        /// username of the user
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// hashed password
        /// </summary>
        public string passwd { get; set; }
        /// <summary>
        /// User's email
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// User's name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// User's surname
        /// </summary>
        public string surname { get; set; }
        /// <summary>
        /// Groups that user belongs to.
        /// </summary>
        public virtual ICollection<GroupDetailsViewModel> GroupDetails { get; set; }
        /// <summary>
        /// Groups created by the user
        /// </summary>
        public virtual ICollection<GroupsViewModel> Groups { get; set; }
        /// <summary>
        /// User's years
        /// </summary>
        public virtual ICollection<YearsViewModel> Years { get; set; }
        /// <summary>
        /// User's grades
        /// </summary>
        public virtual ICollection<SubjectDetailsViewModel> SubjectDetails { get; set; }

        public override string ToString()
        {
            return username;
        }
    }
}
