using System.Linq;

namespace GradingBookProject.Data
{
    public interface IUsersRepository
    {
        IQueryable<Users> Users { get; }
    }
    }
}