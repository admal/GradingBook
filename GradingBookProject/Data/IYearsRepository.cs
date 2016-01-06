using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Models;

namespace GradingBookProject.Data
{
    /// <summary>
    /// Iterface For CRUDs for repository of Years.
    /// </summary>
    public interface IYearsRepository 
    {
        /// <summary>
        /// Adds a Year to the database.
        /// </summary>
        /// <param name="year">Year to be added.</param>
        /// <param name="userid">User to whom the year belongs.</param>
        void AddYear(Years year, int userid);

       /// <summary>
       /// Returns the Years of a given user.
       /// </summary>
       /// <param name="userid">User to whom requested Years belong.</param>
       /// <returns></returns>
        IEnumerable<Years> Years(int userid);

        /// <summary>
        /// Returns single Year of given id
        /// </summary>
        /// <param name="yearid">Id of a requested year.</param>
        /// <returns></returns>
        Years Year(int yearid, int userid);

        /// <summary>
        /// Update the year in the database.
        /// </summary>
        /// <param name="year">values for the update.</param>
        void UpdateYear(Years year);

        /// <summary>
        /// Deletes a Year from a database
        /// </summary>
        /// <param name="year">year to be deleted.</param>
        /// <param name="userid">User to whom the Year belongs.</param>
        void DeleteYear(Years year, int userid);
    }
}
