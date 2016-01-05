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

        /// <summary>
        /// Funciton updates currently logged user to have the same data as in databse.
        /// </summary>
        /// <returns></returns>
        public static async Task UpdateCurrentUser()
        {
            HttpUsersRepository repo = new HttpUsersRepository();
            CurrentUser = await repo.GetOne(CurrentUser.id);
        }
    }
}