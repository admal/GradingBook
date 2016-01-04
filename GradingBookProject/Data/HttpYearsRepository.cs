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
    /// Repository class for a Year, contains all functions needed to manage a Year.
    /// </summary>
    class HttpYearsRepository : HttpRepository<YearsViewModel, HttpYearRequestService>
    {
        /// <summary>
        /// Gets all Years of a given user.
        /// </summary>
        /// <param name="username">Username of a desired user.</param>
        /// <returns></returns>
        public async Task<ICollection<YearsViewModel>> GetYears(string username) {
            return await requestService.GetYearsByUsername(username);
        }

        /// <summary>
        /// Gets all Years of a given Group ID.
        /// </summary>
        /// <param name="groupId">Group ID of a desired Group.</param>
        /// <returns>Collection of Years</returns>
        public async Task<ICollection<YearsViewModel>> GetYearsOfGroup(int groupId)
        {
            return await requestService.GetYearsByGroupId(groupId);
        }
    }
}
