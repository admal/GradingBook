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
    class HttpSubjectsRepository
    {
        private HttpSubjectRequestService requestService = new HttpSubjectRequestService();
        /// <summary>
        /// Gets all Subjects of a given user.
        /// </summary>
        /// <param name="year">Year of desired Subjects.</param>
        /// <returns>Subjects of a year.</returns>
        public async Task<IQueryable<Subjects>> GetSubjects(Years year)
        {
            return await requestService.GetSubjectsOfYear(year);
        }
        /// <summary>
        /// Gets a Subject year of a given id.
        /// </summary>
        /// <param name="id">Id of a Subject you want</param>
        /// <returns>Subject</returns>
        public async Task<Subjects> GetSubject(int id)
        {
            var subject = await requestService.GetOne(id);
            if (subject == null)
                throw new Exception("Such subject does not exist!");

            return subject;
        }
        /// <summary>
        /// Adds a Subject.
        /// </summary>
        /// <param name="subject">Subject to be added.</param>
        /// <returns></returns>
        public async Task AddSubject(Subjects subject)
        {
            if (await requestService.GetOne(subject.id) != null)
                throw new Exception("There is already such a subject!");
            await requestService.PostOne(subject);
        }
        /// <summary>
        /// Updates a given Subject.
        /// </summary>
        /// <param name="subject">Subject to be updated</param>
        /// <returns></returns>
        public async Task UpdateSubject(Subjects subject)
        {
            if (await requestService.GetOne(subject.id) == null)
                throw new Exception("Such subject does not exist!");
            await requestService.UpdateOne(subject.id, subject);
        }
        /// <summary>
        /// Deletes a given Subject.
        /// </summary>
        /// <param name="subject">Subject to be deleted.</param>
        /// <returns></returns>
        public async Task DeleteSubject(Subjects subject)
        {
            if (await requestService.GetOne(subject.id) == null)
                throw new Exception("Such subject does not exist!");
            await requestService.DeleteOne(subject.id);
        }
    }
}
