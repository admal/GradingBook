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
    public class SubjectsController : ApiController
    {
        private GradingBookDbEntities db = new GradingBookDbEntities();

        // GET: api/Subjects
        public IQueryable<SubjectsViewModel> GetSubjects()
        {
            return db.Subjects.ProjectTo<SubjectsViewModel>();
        }

        // GET: api/Subjects/5
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
        [HttpGet]
        [Route("api/subjects/getbyyearid/{id:int}")]
        [ActionName("getbyyearid")]
        public IQueryable<SubjectsViewModel> GetSubjectsOfYear(int id) {
            
            var subjects = db.Years.FirstOrDefault(y => y.id == id).Subjects.AsQueryable().ProjectTo<SubjectsViewModel>();

            if (subjects.Count() > 0)
                return subjects;
            return Enumerable.Empty<SubjectsViewModel>().AsQueryable();
        }

        // PUT: api/Subjects/5
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