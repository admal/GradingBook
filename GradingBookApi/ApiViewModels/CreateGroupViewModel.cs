using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradingBookApi.ApiViewModels
{
    public class CreateGroupViewModel
    {
        public string name { get; set; }
        public string ownerName { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
    }
}