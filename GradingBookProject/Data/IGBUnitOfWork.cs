using System.Data.Entity;

namespace GradingBookProject.Data
{
    public interface IGbUnitOfWork
    {

        IDbSet<Grades> Grades { get; }
        IDbSet<Subjects> Subjects { get; }
        IDbSet<Users> Users { get; }
        IDbSet<Years> Years { get; }

    }
}