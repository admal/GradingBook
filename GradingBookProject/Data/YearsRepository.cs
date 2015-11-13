using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject.Data
{
    public class YearsRepository : IYearsRepository
    {
        GradingBookDbEntities context;

        public YearsRepository()
        {
            context = new GradingBookDbEntities();
        }

        /// <summary>
        /// adds a Year to a database.
        /// </summary>
        /// <param name="year">Year to be added to a DB</param>
        public void AddYear(Years year)
        {
            context.Years.Add(year);
            context.SaveChanges();
        }

        /// <summary>
        /// return Years as a list (IEnumerable)
        /// </summary>
        public IEnumerable<Years> Years
        {
            get {
                return context.Years.ToList();       
            }
        }

        public void UpdateYear(Years year)
        {
            context.Years.FirstOrDefault(y => y.id == year.id).name = year.name;
            context.Years.FirstOrDefault(y => y.id == year.id).start = year.start;
            context.Years.FirstOrDefault(y => y.id == year.id).end_date = year.end_date;
            context.Years.FirstOrDefault(y => y.id == year.id).year_desc = year.year_desc;
            context.SaveChanges();
        }

        /// <summary>
        /// Deletes a given Year from a database (cascading).
        /// </summary>
        /// <param name="year">Year to be deleted from a DB</param>
        public void DeleteYear(Years year) 
        {
            context.Years.Remove(year);
            context.SaveChanges();
        }

    }
}
 