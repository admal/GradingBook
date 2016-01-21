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
using AutoMapper.QueryableExtensions;
using GradingBookProject.Models;
using GradingBookProject.ViewModels;

namespace GradingBookApi.Controllers
{
    /// <summary>
    /// Api controller to manage operations on GroupDetails (they are members of the group)
    /// </summary>
    [EnableCors(origins: "http://localhost:51849", headers: "*", methods: "*")]
    public class GroupDetailsController : ApiController
    {
        /// <summary>
        /// databse context
        /// </summary>
        private GradingBookDbEntities db = new GradingBookDbEntities();

        /// <summary>
        /// Checks whether specified detail exists in the database.
        /// </summary>
        /// <param name="groupId">id of the group to which detail belongs</param>
        /// <param name="userId">id of user in the group</param>
        /// <returns>true - if there is such a detail, false - otherwise</returns>
        [HttpGet]
        [ActionName("DetailExists")]
        public async Task<bool> DetailExists(int groupId, int userId )
        {
            bool exists = (await db.GroupDetails.FirstOrDefaultAsync(d => d.group_id == groupId && d.user_id == userId) != null);
            return exists;
        }
        /// <summary>
        /// Removes detail with specyfied user and group.
        /// </summary>
        /// <param name="groupId">id of the group to which detail belongs</param>
        /// <param name="userId">id of user in the group</param>
        /// <returns>Removed detail. Not found call if there was not such detail.</returns>
        [HttpGet]
        [ActionName("RemoveDetail")]
        public async Task<IHttpActionResult> RemoveDetail(int groupId, int userId)
        {
            var detail = await db.GroupDetails.FirstOrDefaultAsync(d => d.group_id == groupId && d.user_id == userId);
            if (detail == null)
            {
                return NotFound();
            }
            db.GroupDetails.Remove(detail);
            await db.SaveChangesAsync();
            return Ok(detail);
        }
        /// <summary>
        /// Removes detail with specyfied user and group.
        /// </summary>
        /// <param name="groupId">id of the group to which detail belongs</param>
        /// <param name="username">id of user in the group</param>
        /// <returns>Removed detail. Not found call if there was not such detail.</returns>
        [HttpDelete]
        [ActionName("RemoveDetailByUsername")]
        [Route("api/GroupDetails/RemoveDetailByUsername/{groupId:int}/{username}")]
        public async Task<IHttpActionResult> RemoveDetailByUsername(int groupId, string username)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.username == username);
            if (user == null)
            {
                return BadRequest("User does not exist!");
            }
            var detail = await db.GroupDetails.FirstOrDefaultAsync(d => d.group_id == groupId && d.user_id == user.id);
            if (detail == null)
            {
                return NotFound();
            }
            db.GroupDetails.Remove(detail);
            await db.SaveChangesAsync();
            return Ok(detail);
        }

        /// <summary>
        /// Get all groupdetails for the user with id
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>list of groupdetails for given user</returns>
        [HttpGet]
        [ActionName("GetGroupDetailsForUser")]
        [Route("api/GroupDetails/GetGroupDetailsForUser/{id:int}")]
        public async Task<ICollection<GroupDetailsViewModel>> GetGroupDetailsForUser(int id)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.id == id);
            if (user == null)
                return null;
            var details = user.GroupDetails.AsQueryable().ProjectTo<GroupDetailsViewModel>().ToList();
            return details;
        }

        /// <summary>
        /// Get all groupdetails for the group with id
        /// </summary>
        /// <param name="id">group id</param>
        /// <returns>list of groupdetails for given group</returns>
        [HttpGet]
        [ActionName("GetGroupDetailsForGroup")]
        [Route("api/GroupDetails/GetGroupDetailsForGroup/{id:int}")]
        public async Task<ICollection<GroupDetailsViewModel>> GetGroupDetailsForGroup(int id)
        {
            var group = await db.Groups.FirstOrDefaultAsync(g => g.id == id);
            if (group == null)
                return null;
            var details = group.GroupDetails.AsQueryable().ProjectTo<GroupDetailsViewModel>().ToList();
            return details;
        }

        
        // GET: api/GroupDetails
        /// <summary>
        /// Get all details from the database.
        /// </summary>
        /// <returns></returns>
        public IQueryable<GroupDetailsViewModel> GetGroupDetails()
        {
            var details = db.GroupDetails.ProjectTo<GroupDetailsViewModel>();
            return details;
        }


        // GET: api/GroupDetails/5
        /// <summary>
        /// Get group detail by id.
        /// </summary>
        /// <param name="id">Id of the detail</param>
        /// <returns>Detail with specified id, NotFound call otherwise.</returns>
        [ResponseType(typeof(GroupDetailsViewModel))]
        public async Task<IHttpActionResult> GetGroupDetails(int id)
        {
            GroupDetails groupDetail = await db.GroupDetails.FindAsync(id);
            if (groupDetail == null)
            {
                return NotFound();
            }
            var retDetail = Mapper.Map<GroupDetailsViewModel>(groupDetail);
            return Ok(retDetail);
        }

        // PUT: api/GroupDetails/5
        /// <summary>
        /// Edits given detail.
        /// </summary>
        /// <param name="id">id of detail</param>
        /// <param name="groupDetails">edited groupDetail</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGroupDetails(int id, GroupDetails groupDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupDetails.id)
            {
                return BadRequest();
            }

            db.Entry(groupDetails).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupDetailsExists(id))
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

        // POST: api/GroupDetails
        /// <summary>
        /// Adds given detail to database.
        /// </summary>
        /// <param name="groupDetails">View model of the group detail model that needs to be added to database.</param>
        /// <returns>Added detail, bad request response if there was error.</returns>
        [ResponseType(typeof(GroupDetailsViewModel))]
        public async Task<IHttpActionResult> PostGroupDetails(GroupDetailsViewModel groupDetails)
        {
            GroupDetails newDetail = new GroupDetails()
            {
                user_id = groupDetails.user_id,
                group_id = groupDetails.group_id
            };
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupDetails.Add(newDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = groupDetails.id }, groupDetails);
        }

        // DELETE: api/GroupDetails/5
        /// <summary>
        /// Deletes detail with given id.
        /// </summary>
        /// <param name="id">Id of the detail to delete.</param>
        /// <returns>Deleted detail, not found response if there was an error.</returns>
        [ResponseType(typeof(GroupDetailsViewModel))]
        public async Task<IHttpActionResult> DeleteGroupDetails(int id)
        {
            GroupDetails groupDetail = await db.GroupDetails.FindAsync(id);
            if (groupDetail == null)
            {
                return NotFound();
            }

            db.GroupDetails.Remove(groupDetail);
            await db.SaveChangesAsync();
            var retDetail = Mapper.Map<GroupDetailsViewModel>(groupDetail);
            return Ok(retDetail);
        }
        /// <summary>
        /// Deletes detail with given user id and group id.
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="groupId">group id</param>
        /// <returns>Deleted detail, not found response if there was an error.</returns>
        [ResponseType(typeof(GroupDetailsViewModel))]
        public async Task<IHttpActionResult> DeleteGroupDetails(int userId, int groupId)
        {
            var groupDetail =
                await db.GroupDetails.FirstOrDefaultAsync(d => d.group_id == groupId && d.user_id == userId);
            if (groupDetail == null)
                return NotFound();
            var retDetail = Mapper.Map<GroupDetailsViewModel>(groupDetail);
            return Ok(retDetail);
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
        /// Checks whether specified detail exists in the database.
        /// </summary>
        /// <param name="id">id of the detail belongs</param>
        /// <returns>true - if there is such a detail, false - otherwise</returns>
        private bool GroupDetailsExists(int id)
        {
            return db.GroupDetails.Count(e => e.id == id) > 0;
        }

        #region old methods
        //// GET: api/GroupDetails
        //public IQueryable<GroupDetails> GetGroupDetails()
        //{
        //    return db.GroupDetails;
        //}

        //// GET: api/GroupDetails/5
        //[ResponseType(typeof(GroupDetails))]
        //public async Task<IHttpActionResult> GetGroupDetails(int id)
        //{
        //    GroupDetails groupDetails = await db.GroupDetails.FindAsync(id);
        //    if (groupDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(groupDetails);
        //}

        //// PUT: api/GroupDetails/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutGroupDetails(int id, GroupDetails groupDetails)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != groupDetails.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(groupDetails).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GroupDetailsExists(id))
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

        //// POST: api/GroupDetails
        //[ResponseType(typeof(GroupDetails))]
        //public async Task<IHttpActionResult> PostGroupDetails(GroupDetails groupDetails)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.GroupDetails.Add(groupDetails);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = groupDetails.id }, groupDetails);
        //}

        //// DELETE: api/GroupDetails/5
        //[ResponseType(typeof(GroupDetails))]
        //public async Task<IHttpActionResult> DeleteGroupDetails(int id)
        //{
        //    GroupDetails groupDetails = await db.GroupDetails.FindAsync(id);
        //    if (groupDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    db.GroupDetails.Remove(groupDetails);
        //    await db.SaveChangesAsync();

        //    return Ok(groupDetails);
        //}

        //[ResponseType(typeof(GroupDetails))]
        //public async Task<IHttpActionResult> DeleteGroupDetails(int userId, int groupId)
        //{
        //    var groupDetail =
        //        await db.GroupDetails.FirstOrDefaultAsync(d => d.group_id == groupId && d.user_id == userId);
        //    if (groupDetail == null)
        //        return NotFound();

        //    return Ok(groupDetail);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool GroupDetailsExists(int id)
        //{
        //    return db.GroupDetails.Count(e => e.id == id) > 0;
        //}
        #endregion
    }
}