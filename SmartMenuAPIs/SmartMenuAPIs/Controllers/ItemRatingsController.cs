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
    public class ItemRatingsController : ApiController
    {
        private DatabaseContainer db = new DatabaseContainer();

        //// GET api/ItemRatings
        //public IQueryable<ItemRating> GetItemRatings()
        //{
        //    return db.ItemRatings;
        //}

        //// GET api/ItemRatings/5
        //[ResponseType(typeof(ItemRating))]
        //public IHttpActionResult GetItemRating(int id)
        //{
        //    ItemRating itemrating = db.ItemRatings.Find(id);
        //    if (itemrating == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(itemrating);
        //}

        //// PUT api/ItemRatings/5
        //public IHttpActionResult PutItemRating(int id, ItemRating itemrating)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != itemrating.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(itemrating).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ItemRatingExists(id))
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

        // POST api/ItemRatings
        /// <summary>
        /// Rate item
        /// </summary>
        /// <param name="itemrating">object that contains the item rating</param>
        /// <returns></returns>
        [ResponseType(typeof(ItemRating))]
        public IHttpActionResult PostItemRating(ItemRating itemrating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemRatings.Add(itemrating);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = itemrating.ID }, itemrating);
        }

        //// DELETE api/ItemRatings/5
        //[ResponseType(typeof(ItemRating))]
        //public IHttpActionResult DeleteItemRating(int id)
        //{
        //    ItemRating itemrating = db.ItemRatings.Find(id);
        //    if (itemrating == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ItemRatings.Remove(itemrating);
        //    db.SaveChanges();

        //    return Ok(itemrating);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemRatingExists(int id)
        {
            return db.ItemRatings.Count(e => e.ID == id) > 0;
        }
    }
}