using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}