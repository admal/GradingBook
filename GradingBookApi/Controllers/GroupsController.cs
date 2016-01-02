using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GradingBookProject.ViewModels;
using GradingBookProject.Models;

namespace GradingBookApi.Controllers
{
    public class GroupsController : ApiController
    {
        private GradingBookDbEntities db = new GradingBookDbEntities();

        // GET: api/Groups
        public IQueryable<GroupsViewModel> GetGroups()
        {
            var groups = db.Users.ProjectTo<GroupsViewModel>();
            return groups;
        }

        // GET: api/Groups/5
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

        // PUT: api/Groups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGroups(int id, Groups groups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groups.id)
            {
                return BadRequest();
            }

            db.Entry(groups).State = EntityState.Modified;

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
            //TODO: ADD group details

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Groups.Add(newGroup);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = groups.id }, groups);
        }

        // DELETE: api/Groups/5
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

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