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

        public YearListItem(string _name, int _id) 
        {
            name = _name;
            id = _id;
        }

        public int Id 
        {
            get { return id; }
        }

        public override string ToString()
        {
            return name;
        }

    }
}
