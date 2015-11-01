using System.Linq;
namespace GradingBookProject.Data
{
    public class UsersRepository : IUsersRepository
    {
        private GradingBookDbEntities context = new GradingBookDbEntities(); //TODO: check if is possible to improve it

        public IQueryable<Users> Users
        {
            get { return context.Users; }
        }
    }
}