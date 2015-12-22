using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Http;
using GradingBookProject.Models;
using GradingBookProject.Validation;


namespace GradingBookProject.Data
{
    /// <summary>
    /// Repository class for a Subject, contains all functions needed to manage a Subject.
    /// </summary>
    class HttpSubjectsRepository : HttpRepository<Subjects, HttpSubjectRequestService>
    {
        //private HttpSubjectRequestService requestService = new HttpSubjectRequestService();
        /// <summary>
        /// Gets all Subjects of a given user.
        /// </summary>
        /// <param name="year">Year of desired Subjects.</param>
        /// <returns>Subjects of a year.</returns>
        public async Task<IQueryable<Subjects>> GetSubjects(Years year)
        {
            return await requestService.GetSubjectsOfYear(year);
        }
    }
}
