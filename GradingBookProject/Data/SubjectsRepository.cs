using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GradingBookProject.Data
{
    public class SubjectsRepository : ISubjectsRepository
    {
        
        private GradingBookDbEntities context;

        public SubjectsRepository(/*GradingBookDbEntities _context*/) { 
            //context= _context;
            context = new GradingBookDbEntities();
        }

        public IEnumerable<Subjects> Subjects
        {
            get
            {
                return context.Subjects.ToArray();
            }
        }

        public void AddSubject(Subjects subject) {
            //add validation
            context.Subjects.Add(subject);
            context.SaveChanges();
        }

    }
}
