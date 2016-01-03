using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Http;
using GradingBookProject.Models;
using GradingBookProject.Validation;
using GradingBookProject.ViewModels;

namespace GradingBookProject.Data
{
    /// <summary>
    /// Repository class for Grades, contains all functions needed to manage a Grade.
    /// </summary>
    class HttpSubjectDetailsRepository : HttpRepository<SubjectDetailsViewModel, HttpSubjectDetailsRequestService>
    {
       // private HttpSubjectDetailsRequestService requestService = new HttpSubjectDetailsRequestService();
        /// <summary>
        /// Gets all Grades of a given Subject.
        /// </summary>
        /// <param name="subject">Subject we take grades from.</param>
        /// <returns>SubjectDetails of a year.</returns>
        public async Task<ICollection<SubjectDetailsViewModel>> GetSubjectDetails(SubjectsViewModel subject)
        {
            return await requestService.GetSubjectDetailsOfSubject(subject);
        }
    }
}
