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
    public class SubjectDetailsController : ApiController
    {
        private GradingBookDbEntities db = new GradingBookDbEntities();

        // GET: api/SubjectDetails
        public IQueryable<SubjectDetails> GetSubjectDetails()
        {
            return db.SubjectDetails;
        }

        // GET: api/SubjectDetails/5
        [ResponseType(typeof(SubjectDetails))]
        public async Task<IHttpActionResult> GetSubjectDetails(int id)
        {
            SubjectDetails subjectDetails = await db.SubjectDetails.FindAsync(id);
            if (subjectDetails == null)
            {
                return NotFound();
            }

            return Ok(subjectDetails);
        }

        // PUT: api/SubjectDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubjectDetails(int id, SubjectDetails subjectDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subjectDetails.id)
            {
                return BadRequest();
            }

            db.Entry(subjectDetails).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectDetailsExists(id))
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

        // POST: api/SubjectDetails
        [ResponseType(typeof(SubjectDetails))]
        public async Task<IHttpActionResult> PostSubjectDetails(SubjectDetails subjectDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubjectDetails.Add(subjectDetails);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = subjectDetails.id }, subjectDetails);
        }

        // DELETE: api/SubjectDetails/5
        [ResponseType(typeof(SubjectDetails))]
        public async Task<IHttpActionResult> DeleteSubjectDetails(int id)
        {
            SubjectDetails subjectDetails = await db.SubjectDetails.FindAsync(id);
            if (subjectDetails == null)
            {
                return NotFound();
            }

            db.SubjectDetails.Remove(subjectDetails);
            await db.SaveChangesAsync();

            return Ok(subjectDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubjectDetailsExists(int id)
        {
            return db.SubjectDetails.Count(e => e.id == id) > 0;
        }
    }
}