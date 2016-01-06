using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject.Maths
{
    /// <summary>
    /// Comparator of objects, returning the value as type given to compare.
    /// </summary>
    public class Comparator
    {
        /// <summary>
        /// Takes two dates and compares them.
        /// </summary>
        /// <param name="firstDate">First date.</param>
        /// <param name="secondDate">Second date.</param>
        /// <returns>Returns the date that is later as DateTime object.</returns>
        public DateTime isLater(DateTime firstDate, DateTime secondDate) {
            int x = firstDate.CompareTo(secondDate);

            if (x < 0)
                return secondDate;
            else
                return firstDate;
        }
    }
}
