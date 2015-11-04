using System;
using System.Collections.Generic;
using System.Linq;
using GradingBookProject.Validation;
using Ninject.Infrastructure.Language;

namespace GradingBookProject.Data
{
    public class UsersRepository : IUsersRepository
    {

        //TODO: check if is possible to improve it
        //private GradingBookDbEntities context = new GradingBookDbEntities();

        private GradingBookDbEntities context = new GradingBookDbEntities();

        //public UsersRepository(IGbUnitOfWork _context)
        //{
        //    context = _context;
        //}

        public IQueryable<Users> Users
        {
            get { return context.Users; }
        }

        public void AddUser(Users user)
        {
            if (context.Users.FirstOrDefault(u => u.username == user.username) != null)
                throw new Exception("There is already such a user!");
            
            context.Users.Add(user);
            context.SaveChanges();
        }

        public bool LoginUser(string username, string passwd)
        {
            var user = context.Users.FirstOrDefault(u => u.username == username);

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

    }
}