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
    class HttpYearsRepository
    {
        private HttpYearRequestService requestService = new HttpYearRequestService();
        /// <summary>
        /// Gets all Years of a given user.
        /// </summary>
        /// <param name="username">Username of a desired user.</param>
        /// <returns>IQueryable<Years></returns>
        public async Task<IQueryable<Years>> GetYears(string username) {
            return await requestService.GetYearsByUsername(username);
        }
        /// <summary>
        /// Gets a single year of a given id.
        /// </summary>
        /// <param name="id">Id of a year you want</param>
        /// <returns></returns>
        public async Task<Years> GetYear(int id) {
            var year = await requestService.GetOne(id);
            if( year == null)
                throw new Exception("Such year does not exist!");

            return year;
        }
        /// <summary>
        /// Adds a year.
        /// </summary>
        /// <param name="year">Year to be added.</param>
        /// <returns></returns>
        public async Task AddYear(Years year) { 
            if(await requestService.GetOne(year.id) != null)
                throw new Exception("There is already such a year!");
            await requestService.PostOne(year);
        }
        /// <summary>
        /// Updates a given Year.
        /// </summary>
        /// <param name="year">Year to be updated</param>
        /// <returns></returns>
        public async Task UpdateYear(Years year) { 
            if(await requestService.GetOne(year.id) == null)
                throw new Exception("Such year does not exist!");
            await requestService.UpdateOne(year.id, year);
        
        }
        /// <summary>
        /// Deletes a given Year.
        /// </summary>
        /// <param name="year">Year to be deleted.</param>
        /// <returns></returns>
        public async Task DeleteYear(Years year){
            if(await requestService.GetOne(year.id) == null)
                throw new Exception("Such year does not exist!");
            await requestService.DeleteOne(year.id);
        }

    }
}
