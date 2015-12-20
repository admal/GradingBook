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
    class HttpYearsRepository
    {
        private HttpYearRequestService requestService = new HttpYearRequestService();

        public async Task<IQueryable<Years>> GetYears(string username) {
            return await requestService.GetYearsByUsername(username);
        }

        public async Task<Years> GetYear(int id) {
            var year = await requestService.GetOne(id);
            if( year == null)
                throw new Exception("Such year does not exist!");

            return year;
        }

        public async Task AddYear(Years year) { 
            if(await requestService.GetOne(year.id) != null)
                throw new Exception("There is already such a year!");
            await requestService.PostOne(year);
        }

        public async Task UpdateYear(Years year) { 
            if(await requestService.GetOne(year.id) == null)
                throw new Exception("Such year does not exist!");
            await requestService.UpdateOne(year.id, year);
        
        }

        public async Task DeleteYear(Years year){
            if(await requestService.GetOne(year.id) == null)
                throw new Exception("Such year does not exist!");
            await requestService.DeleteOne(year.id);
        }

    }
}
