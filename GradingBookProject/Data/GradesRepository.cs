using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject.Data
{
    class GradesRepository : IGradesRepository
    {
        private GradingBookDbEntities context;

        public GradesRepository() { 
            context = new GradingBookDbEntities();
        }

        public void AddGrade(SubjectDetails grade, int yearid, int subjectid)
        {
            /*  grade
             *  - subject_id
             *  - grade_id
             *  - grade_description
             *  - grade_weight
             *  - grade_date
             */
            if (context.Years.FirstOrDefault(y => y.id == yearid).Subjects.FirstOrDefault(s => s.id == subjectid) == null)
                throw new Exception("The Subject doesn't exist");
            
            context.Years.FirstOrDefault(y => y.id == yearid).Subjects.FirstOrDefault(s => s.id == subjectid).SubjectDetails.Add(grade);
            context.SaveChanges();
        }

        public IEnumerable<SubjectDetails> Grades(int yearid, int subjectid)
        {
            if (context.Years.FirstOrDefault(y => y.id == yearid) == null)
                throw new Exception("Such year doesn't exist!");
            else if (context.Years.FirstOrDefault(y => y.id == yearid).Subjects.FirstOrDefault(s => s.id == subjectid) == null)
                throw new Exception("Subject doesn't exist");

            return context.Years.FirstOrDefault(y => y.id == yearid).Subjects.FirstOrDefault(s => s.id == subjectid).SubjectDetails;
        }

        public void UpdateGrade(SubjectDetails grade, int yearid, int subjectid)
        {
            throw new NotImplementedException();
        }

        public void DeleteGrade(SubjectDetails grade, int yearid, int subjectid)
        {
            throw new NotImplementedException();
        }
    }
}
