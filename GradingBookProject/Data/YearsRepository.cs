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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_context"></param>
        public YearsRepository()
        {
            context = new GradingBookDbEntities();
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
        /// <summary>
        /// adds a year to a database (not implemented yet)
        /// </summary>
        /// <param name="year"></param>
        public void AddYear(Years year)
        {
            context.Years.Add(year);
            context.SaveChanges();
        }


    }
}
