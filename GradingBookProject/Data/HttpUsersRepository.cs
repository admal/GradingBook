using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Http;
using GradingBookProject.Models;

namespace GradingBookProject.Data
{
    class HttpUsersRepository : IUsersRepository
    {
        private HttpRequestService<Users> requestService = new HttpRequestService<Users>();

        public IQueryable<Users> Users
        {
            get { return requestService.GetAll().Result.AsQueryable(); }
        }

        public async void AddUser(Users user)
        {
            if(this.Users.FirstOrDefault(u => u.id==user.id) != null)
                throw new Exception("There is already such a user!");
             await requestService.PostOne(user);
        }

    }
}
