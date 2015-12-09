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
using GradingBookApi.Models;

namespace GradingBookApi.Controllers
{
    public class YearsController : ApiController
    {
        private GradingBookEntities db = new GradingBookEntities();

        // GET: api/Years
        public IQueryable<Years> GetYears()
        {
            return db.Years;
        }

        // GET: api/Years/5
        [ResponseType(typeof(Years))]
        public async Task<IHttpActionResult> GetYears(int id)
        {
            Years years = await db.Years.FindAsync(id);
            if (years == null)
            {
                return NotFound();
            }

            return Ok(years);
        }

        // PUT: api/Years/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutYears(int id, Years years)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != years.id)
            {
                return BadRequest();
            }

            db.Entry(years).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearsExists(id))
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

        // POST: api/Years
        [ResponseType(typeof(Years))]
        public async Task<IHttpActionResult> PostYears(Years years)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Years.Add(years);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = years.id }, years);
        }

        // DELETE: api/Years/5
        [ResponseType(typeof(Years))]
        public async Task<IHttpActionResult> DeleteYears(int id)
        {
            Years years = await db.Years.FindAsync(id);
            if (years == null)
            {
                return NotFound();
            }

            db.Years.Remove(years);
            await db.SaveChangesAsync();

            return Ok(years);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool YearsExists(int id)
        {
            return db.Years.Count(e => e.id == id) > 0;
        }
    }
}