using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject.Data
{
    public interface ISubjectsRepository
    {
        /// <summary>
        /// Add a subject for a given user.
        /// </summary>
        /// <param name="subject">Subject to be added.</param>
        /// <param name="yearid">Year(of a User) to which it belongs.</param>
        void AddSubject(Subjects subject, int yearid);
        /// <summary>
        /// List Subjects for a given year.
        /// </summary>
        /// <param name="yearid">Year of subjects.</param>
        /// <returns></returns>
        IEnumerable<Subjects> Subjects(int yearid);
        /// <summary>
        /// Update given subject's record in a database.
        /// </summary>
        /// <param name="subject">Subject to be updated.</param>
        /// <param name="yearid">Year(of a user) from which we delete the year.</param>
        void UpdateSubject(Subjects subject, int yearid);
        /// <summary>
        /// Delete the given subject
        /// </summary>
        /// <param name="subject">Subject to be deleted.</param>
        /// <param name="yearid">Year(of a user) to which subject belongs.</param>
        void DeleteSubject(Subjects subject, int yearid);

    }
}
