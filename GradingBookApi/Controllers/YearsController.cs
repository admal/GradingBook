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
using GradingBookProject.ViewModels;

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
        public IQueryable<YearsViewModel> GetYears()
        {
            return db.Years.ProjectTo<YearsViewModel>();
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

            return Ok(Mapper.Map<YearsViewModel>(years));
        }
        // GET: api/Years/getByUsername/jedrek
        /// <summary>
        /// Sends all Years of a given User.
        /// </summary>
        /// <param name="username">Username of a User we want years of.</param>
        /// <returns>Years of a User.</returns>
        [ActionName("GetByUsername")]
        public async Task<ICollection<YearsViewModel>> GetYearsOfUsername(string username)
        {

            var user = await db.Users.FirstOrDefaultAsync(u => u.username == username);

            if (user == null)
                return null;
            
            return user.Years.AsQueryable().ProjectTo<YearsViewModel>().ToList();
        }

        // GET: api/Years/GetByGroupId/3
        /// <summary>
        /// Sends all Years of a given Group.
        /// </summary>
        /// <param name="groupId">Group ID of a Group we want years of.</param>
        /// <returns>Years of a Group.</returns>
        [ActionName("GetByGroupId")]
        public async Task<ICollection<YearsViewModel>> GetYearsOfGroup(int groupId) {

            var group = await db.Groups.FirstOrDefaultAsync(g => g.id == groupId);

            if (group== null)
                return null;

            return group.Years.AsQueryable().ProjectTo<YearsViewModel>().ToList();
        }

        // PUT: api/Years/5
        /// <summary>
        /// Updates a given year.
        /// </summary>
        /// <param name="id">ID of a year to be updated.</param>
        /// <param name="years">Year to be updated.</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutYears(int id, YearsViewModel years)
        {

            Years updateYear = await db.Years.FindAsync(id);
            updateYear.end_date = years.end_date;
            updateYear.group_id = years.group_id;
            updateYear.name = years.name;
            updateYear.start = years.start;
            updateYear.user_id = years.user_id;
            updateYear.year_desc = years.year_desc;


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != years.id)
            {
                return BadRequest();
            }

            db.Entry(updateYear).State = EntityState.Modified;

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
        [ResponseType(typeof(YearsViewModel))]
        public async Task<IHttpActionResult> PostYears(YearsViewModel years)
        {
            Years newYear = new Years() { 
                end_date = years.end_date,
                group_id = years.group_id,
                name = years.name,
                start = years.start,
                user_id = years.user_id,
                year_desc = years.year_desc,
            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Years.Add(newYear);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = years.id }, newYear);
        }

        // DELETE: api/Years/5
        /// <summary>
        /// Deletes a Year.
        /// </summary>
        /// <param name="id">Id of a Year to be deleted.</param>
        /// <returns></returns>
        [ResponseType(typeof(YearsViewModel))]
        public async Task<IHttpActionResult> DeleteYears(int id)
        {
            Years years = await db.Years.FindAsync(id);
            if (years == null)
            {
                return NotFound();
            }

            db.Years.Remove(years);
            await db.SaveChangesAsync();

            return Ok(Mapper.Map<YearsViewModel>(years));
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