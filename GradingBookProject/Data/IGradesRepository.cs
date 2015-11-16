using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject.Data
{
    interface IGradesRepository
    {
        /// <summary>
        /// Adds a Grade for a given subject.
        /// </summary>
        /// <param name="grade">Grade to be added.</param>
        /// <param name="yearid">Year on which the subject is.</param>
        /// <param name="subjectid">Subject to which we add the grade.</param>
        void AddGrade(SubjectDetails grade, int yearid, int subjectid);
        /// <summary>
        /// Lists Grades from a given subject
        /// </summary>
        /// <param name="yearid">Year on which the subject is.</param>
        /// <param name="subjectid">Subject for which the grades are requested.</param>
        /// <returns></returns>
        IEnumerable<SubjectDetails> Grades(int subjectid);
        /// <summary>
        /// Updates a given Grade.
        /// </summary>
        /// <param name="grade">Grade to be updated.</param>
        /// <param name="yearid">Year on which a subject is.</param>
        /// <param name="subjectid">Subject for which we upgrade a grade.</param>
        void UpdateGrade(SubjectDetails grade, int yearid, int subjectid);
        /// <summary>
        /// Deletes a grade from a database
        /// </summary>
        /// <param name="grade">Grade to be deleted.</param>
        /// <param name="yearid">year on which the subject is.</param>
        /// <param name="subjectid">Subject for which we delete a grade.</param>
        void DeleteGrade(SubjectDetails grade, int yearid, int subjectid);


    }
}
