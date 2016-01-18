using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions;
using GradingBookApi.ApiViewModels;
using GradingBookProject.ViewModels;
using GradingBookProject.Models;

namespace GradingBookApi.Controllers
{
    /// <summary>
    /// Api controller to manage operations on groups.
    /// </summary>
    [EnableCors(origins: "http://localhost:51849", headers: "*", methods: "*")]
    public class GroupsController : ApiController
    {
        /// <summary>
        /// databse context
        /// </summary>
        private GradingBookDbEntities db = new GradingBookDbEntities();

        // GET: api/Groups
        /// <summary>
        /// Get all groups from the database.
        /// </summary>
        /// <returns>Groups from db</returns>
        public IQueryable<GroupsViewModel> GetGroups()
        {
            var groups = db.Groups.ProjectTo<GroupsViewModel>();
            return groups;
        }

        // GET: api/Groups/5
        /// <summary>
        /// Get single group by id.
        /// </summary>
        /// <param name="id">id of the group</param>
        /// <returns>Group view model, not found response</returns>
        [ResponseType(typeof(GroupsViewModel))]
        public async Task<IHttpActionResult> GetGroups(int id)
        {
            Groups group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            var retGroup = Mapper.Map<GroupsViewModel>(group);
            return Ok(retGroup);
        }

        [ResponseType(typeof(ICollection<GroupsViewModel>))]
        [Route("api/groups/getbyusername/{username}")]
        public async Task<IHttpActionResult> GetGroupsByUsername(string username)
        {
            var owner = await db.Users.FirstAsync(u => u.username == username);
            var groups = db.Groups.Where(g => g.owner_id == owner.id);
            if (groups == null)
            {
                return NotFound();
            }
            var retGroup = groups.ProjectTo<GroupsViewModel>();
            return Ok(retGroup);
        }

        [ResponseType(typeof(ICollection<GroupsViewModel>))]
        [Route("api/groups/getusersgroups/{username}")]
        public async Task<IHttpActionResult> GetGroupsUserMember(string username)
        {
            var user = await db.Users.FirstAsync(u => u.username == username);
            //var groups = db.Groups.Where(g => g.owner_id == owner.id);
            var details = db.GroupDetails.Where(d => d.user_id == user.id);

            var groups = new List<Groups>();
            foreach (var detail in details)
            {
                groups.Add(detail.Groups);
            }

            var retGroup = groups.AsQueryable().ProjectTo<ShowGroupViewModel>();
            return Ok(retGroup);
        }

        // PUT: api/Groups/5
        /// <summary>
        /// Edits group with given id.
        /// </summary>
        /// <param name="id">id of the group</param>
        /// <param name="groups">edited group</param>
        /// <returns>Edited group view model, bad request, not found responses</returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGroups(int id, GroupsViewModel groups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groups.id)
            {
                return BadRequest();
            }

            var groupToEdit = await db.Groups.FirstOrDefaultAsync(g => g.id == id);

            groupToEdit.name = groups.name;
            groupToEdit.description= groups.description;
            groupToEdit.created_at = groups.created_at;
            groupToEdit.owner_id = groups.owner_id;

            db.Entry(groupToEdit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupsExists(id))
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

        // POST: api/Groups
        /// <summary>
        /// Add new group to the database.
        /// </summary>
        /// <param name="groups">Group to be added</param>
        /// <returns>Added group view model, bad request response.</returns>
        [ResponseType(typeof(GroupsViewModel))]
        public async Task<IHttpActionResult> PostGroups(GroupsViewModel groups)
        {
            Groups newGroup = new Groups()
            {
                name = groups.name,
                created_at = groups.created_at,
                description = groups.description,
                owner_id = groups.owner_id,
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Groups.Add(newGroup);
            await db.SaveChangesAsync();

            var retGroup = Mapper.Map<GroupsViewModel>(newGroup);
            return CreatedAtRoute("DefaultApi", new { id = newGroup.id }, retGroup);
        }

        /// <summary>
        /// Add new group to the database.
        /// </summary>
        /// <param name="groups">Group to be added (CreateGroupViewModel)</param>
        /// <returns>Added group view model, bad request response.</returns>
        [HttpPost]
        [ResponseType(typeof(GroupsViewModel))]
        [Route("api/groups/creategroup")]
        public async Task<IHttpActionResult> CreateGroup([FromBody]CreateGroupViewModel group)
        {
            var owner = await db.Users.FirstOrDefaultAsync(u => u.username == group.ownerName);
            if (owner == null)
                return BadRequest("User can not be found!");
            var newGroup = new Groups()
            {
                name = group.name,
                created_at = group.createdAt,
                description = group.description,
                owner_id = owner.id,
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Groups.Add(newGroup);
            await db.SaveChangesAsync();
            //add user to db
            newGroup.GroupDetails.Add(new GroupDetails()
            {
                user_id = owner.id,
                group_id = newGroup.id
            });
            await db.SaveChangesAsync();
            var retGroup = Mapper.Map<GroupsViewModel>(newGroup);
            return Ok(retGroup);
        }


        // DELETE: api/Groups/5
        /// <summary>
        /// Deletes group with given id.
        /// </summary>
        /// <param name="id">id of the group</param>
        /// <returns>Deleted group view model, not found response</returns>
        [ResponseType(typeof(GroupsViewModel))]
        public async Task<IHttpActionResult> DeleteGroups(int id)
        {
            Groups group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            db.Groups.Remove(group);
            await db.SaveChangesAsync();

            var retGroup = Mapper.Map<GroupsViewModel>(group);
            return Ok(retGroup);
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
        /// Checks whether specified group exists in the database.
        /// </summary>
        /// <param name="id">id of the group belongs</param>
        /// <returns>true - if there is such a group, false - otherwise</returns>
        private bool GroupsExists(int id)
        {
            return db.Groups.Count(e => e.id == id) > 0;
        }

        #region old methods
        //// GET: api/Groups
        //public IQueryable<Groups> GetGroups()
        //{
        //    return db.Groups;
        //}

        //// GET: api/Groups/5
        //[ResponseType(typeof(Groups))]
        //public async Task<IHttpActionResult> GetGroups(int id)
        //{
        //    Groups groups = await db.Groups.FindAsync(id);
        //    if (groups == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(groups);
        //}

        //// PUT: api/Groups/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutGroups(int id, Groups groups)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != groups.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(groups).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GroupsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Groups
        //[ResponseType(typeof(Groups))]
        //public async Task<IHttpActionResult> PostGroups(Groups groups)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Groups.Add(groups);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = groups.id }, groups);
        //}

        //// DELETE: api/Groups/5
        //[ResponseType(typeof(Groups))]
        //public async Task<IHttpActionResult> DeleteGroups(int id)
        //{
        //    Groups groups = await db.Groups.FindAsync(id);
        //    if (groups == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Groups.Remove(groups);
        //    await db.SaveChangesAsync();

        //    return Ok(groups);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool GroupsExists(int id)
        //{
        //    return db.Groups.Count(e => e.id == id) > 0;
        //}
        #endregion
    }
}