using System.Linq;
namespace GradingBookProject.Data
{
    public class UsersRepository : IUsersRepository
    {

        //TODO: check if is possible to improve it
        //private GradingBookDbEntities context = new GradingBookDbEntities();

        private IGbUnitOfWork context;

        public UsersRepository(IGbUnitOfWork _context)
        {
            context = _context;
        }

        public IQueryable<Users> Users
        {
            get { return context.Users; }
        }
    }
}