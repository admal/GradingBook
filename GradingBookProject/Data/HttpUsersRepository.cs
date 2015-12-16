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
        //private HttpUserRequestService requestService = new HttpUserRequestService();

        //public IQueryable<Users> Users
        //{
        //    get { return requestService.GetAll().Result.AsQueryable(); }
        //}

        //public async void AddUser(Users user)
        //{
        //    if(this.Users.FirstOrDefault(u => u.id==user.id) != null)
        //        throw new Exception("There is already such a user!");
        //     await requestService.PostOne(user);
        //}

        //public bool LoginUser(string username, string passwd)
        //{
        //    Users user = null;
        //    try
        //    {
        //        user = context.Users.FirstOrDefault(u => u.username == username);
        //        user = requestService
        //    }
        //    catch (Exception e)
        //    {

        //        System.Windows.Forms.MessageBox.Show("Unknnown error occured!");
        //    }


        //    if (user != null)
        //    {
        //        var en = new DataEncryptor();
        //        var encryptedPasswd = en.GetSha256String(passwd);
        //        if (user.passwd == encryptedPasswd)
        //        {
        //            Globals.CurrentUser = user;
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public bool userExists(string username)
        //{
        //    throw new NotImplementedException();
        //}

        //public void EditUser(Users user)
        //{
        //    throw new NotImplementedException();
        //}
        public IQueryable<Users> Users { get; }
        public void AddUser(Users user)
        {
            throw new NotImplementedException();
        }

        public bool LoginUser(string username, string passwd)
        {
            throw new NotImplementedException();
        }

        public bool userExists(string username)
        {
            throw new NotImplementedException();
        }

        public void EditUser(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
