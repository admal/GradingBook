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
    /// Repository class for a Year, contains all functions needed to manage a Year.
    /// </summary>
    class HttpYearsRepository : HttpRepository<YearsViewModel, HttpYearRequestService>
    {
        //private HttpYearRequestService requestService = new HttpYearRequestService();
        /// <summary>
        /// Gets all Years of a given user.
        /// </summary>
        /// <param name="username">Username of a desired user.</param>
        /// <returns></returns>
        public async Task<IQueryable<Years>> GetYears(string username) {
            return await requestService.GetYearsByUsername(username);
        }
    }
}
