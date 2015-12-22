using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingBookProject.Models
{
    /// <summary>
    /// Base class for every database entity.
    /// </summary>
    public class DataEntity
    {
        /// <summary>
        /// Id of the entity in the database.
        /// </summary>
        public int id { get; set; }
    }
}
