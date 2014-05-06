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
    public class AdController : ApiController
    {
        private DatabaseContainer db = new DatabaseContainer();

        // GET api/Ad 
        /// <summary>
        /// Get Available advertisement
        /// </summary>
        /// <returns></returns>
        public IQueryable<Ad> GetAds()
        {
            return db.Ads;
        }

        //// GET api/Ad/5
        //[ResponseType(typeof(Ad))]
        //public IHttpActionResult GetAd(int id)
        //{
        //    Ad ad = db.Ads.Find(id);
        //    if (ad == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(ad);
        //}

        //// PUT api/Ad/5
        //public IHttpActionResult PutAd(int id, Ad ad)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != ad.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(ad).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AdExists(id))
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

        //// POST api/Ad
        //[ResponseType(typeof(Ad))]
        //public IHttpActionResult PostAd(Ad ad)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Ads.Add(ad);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = ad.ID }, ad);
        //}

        //// DELETE api/Ad/5
        //[ResponseType(typeof(Ad))]
        //public IHttpActionResult DeleteAd(int id)
        //{
        //    Ad ad = db.Ads.Find(id);
        //    if (ad == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Ads.Remove(ad);
        //    db.SaveChanges();

        //    return Ok(ad);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdExists(int id)
        {
            return db.Ads.Count(e => e.ID == id) > 0;
        }
    }
}