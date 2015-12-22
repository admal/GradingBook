using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Http;
using GradingBookProject.Models;

namespace GradingBookProject.Data
{
    public class HttpGroupsRepository : HttpRepository<Groups, HttpRequestService<Groups>>
    { 

    }
}
