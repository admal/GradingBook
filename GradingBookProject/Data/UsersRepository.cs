using System;
using System.Collections.Generic;
using System.Linq;
using GradingBookProject.Models;
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
            Users user = null;
            try
            {
               user = context.Users.FirstOrDefault(u => u.username == username);
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
        /// <summary>
        /// Checks if user with given username already exists
        /// </summary>
        /// <param name="username">user name to check</param>
        /// <returns>true - if alredy exists</returns>
        public bool userExists(string username)
        {
            var user = context.Users.FirstOrDefault(u => u.username == username);
            return user != null;
        }
        /// <summary>
        /// Edit given user.
        /// </summary>
        /// <param name="user">New user's credentials</param>
        public void EditUser(Users user)
        {
            var userToEdit = context.Users.FirstOrDefault(u => u.id == user.id);

            if(userToEdit == null) throw new Exception("Error: no such a user!");

            userToEdit.name = user.name;
            userToEdit.surname = user.surname;
            userToEdit.email = user.email;
            userToEdit.passwd = user.passwd;
            userToEdit.username = user.username;

            context.SaveChanges();
        }

    }
}