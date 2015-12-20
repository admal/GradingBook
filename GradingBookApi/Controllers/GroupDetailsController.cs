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
using GradingBookProject.Models;

namespace GradingBookApi.Controllers
{
    public class GroupDetailsController : ApiController
    {
        private GradingBookDbEntities db = new GradingBookDbEntities();

        // GET: api/GroupDetails
        public IQueryable<GroupDetails> GetGroupDetails()
        {
            return db.GroupDetails;
        }

        // GET: api/GroupDetails/5
        [ResponseType(typeof(GroupDetails))]
        public async Task<IHttpActionResult> GetGroupDetails(int id)
        {
            GroupDetails groupDetails = await db.GroupDetails.FindAsync(id);
            if (groupDetails == null)
            {
                return NotFound();
            }

            return Ok(groupDetails);
        }

        // PUT: api/GroupDetails/5
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
        [ResponseType(typeof(GroupDetails))]
        public async Task<IHttpActionResult> PostGroupDetails(GroupDetails groupDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroupDetails.Add(groupDetails);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = groupDetails.id }, groupDetails);
        }

        // DELETE: api/GroupDetails/5
        [ResponseType(typeof(GroupDetails))]
        public async Task<IHttpActionResult> DeleteGroupDetails(int id)
        {
            GroupDetails groupDetails = await db.GroupDetails.FindAsync(id);
            if (groupDetails == null)
            {
                return NotFound();
            }

            db.GroupDetails.Remove(groupDetails);
            await db.SaveChangesAsync();

            return Ok(groupDetails);
        }

        [ResponseType(typeof(GroupDetails))]
        public async Task<IHttpActionResult> DeleteGroupDetails(int userId, int groupId)
        {
            var groupDetail =
                await db.GroupDetails.FirstOrDefaultAsync(d => d.group_id == groupId && d.user_id == userId);
            if (groupDetail == null)
                return NotFound();

            return Ok(groupDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupDetailsExists(int id)
        {
            return db.GroupDetails.Count(e => e.id == id) > 0;
        }
    }
}