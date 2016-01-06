using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject.Maths
{
    public class Comparator
    {
        public DateTime isLater(DateTime firstYear, DateTime secondYear) {
            int x = firstYear.CompareTo(secondYear);

            if (x < 0)
                return secondYear;
            else
                return firstYear;
        }
    }
}
