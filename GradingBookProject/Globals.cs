using System.Threading.Tasks;
using GradingBookProject.Data;
using GradingBookProject.Models;
using GradingBookProject.ViewModels;

namespace GradingBookProject
{
    /// <summary>
    /// Global variables
    /// </summary>
    public static class Globals
    {
        /// <summary>
        /// Currently logged user
        /// </summary>
        //public static Users  CurrentUser { get; set; }
        public static UsersViewModel CurrentUser { get; set; }

        public static async Task<bool> UpdateCurrentUser()
        {
            HttpUsersRepository repo = new HttpUsersRepository();
            CurrentUser = await repo.GetOne(CurrentUser.id);
            return true;
        }
    }
}