﻿using System;
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
using GradingBookProject.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Web.Http.Cors;

namespace GradingBookApi.Controllers
{
    /// <summary>
    /// Api controller for managing grades(SubjectDetails).
    /// </summary>
    [EnableCors(origins: "http://localhost:51849", headers: "*", methods: "*")]
    public class SubjectDetailsController : ApiController
    {
        /// <summary>
        /// Database connection
        /// </summary>
        private GradingBookDbEntities db = new GradingBookDbEntities();

        // GET: api/SubjectDetails
        /// <summary>
        /// Gets all grades.
        /// </summary>
        /// <returns>All grades.</returns>
        public IQueryable<SubjectDetailsViewModel> GetSubjectDetails()
        {
            return db.SubjectDetails.ProjectTo<SubjectDetailsViewModel>();
        }

        // GET: api/SubjectDetails/5
        /// <summary>
        /// Gets a certain grade.
        /// </summary>
        /// <param name="id">Id of a requested grade.</param>
        /// <returns>Grades view model / not found.</returns>
        [ResponseType(typeof(SubjectDetailsViewModel))]
        public async Task<IHttpActionResult> GetSubjectDetails(int id)
        {
            var subjectDetails = await db.SubjectDetails.FindAsync(id);
            var subjectDetailsViewModel = Mapper.Map<SubjectDetailsViewModel>(subjectDetails);

            if (subjectDetails == null)
            {
                return NotFound();
            }

            return Ok(subjectDetailsViewModel);
        }

        // GET: api/subjectDetails/getbysubjectid/4
        /// <summary>
        /// Gets grades of a given subject.
        /// </summary>
        /// <param name="id">Id of a subject we want grades from.</param>
        /// <returns>Collection of grades as view models.</returns>
        [HttpGet]
        [Route("api/subjectDetails/getbysubjectid/{id:int}")]
        [ActionName("getbysubjectid")]
        public async Task<ICollection<SubjectDetailsViewModel>> GetGradesOfSubject(int id)
        {
            var subject = await db.Subjects.FirstOrDefaultAsync(s => s.id == id);

            if (subject == null)
                return null;
            return subject.SubjectDetails.AsQueryable().ProjectTo<SubjectDetailsViewModel>().ToList();
        }

        // PUT: api/SubjectDetails/5
        /// <summary>
        /// Updates a grade.
        /// </summary>
        /// <param name="id">Id of a grade to be updated.</param>
        /// <param name="subjectDetails">Updated grade as a view model.</param>
        /// <returns>Updated grade view model / not found/ bad request.</returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubjectDetails(int id, SubjectDetailsViewModel subjectDetails)
        {
            SubjectDetails local=  await db.SubjectDetails.FindAsync(id);
            local.grade_date = subjectDetails.grade_date;
            local.grade_desc = subjectDetails.grade_desc;
            local.grade_value = subjectDetails.grade_value;
            local.grade_weight = subjectDetails.grade_weight;
            local.user_id = subjectDetails.user_id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subjectDetails.id)
            {
                return BadRequest();
            }

            db.Entry(local).State = EntityState.Modified;

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
        /// <summary>
        /// Adds a grade.
        /// </summary>
        /// <param name="subjectDetails">Grade to be added</param>
        /// <returns>Added grade / bad request.</returns>
        [ResponseType(typeof(SubjectDetailsViewModel))]
        public async Task<IHttpActionResult> PostSubjectDetails(SubjectDetailsViewModel subjectDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SubjectDetails newSubjectDetail = new SubjectDetails()
            {
                grade_date = subjectDetails.grade_date,
                grade_desc = subjectDetails.grade_desc,
                grade_value = subjectDetails.grade_value,
                grade_weight = subjectDetails.grade_weight,
                sub_id = subjectDetails.sub_id,
                user_id = subjectDetails.user_id
            };

            db.SubjectDetails.Add(newSubjectDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = subjectDetails.id }, subjectDetails);
        }

        // DELETE: api/SubjectDetails/5
        /// <summary>
        /// Deletes a grade.
        /// </summary>
        /// <param name="id">Id of a grade to be deleted.</param>
        /// <returns>Deleted grade / not found.</returns>
        [ResponseType(typeof(SubjectDetailsViewModel))]
        public async Task<IHttpActionResult> DeleteSubjectDetails(int id)
        {
            SubjectDetails subjectDetails = await db.SubjectDetails.FindAsync(id);
            if (subjectDetails == null)
            {
                return NotFound();
            }

            db.SubjectDetails.Remove(subjectDetails);
            await db.SaveChangesAsync();
            
            return Ok(Mapper.Map<SubjectDetailsViewModel>(subjectDetails));
        }
        /// <summary>
        /// Disposes of database connection.
        /// </summary>
        /// <param name="disposing">Determines wether the connection should be disposed.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// Checks if grade exists.
        /// </summary>
        /// <param name="id">Id of a grade.</param>
        /// <returns>True if a grade exists, false otherwise.</returns>
        private bool SubjectDetailsExists(int id)
        {
            return db.SubjectDetails.Count(e => e.id == id) > 0;
        }
    }
}