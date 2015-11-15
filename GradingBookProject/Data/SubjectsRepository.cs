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

        public SubjectsRepository() { 
            context = new GradingBookDbEntities();
        }

        public void AddSubject(Subjects subject, int yearid)
        {
            if ((context.Years.FirstOrDefault(y => y.id == yearid).Subjects.FirstOrDefault(s => s.id == subject.id) != null) || (context.Years.FirstOrDefault(y => y.id == yearid).Subjects.FirstOrDefault(s => s.name == subject.name) != null))
                throw new Exception("Such Subject already exists!");
         
            context.Years.FirstOrDefault(y => y.id == yearid).Subjects.Add(subject);
            context.SaveChanges();
        }

        public IEnumerable<Subjects> Subjects(int yearid)
        {
            if (context.Years.FirstOrDefault(y => y.id == yearid) == null)
                throw new Exception("Year doesn't exist!");

            return context.Years.FirstOrDefault(y => y.id == yearid).Subjects;
        }

        public Subjects Subject(int yearid, int subjectid) { 
            if(context.Years.FirstOrDefault(y => y.id == yearid).Subjects.FirstOrDefault(s => s.id == subjectid) == null)
                throw new Exception("Year doesn't exist!");

            return context.Years.FirstOrDefault(y => y.id == yearid).Subjects.FirstOrDefault(s => s.id == subjectid);
        }

        public void UpdateSubject(Subjects subject, int yearid)
        {
            if (context.Years.FirstOrDefault(y => y.id == yearid).Subjects.FirstOrDefault(s => s.id == subject.id) == null)
                throw new Exception("Subject doesn't exist!");

            //Checking if the subject with such a name already exists if yes throw an Exception
            var subjects = context.Years.FirstOrDefault(y => y.id == yearid).Subjects;
            var repeatedSubjects = subjects.Where(s => s.name == subject.name);
            if(repeatedSubjects.FirstOrDefault(s => s.id != subject.id) != null)
                throw new Exception("Subject with such name already exist!");

            context.Years.FirstOrDefault(y => y.id == yearid).Subjects.FirstOrDefault(s => s.id ==subject.id).name = subject.name;
            context.Years.FirstOrDefault(y => y.id == yearid).Subjects.FirstOrDefault(s => s.id == subject.id).sub_desc = subject.sub_desc;
            context.Years.FirstOrDefault(y => y.id == yearid).Subjects.FirstOrDefault(s => s.id == subject.id).SubjectDetails = subject.SubjectDetails;
            context.Years.FirstOrDefault(y => y.id == yearid).Subjects.FirstOrDefault(s => s.id == subject.id).teacher_mail = subject.teacher_mail;
            context.SaveChanges();
        }

        public void DeleteSubject(Subjects subject, int yearid)
        {
            if (context.Years.FirstOrDefault(y => y.id == yearid).Subjects.FirstOrDefault(s => s.id == subject.id) == null)
                throw new Exception("Such subject doesn't exist");

            context.Subjects.Remove(context.Years.FirstOrDefault(y => y.id == yearid).Subjects.FirstOrDefault(s => s.id == subject.id));
            context.SaveChanges();
        }
    }
}
