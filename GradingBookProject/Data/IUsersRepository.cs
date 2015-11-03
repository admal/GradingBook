using System.Linq;

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
    }
    
}