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
    /// Repository class for Grades, contains all functions needed to manage a Grade.
    /// </summary>
    class HttpSubjectDetailsRepository
    {
        private HttpSubjectDetailsRequestService requestService = new HttpSubjectDetailsRequestService();
        /// <summary>
        /// Gets all Grades of a given Subject.
        /// </summary>
        /// <param name="subject">Subject we take grades from.</param>
        /// <returns>SubjectDetails of a year.</returns>
        public async Task<IQueryable<SubjectDetails>> GetSubjectDetails(Subjects subject)
        {
            return await requestService.GetSubjectDetailsOfSubject(subject);
        }
        /// <summary>
        /// Gets a Grade of a given id.
        /// </summary>
        /// <param name="id">Id of a Grade wanted</param>
        /// <returns>Subject</returns>
        public async Task<SubjectDetails> GetSubjectDetail(int id)
        {
            var grade = await requestService.GetOne(id);
            if (grade == null)
                throw new Exception("Such grade does not exist!");

            return grade;
        }
        /// <summary>
        /// Adds a Grade.
        /// </summary>
        /// <param name="grade">Grade to be added.</param>
        /// <returns></returns>
        public async Task AddSubjectDetail(SubjectDetails grade)
        {
            if (await requestService.GetOne(grade.id) != null)
                throw new Exception("There is already such a grade!");
            await requestService.PostOne(grade);
        }
        /// <summary>
        /// Updates a given Grade.
        /// </summary>
        /// <param name="grade">Grade to be updated</param>
        /// <returns></returns>
        public async Task UpdateSubjectDetail(SubjectDetails grade)
        {
            if (await requestService.GetOne(grade.id) == null)
                throw new Exception("Such grade does not exist!");

            await requestService.UpdateOne(grade.id, new SubjectDetails { id = grade.id, sub_id = grade.sub_id, grade_weight = grade.grade_weight, Subjects = null, grade_date = grade.grade_date, grade_desc = grade.grade_desc, grade_value = grade.grade_value });
        }
        /// <summary>
        /// Deletes a given Grade.
        /// </summary>
        /// <param name="grade">Grade to be deleted.</param>
        /// <returns></returns>
        public async Task DeleteSubjectDetail(SubjectDetails grade)
        {
            if (await requestService.GetOne(grade.id) == null)
                throw new Exception("Such grade does not exist!");
            await requestService.DeleteOne(grade.id);
        }
    }
}
