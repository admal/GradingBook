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
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace GradingBookApi.Controllers
{
    /// <summary>
    /// Controller containing all Year methods.
    /// </summary>
    public class YearsController : ApiController
    {
        private GradingBookDbEntities db = new GradingBookDbEntities();

        // GET: api/Years
        /// <summary>
        /// Sends all Years from database.
        /// </summary>
        /// <returns>All years</returns>
        public IQueryable<Years> GetYears()
        {
            return db.Years;
        }

        // GET: api/Years/5
        /// <summary>
        /// Sends a chosen Year from database.
        /// </summary>
        /// <param name="id">Years unique id</param>
        /// <returns>Single Year.</returns>
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
        // GET: api/Years/getByUsername/jedrek
        /// <summary>
        /// Sends all Years of a given User.
        /// </summary>
        /// <param name="username">Username of a User we want years of.</param>
        /// <returns>Years of a User.</returns>
        [ActionName("GetByUsername")]
        public IQueryable<Years> GetYearsOfUsername(string username)
        {

            var years = db.Users.FirstOrDefault(u => u.username == username).Years;

            if(years.Count > 0)
                return years.AsQueryable();
            return Enumerable.Empty<Years>().AsQueryable();
        }

        // PUT: api/Years/5
        /// <summary>
        /// Updates a given year.
        /// </summary>
        /// <param name="id">ID of a year to be updated.</param>
        /// <param name="years">Year to be updated.</param>
        /// <returns></returns>
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

           /*(await db.Years.FirstOrDefaultAsync(y => y.id == id)).name = years.name;
           (await db.Years.FirstOrDefaultAsync(y => y.id == id)).year_desc = years.year_desc;
           (await db.Years.FirstOrDefaultAsync(y => y.id == id)).start = years.start;
           (await db.Years.FirstOrDefaultAsync(y => y.id == id)).end_date = years.end_date;*/

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
        /// <summary>
        /// Saves a given year.
        /// </summary>
        /// <param name="years">ID of a Year to be saved.</param>
        /// <returns>Year to be saved</returns>
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
        /// <summary>
        /// Deletes a Year.
        /// </summary>
        /// <param name="id">Id of a Year to be deleted.</param>
        /// <returns></returns>
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
        /// <summary>
        /// Disposes of database connection.
        /// </summary>
        /// <param name="disposing">If positive -> dispose</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// Checks if Year exists.
        /// </summary>
        /// <param name="id">Id of a Year.</param>
        /// <returns>Wether a given year existts.</returns>
        private bool YearsExists(int id)
        {
            return db.Years.Count(e => e.id == id) > 0;
        }
    }
}