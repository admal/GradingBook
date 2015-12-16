using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradingBookProject.Http;
using GradingBookProject.Models;
using GradingBookProject.Validation;

namespace GradingBookProject.Data
{
    class HttpUsersRepository : IUsersRepository
    {
        private HttpUserRequestService requestService = new HttpUserRequestService();

        public IQueryable<Users> Users
        {
            get { return requestService.GetAll().Result.AsQueryable(); }
        }

        public async void AddUser(Users user)
        {
            if (this.Users.FirstOrDefault(u => u.id == user.id) != null)
                throw new Exception("There is already such a user!");
            await requestService.PostOne(user);
        }

        public bool LoginUser(string username, string passwd)
        {
            Users user = null;
            try
            {
                user = requestService.GetUserByUsername(username).Result;
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show("Unknnown error occured!");
            }


            if (user != null)
            {
                var en = new DataEncryptor();
                var encryptedPasswd = en.GetSha256String(passwd);
                if (user.passwd == encryptedPasswd)
                {
                    Globals.CurrentUser = user;
                    return true;
                }
            }
            return false;
        }

        public bool userExists(string username)
        {
            var user = requestService.GetUserByUsername(username).Result;
            return user != null;
        }

        public async void EditUser(Users user)
        {
            await requestService.UpdateOne(user.id, user);
        }

    }
}
