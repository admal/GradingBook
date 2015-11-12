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
        void AddYear(Years year);

        /// <summary>
        /// returns a list of all Years
        /// </summary>
        IEnumerable<Years> Years { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        void UpdateYear(Years year);

        /// <summary>
        /// deletes a Year from the database
        /// </summary>
        /// <param name="year"></param>
        void DeleteYear(Years year);
    }
}
