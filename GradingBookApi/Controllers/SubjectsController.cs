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
    public class SubjectsController : ApiController
    {
        private GradingBookDbEntities db = new GradingBookDbEntities();

        // GET: api/Subjects
        public IQueryable<Subjects> GetSubjects()
        {
            return db.Subjects;
        }

        // GET: api/Subjects/5
        [ResponseType(typeof(Subjects))]
        public async Task<IHttpActionResult> GetSubjects(int id)
        {
            Subjects subjects = await db.Subjects.FindAsync(id);
            if (subjects == null)
            {
                return NotFound();
            }

            return Ok(subjects);
        }
        // GET: api/subjects/getbyyearid/4
        [ActionName("GetByYearId")]
        public IQueryable<Subjects> GetSubjectsOfYear(int id) {
            
            var subjects = db.Years.FirstOrDefault(y => y.id == id).Subjects;

            if (subjects.Count > 0)
                return subjects.AsQueryable();
            return Enumerable.Empty<Subjects>().AsQueryable();
        }

        // PUT: api/Subjects/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubjects(int id, Subjects subjects)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subjects.id)
            {
                return BadRequest();
            }

            db.Entry(subjects).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectsExists(id))
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

        // POST: api/Subjects
        [ResponseType(typeof(Subjects))]
        public async Task<IHttpActionResult> PostSubjects(Subjects subjects)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subjects.Add(subjects);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = subjects.id }, subjects);
        }

        // DELETE: api/Subjects/5
        [ResponseType(typeof(Subjects))]
        public async Task<IHttpActionResult> DeleteSubjects(int id)
        {
            Subjects subjects = await db.Subjects.FindAsync(id);
            if (subjects == null)
            {
                return NotFound();
            }

            db.Subjects.Remove(subjects);
            await db.SaveChangesAsync();

            return Ok(subjects);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubjectsExists(int id)
        {
            return db.Subjects.Count(e => e.id == id) > 0;
        }
    }
}