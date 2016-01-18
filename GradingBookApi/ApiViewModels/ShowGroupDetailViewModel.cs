using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradingBookApi.ApiViewModels
{
    public class ShowGroupDetailViewModel
    {
        public string username { get; set; }
        public int user_id { get; set; }
        public int group_id { set; get; }
    }
}