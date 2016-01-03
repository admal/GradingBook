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
        public async Task<IQueryable<SubjectDetailsViewModel>> GetSubjectDetails(SubjectsViewModel subject)
        {
            return await requestService.GetSubjectDetailsOfSubject(subject);
        }
        
        /// <summary>
        /// Updates a given Grade. Overrides base.EditOne()
        /// </summary>
        /// <param name="grade">Grade to be updated</param>
        /// <returns></returns>
        public new async Task EditOne(SubjectDetailsViewModel grade)
        {
            if (await requestService.GetOne(grade.id) == null)
                throw new Exception("Such grade does not exist!");

            await requestService.UpdateOne(grade.id, new SubjectDetailsViewModel
            {
                id = grade.id,
                sub_id = grade.sub_id,
                grade_weight = grade.grade_weight,
                //Subjects = null,
                grade_date = grade.grade_date,
                grade_desc = grade.grade_desc,
                grade_value = grade.grade_value
            });
        }
    }
}
