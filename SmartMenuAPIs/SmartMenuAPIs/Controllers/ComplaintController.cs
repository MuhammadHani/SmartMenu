using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SmartMenuAPIs.Models;

namespace SmartMenuAPIs.Controllers
{
    public class ComplaintController : ApiController
    {
        private DatabaseContainer db = new DatabaseContainer();

        //// GET api/Complaint
        //public IQueryable<Complaint> GetComplaints()
        //{
        //    return db.Complaints;
        //}

        //// GET api/Complaint/5
        //[ResponseType(typeof(Complaint))]
        //public IHttpActionResult GetComplaint(int id)
        //{
        //    Complaint complaint = db.Complaints.Find(id);
        //    if (complaint == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(complaint);
        //}

        //// PUT api/Complaint/5
        //public IHttpActionResult PutComplaint(int id, Complaint complaint)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != complaint.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(complaint).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ComplaintExists(id))
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

        // POST api/Complaint
        /// <summary>
        /// Send complain
        /// </summary>
        /// <param name="complaint"></param>
        /// <returns></returns>
        [ResponseType(typeof(Complaint))]
        public IHttpActionResult PostComplaint(Complaint complaint)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Complaints.Add(complaint);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = complaint.ID }, complaint);
        }

        //// DELETE api/Complaint/5
        //[ResponseType(typeof(Complaint))]
        //public IHttpActionResult DeleteComplaint(int id)
        //{
        //    Complaint complaint = db.Complaints.Find(id);
        //    if (complaint == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Complaints.Remove(complaint);
        //    db.SaveChanges();

        //    return Ok(complaint);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComplaintExists(int id)
        {
            return db.Complaints.Count(e => e.ID == id) > 0;
        }
    }
}