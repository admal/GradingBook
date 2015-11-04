using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject.Data
{
    public interface ISubjectsRepository
    {
        //IQueryable<Subjects> Subjects { get; }
        IEnumerable<Subjects> Subjects { get; }
        void AddSubject(Subjects subject);

    }
}
