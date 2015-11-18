using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject
{
    /// <summary>
    /// Class added to populate the Combo Box with name of the year and it's hidden ID.
    /// </summary>
    class YearListItem
    {
        private string name;
        private int id;
        /// <summary>
        /// Takes the name of the year and it's id.
        /// </summary>
        /// <param name="_name">Year name.</param>
        /// <param name="_id">Year id.</param>
        public YearListItem(string _name, int _id) 
        {
            name = _name;
            id = _id;
        }
        /// <summary>
        /// returns hidden Year id
        /// </summary>
        public int Id 
        {
            get { return id; }
        }
        /// <summary>
        /// Sets Year id.
        /// </summary>
        /// <param name="_name"></param>
        public void Name(string _name)
        {
            name = _name;
        }
        /// <summary>
        /// Returns Year name.
        /// </summary>
        /// <returns>Year name</returns>
        public override string ToString()
        {
            return name;
        }

    }
}
