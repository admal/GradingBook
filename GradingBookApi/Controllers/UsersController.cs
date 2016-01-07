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
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GradingBookProject.Models;
using GradingBookProject.ViewModels;

namespace GradingBookApi.Controllers
{
    /// <summary>
    /// Api controller to manage operations on groups.
    /// </summary>
    [EnableCors(origins: "http://localhost:51849", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        /// <summary>
        /// databse context
        /// </summary>
        private GradingBookDbEntities db = new GradingBookDbEntities();

        /// <summary>
        /// Get all users from the database.
        /// </summary>
        /// <returns>Groups from db</returns>
        public IQueryable<UsersViewModel> GetUsers()
        {
            var users = db.Users.ProjectTo<UsersViewModel>();
            return users;
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">id of user</param>
        /// <returns>Single user with the given id, not found response</returns>
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

        // GET: api/users/getbygroupid/4
        /// <summary>
        /// Gets users of a group.
        /// </summary>
        /// <param name="id">group we want users of.</param>
        /// <returns>Collection of users of a group view models / null.</returns>
        [HttpGet]
        [Route("api/users/getbygroupid/{id:int}")]
        [ActionName("getbygroupid")]
        public async Task<ICollection<UsersViewModel>> GetUsersOfGroup(int id)
        {

            var group = await db.Groups.FirstOrDefaultAsync(g => g.id == id);
            if (group == null)
                return null;

            var gds = group.GroupDetails;

            if (gds == null)
                return null;

            List<Users> users = new List<Users>();
            foreach (var gd in gds) {
                users.Add(gd.Users);
            }

            return users.AsQueryable().ProjectTo<UsersViewModel>().ToList();

        }

        // PUT: api/Users/5
        /// <summary>
        /// Edits user with given id.
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="users">edited user</param>
        /// <returns>Edited user view model, bad request, not found responses</returns>
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
        /// <summary>
        /// Adds new user to db.
        /// </summary>
        /// <param name="users">User to be added</param>
        /// <returns>Added user view model, bad request response.</returns>
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


        /// <summary>
        /// Deletes user with given id.
        /// </summary>
        /// <param name="id">id of the user</param>
        /// <returns>Deleted user view model, not found response</returns>
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

        /// <summary>
        /// Finds user with the given username.
        /// </summary>
        /// <param name="username">username of searched user</param>
        /// <returns>User view model with the given username, not found response</returns>
        [HttpGet]
        [ActionName("GetByUsername")]
        [ResponseType(typeof(UsersViewModel))]
        public async Task<UsersViewModel> GetUserByUsername(string username )
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.username == username);
            if (user == null)
            {
                return null;
            }
            var retUser = Mapper.Map<UsersViewModel>(user);
            return retUser;
        }
        /// <summary>
        /// Close connection to the database.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// Checks whether specified user exists in the database.
        /// </summary>
        /// <param name="id">id of the user </param>
        /// <returns>true - if there is such a user, false - otherwise</returns>
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