using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Http;
using GradingBookProject.Models;
using GradingBookProject.ViewModels;

namespace GradingBookProject.Data
{
    public class HttpGroupsRepository : HttpRepository<GroupsViewModel, HttpRequestService<GroupsViewModel>>
    { 

    }
}
