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
    public class ItemReviewController : ApiController
    {
        private DatabaseContainer db = new DatabaseContainer();

        //// GET api/ItemReview
        //public IQueryable<ItemReview> GetItemReviews()
        //{
        //    return db.ItemReviews;
        //}

        //// GET api/ItemReview/5
        //[ResponseType(typeof(ItemReview))]
        //public IHttpActionResult GetItemReview(int id)
        //{
        //    ItemReview itemreview = db.ItemReviews.Find(id);
        //    if (itemreview == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(itemreview);
        //}

        //// PUT api/ItemReview/5
        //public IHttpActionResult PutItemReview(int id, ItemReview itemreview)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != itemreview.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(itemreview).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ItemReviewExists(id))
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

        // POST api/ItemReview
        /// <summary>
        /// Review item
        /// </summary>
        /// <param name="itemreview"></param>
        /// <returns></returns>
        [ResponseType(typeof(ItemReview))]
        public IHttpActionResult PostItemReview(ItemReview itemreview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemReviews.Add(itemreview);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = itemreview.ID }, itemreview);
        }

        //// DELETE api/ItemReview/5
        //[ResponseType(typeof(ItemReview))]
        //public IHttpActionResult DeleteItemReview(int id)
        //{
        //    ItemReview itemreview = db.ItemReviews.Find(id);
        //    if (itemreview == null)
        //    {
        //        return NotFound();
        //    }

        //    db.ItemReviews.Remove(itemreview);
        //    db.SaveChanges();

        //    return Ok(itemreview);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemReviewExists(int id)
        {
            return db.ItemReviews.Count(e => e.ID == id) > 0;
        }
    }
}