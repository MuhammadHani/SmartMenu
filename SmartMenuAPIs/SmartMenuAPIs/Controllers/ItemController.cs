﻿using System;
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
    public class ItemController : ApiController
    {
        private DatabaseContainer db = new DatabaseContainer();

        //// GET api/Item
        //public IQueryable<Item> GetItems()
        //{
        //    return db.Items;
        //}

        /// <summary>
        /// Get items sub details
        /// </summary>
        /// <param name="id">id of sub cat.</param>
        /// <returns></returns>
        [Route("api/Items/BySubCategoryID/{id}")] // USED
        public IQueryable<Item> GetItemsBySubCategoryID(int id)
        {
            return db.Items.Where(x => x.SubCategoryID == id);
        }

        // GET api/Item/5
        /// <summary>
        /// Get Item Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Item))] 
        public IHttpActionResult GetItem(int id)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        //// PUT api/Item/5
        //public IHttpActionResult PutItem(int id, Item item)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != item.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(item).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ItemExists(id))
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

        //// POST api/Item
        //[ResponseType(typeof(Item))]
        //public IHttpActionResult PostItem(Item item)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Items.Add(item);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = item.ID }, item);
        //}






 



        //// DELETE api/Item/5
        //[ResponseType(typeof(Item))]
        //public IHttpActionResult DeleteItem(int id)
        //{
        //    Item item = db.Items.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Items.Remove(item);
        //    db.SaveChanges();

        //    return Ok(item);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(int id)
        {
            return db.Items.Count(e => e.ID == id) > 0;
        }
    }
}