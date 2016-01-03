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
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GradingBookProject.Http;
using GradingBookProject.Models;
using GradingBookProject.ViewModels;

namespace GradingBookApi.Controllers
{
    public class GroupDetailsController : ApiController
    {
        private GradingBookDbEntities db = new GradingBookDbEntities();

        [HttpGet]
        [ActionName("DetailExists")]
        public async Task<bool> DetailExists(int groupId, int userId )
        {
            bool exists = (await db.GroupDetails.FirstOrDefaultAsync(d => d.group_id == groupId && d.user_id == userId) != null);
            return exists;
        }

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
        public IQueryable<GroupDetailsViewModel> GetGroupDetails()
        {
            var details = db.GroupDetails.ProjectTo<GroupDetailsViewModel>();
            return details;
        }

        // GET: api/GroupDetails/5
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