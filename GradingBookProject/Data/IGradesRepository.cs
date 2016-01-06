using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Models;

namespace GradingBookProject.Data
{
    /// <summary>
    /// Interface of GradesRepository
    /// </summary>
    interface IGradesRepository
    {
        /// <summary>
        /// Adds a Grade for a given subject.
        /// </summary>
        /// <param name="grade">Grade to be added.</param>
        /// <param name="yearid">Year on which the subject is.</param>
        /// <param name="subjectid">Subject to which we add the grade.</param>
        void AddGrade(SubjectDetails grade);
        /// <summary>
        /// Lists SubjectGrades from a given subject
        /// </summary>
        /// <param name="yearid">Year on which the subject is.</param>
        /// <param name="subjectid">Subject for which the grades are requested.</param>
        /// <returns></returns>
        IEnumerable<SubjectDetails> SubjectGrades(int subjectid);
        /// <summary>
        /// Updates a given Grade.
        /// </summary>
        /// <param name="grade">Grade to be updated.</param>
        /// <param name="yearid">Year on which a subject is.</param>
        /// <param name="subjectid">Subject for which we upgrade a grade.</param>
        void UpdateGrade(SubjectDetails grade);

        /// <summary>
        /// Deletes a grade from a database
        /// </summary>
        /// <param name="grade">Grade to be deleted.</param>
        /// <param name="yearid">year on which the subject is.</param>
        /// <param name="subjectid">Subject for which we delete a grade.</param>
        void DeleteGrade(SubjectDetails grade);

        /// <summary>
        /// Get grade with provided id
        /// </summary>
        /// <param name="gradeId">id of grade</param>
        /// <returns>Grade object with id gradeId or null if grade was not found</returns>
        SubjectDetails GetGrade(int gradeId);
    }
}
