using System.Linq;
using GradingBookProject.Models;
//using GradingBookApi.Models;

namespace GradingBookProject.Data
{
    public interface IUsersRepository
    {
        IQueryable<Users> Users { get; }
        /// <summary>
        /// Add user to the database
        /// </summary>
        /// <param name="user">New user</param>
        void AddUser(Users user);

        bool LoginUser(string username, string passwd);
        bool userExists(string username);
        void EditUser(Users user);
    }
    
}