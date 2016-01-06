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
    /// Api controller to manage Subjects.
    /// </summary>
    public class SubjectsController : ApiController
    {
        /// <summary>
        /// Database access
        /// </summary>
        private GradingBookDbEntities db = new GradingBookDbEntities();

        // GET: api/Subjects
        /// <summary>
        /// Gets all subjects view models.
        /// </summary>
        /// <returns>All subjects view models.</returns>
        public IQueryable<SubjectsViewModel> GetSubjects()
        {
            return db.Subjects.ProjectTo<SubjectsViewModel>();
        }

        // GET: api/Subjects/5
        /// <summary>
        /// Gets a certain subject.
        /// </summary>
        /// <param name="id">Id of a subject requested.</param>
        /// <returns>Single subject view model / not found.</returns>
        [ResponseType(typeof(SubjectsViewModel))]
        public async Task<IHttpActionResult> GetSubjects(int id)
        {
            Subjects subjects = await db.Subjects.FindAsync(id);
            if (subjects == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<SubjectsViewModel>(subjects));
        }

        // GET: api/subjects/getbyyearid/4
        /// <summary>
        /// Gets subjects of a year.
        /// </summary>
        /// <param name="id">Year we want subjects of.</param>
        /// <returns>Collection of subjects of year view models / null.</returns>
        [HttpGet]
        [Route("api/subjects/getbyyearid/{id:int}")]
        [ActionName("getbyyearid")]
        public async Task<ICollection<SubjectsViewModel>> GetSubjectsOfYear(int id) {

            var year = await db.Years.FirstOrDefaultAsync(y => y.id == id);

            if (year == null)
                return null;
            return  year.Subjects.AsQueryable().ProjectTo<SubjectsViewModel>().ToList();
           
        }

        // PUT: api/Subjects/5
        /// <summary>
        /// Updates a subject.
        /// </summary>
        /// <param name="id">Id od a subject to update.</param>
        /// <param name="subjects">Updated version of a subject.</param>
        /// <returns>Single updated subject view model / not found / bad request.</returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubjects(int id, SubjectsViewModel subjects)
        {
            Subjects updatedSubject = await db.Subjects.FindAsync(id); 
                updatedSubject.name = subjects.name;
                updatedSubject.sub_desc = subjects.sub_desc;
                updatedSubject.teacher_mail = subjects.teacher_mail;
                updatedSubject.year_id = subjects.year_id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subjects.id)
            {
                return BadRequest();
            }

            db.Entry(updatedSubject).State = EntityState.Modified;

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
        /// <summary>
        /// Adds a subject.
        /// </summary>
        /// <param name="subjects">Subject to be added.</param>
        /// <returns>Added subjects view model / bad request.</returns>
        [ResponseType(typeof(SubjectsViewModel))]
        public async Task<IHttpActionResult> PostSubjects(SubjectsViewModel subjects)
        {
            Subjects newSubject = new Subjects()
            {
                name = subjects.name,
                sub_desc = subjects.sub_desc,
                teacher_mail = subjects.teacher_mail,
                year_id = subjects.year_id,

            };

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subjects.Add(newSubject);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = subjects.id }, newSubject);
        }

        // DELETE: api/Subjects/5
        /// <summary>
        /// Deletes a subject.
        /// </summary>
        /// <param name="id">Id of a subject to be deleted.</param>
        /// <returns>Deleted subjects view model / not found.</returns>
        [ResponseType(typeof(SubjectsViewModel))]
        public async Task<IHttpActionResult> DeleteSubjects(int id)
        {
            Subjects subjects = await db.Subjects.FindAsync(id);
            if (subjects == null)
            {
                return NotFound();
            }

            db.Subjects.Remove(subjects);
            await db.SaveChangesAsync();

            return Ok(Mapper.Map<SubjectsViewModel>(subjects));
        }
        /// <summary>
        /// Disposes of database connection.
        /// </summary>
        /// <param name="disposing">Determines wether it will dispose of database connection.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// Checks if subject exists.
        /// </summary>
        /// <param name="id">Id of a subject to be checked.</param>
        /// <returns>True if subject exists, false otherwise</returns>
        private bool SubjectsExists(int id)
        {
            return db.Subjects.Count(e => e.id == id) > 0;
        }
    }
}