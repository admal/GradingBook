using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject.Data
{
    public interface IYearsRepository 
    {
        /// <summary>
        /// adds a Year to the database
        /// </summary>
        /// <param name="year"></param>
        void AddYear(Years year, int userid);

        /// <summary>
        /// returns a list of all Years
        /// </summary>
        IEnumerable<Years> Years(int userid);

        /// <summary>
        /// Update the year in the database
        /// </summary>
        /// <param name="year">values for the update</param>
        void UpdateYear(Years year);

        /// <summary>
        /// deletes a Year from the database
        /// </summary>
        /// <param name="year">Year to be deleted</param>
        void DeleteYear(Years year, int userid);
    }
}
