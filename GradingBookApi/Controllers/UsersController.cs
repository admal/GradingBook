using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GradingBookProject.Models;
using GradingBookProject.ViewModels;

namespace GradingBookApi.Controllers
{
    public class UsersController : ApiController
    {
        private GradingBookDbEntities db = new GradingBookDbEntities();



        public IQueryable<UsersViewModel> GetUsers()
        {
            var users = db.Users.ProjectTo<UsersViewModel>();
            return users;
        }

        
        [ResponseType(typeof(UsersViewModel))]
        public async Task<IHttpActionResult> GetUsers(int id)
        {
            Users user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var retUser = Mapper.Map<UsersViewModel>(user);
            return Ok(retUser);
        }


        // PUT: api/Users/5

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsers(int id, UsersViewModel users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.id)
            {
                return BadRequest();
            }

            var userToEdit = await db.Users.FirstOrDefaultAsync(u => u.id == id);
            
            userToEdit.username = users.username;
            userToEdit.email = users.email;
            userToEdit.name = users.name;
            userToEdit.surname = users.surname;
            userToEdit.passwd = users.passwd;
            
            db.Entry(userToEdit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(UsersViewModel))]
        public async Task<IHttpActionResult> PostUsers(UsersViewModel users)
        {
            Users newUser = new Users()
            {
                name = users.name,
                surname = users.surname,
                username = users.username,
                email = users.email,
                passwd = users.passwd
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(newUser);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = users.id }, users);
        }

        

        [ResponseType(typeof(UsersViewModel))]
        public async Task<IHttpActionResult> DeleteUsers(int id)
        {
            Users users = await db.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            await db.SaveChangesAsync();

            var retUser = Mapper.Map<UsersViewModel>(users);

            return Ok(retUser);
        }

        [HttpGet]
        [ActionName("GetByUsername")]
        [ResponseType(typeof(UsersViewModel))]
        public async Task<IHttpActionResult> GetUserByUsername(string username )
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.username == username);
            if (user == null)
            {
                return NotFound();
            }
            var retUser = Mapper.Map<UsersViewModel>(user);
            return Ok(retUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.id == id) > 0;
        }



        #region old methods
        //// GET: api/Users/5
        //[ResponseType(typeof(Users))]
        //public async Task<IHttpActionResult> GetUsers(int id)
        //{
        //    Users users = await db.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(users);
        //}

        //// POST: api/Users
        //[ResponseType(typeof(Users))]
        //public async Task<IHttpActionResult> PostUsers(Users users)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Users.Add(users);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = users.id }, users);
        //}

        //// GET: api/Users
        //public IQueryable<Users> GetUsers()
        //{
        //    return db.Users;
        //}

        //[ResponseType(typeof(Users))]
        //public async Task<IHttpActionResult> DeleteUsers(int id)
        //{
        //    Users users = await db.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Users.Remove(users);
        //    await db.SaveChangesAsync();

        //    return Ok(users);
        //}

        //[HttpGet]
        //[ActionName("GetByUsername")]
        //[ResponseType(typeof(Users))]
        //public async Task<IHttpActionResult> GetUserByUsername(string username)
        //{
        //    var users = await db.Users.FirstOrDefaultAsync(u => u.username == username);
        //    if (users == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(users);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        #endregion
    }
}