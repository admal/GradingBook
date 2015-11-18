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

        public void AddYear(Years year, int userid)
        {
            if (context.Users.FirstOrDefault(u => u.id == userid).Years.FirstOrDefault(y => y.id == year.id) != null)
                throw new Exception("Such Year already exists!");

            context.Users.FirstOrDefault(u => u.id == userid).Years.Add(year);
            context.SaveChanges();
        }

        public IEnumerable<Years> Years(int userid)
        {
            return context.Users.FirstOrDefault(u => u.id == userid).Years;
        }

        public Years Year(int yearid, int userid)
        {
            if (context.Users.FirstOrDefault(u => u.id == userid).Years.FirstOrDefault(y => y.id == yearid) == null)
                throw new Exception("Such year does not exist!");

            return context.Users.FirstOrDefault(u => u.id == userid).Years.FirstOrDefault(y => y.id == yearid); 
        }

        public void UpdateYear(Years year)
        {
            if (context.Years.FirstOrDefault(y => y.id == year.id) == null)
                throw new Exception("Such year does not exist!");
            
            context.Years.FirstOrDefault(y => y.id == year.id).name = year.name;
            context.Years.FirstOrDefault(y => y.id == year.id).start = year.start;
            context.Years.FirstOrDefault(y => y.id == year.id).end_date = year.end_date;
            context.Years.FirstOrDefault(y => y.id == year.id).year_desc = year.year_desc;
            context.SaveChanges();
        }   

        public void DeleteYear(Years year, int userid) 
        {
            if (context.Users.FirstOrDefault(u => u.id == userid).Years.FirstOrDefault(y => y.id == year.id) == null)
                throw new Exception("Such year doesn't exist!");

            context.Years.Remove(context.Users.FirstOrDefault(u => u.id == userid).Years.FirstOrDefault(y => y.id == year.id));
            context.SaveChanges();
        }


    }
}
 