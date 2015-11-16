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

        public void AddGrade(SubjectDetails grade)
        {
            context.SubjectDetails.Add(grade);
            context.SaveChanges();
        }

        public SubjectDetails GetGrade(int gradeID)
        {
            return context.SubjectDetails.FirstOrDefault(g => g.id == gradeID);
        }
        public IEnumerable<SubjectDetails> SubjectGrades(int subjectid)
        {

            var sub = context.Subjects.FirstOrDefault(s => s.id == subjectid);
            IEnumerable<SubjectDetails> grades = null;
            if (sub != null)
                grades = sub.SubjectDetails;

            return grades;
        }

        public void UpdateGrade(SubjectDetails grade)
        {
            var g = context.SubjectDetails.FirstOrDefault(gr => gr.id == grade.id);
            if (g != null)
            {
                g.grade_value = grade.grade_value;
                g.grade_weight = grade.grade_weight;
                g.grade_desc = g.grade_desc;
                g.grade_date = g.grade_date;
                context.SaveChanges();
            }
        }

        public void DeleteGrade(SubjectDetails grade)
        {
            context.SubjectDetails.Remove(grade);
            context.SaveChanges();
        }
    }
}
