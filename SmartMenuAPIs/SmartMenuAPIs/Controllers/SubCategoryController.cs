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
    public class SubCategoryController : ApiController
    {
        private DatabaseContainer db = new DatabaseContainer();

        //// GET api/SubCategory
        //public IQueryable<SubCategory> GetSubCategories()
        //{
        //    return db.SubCategories;
        //}

        /// <summary>
        /// Get subcategories by CategoryID
        /// </summary>
        /// <returns>subCategories Array of objects json</returns> // USED
        [Route("api/SubCategory/ByCategoryID/{id}")]
        public IQueryable<SubCategory> GetSubCategoriesNew(int id)
        {
            return db.SubCategories.Where(x => x.CategoryID == id);
        }

        //// GET api/SubCategory/5
        //[ResponseType(typeof(SubCategory))]
        //public IHttpActionResult GetSubCategory(int id)
        //{
        //    SubCategory subcategory = db.SubCategories.Find(id);
        //    if (subcategory == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(subcategory);
        //}

        //// PUT api/SubCategory/5
        //public IHttpActionResult PutSubCategory(int id, SubCategory subcategory)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != subcategory.ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(subcategory).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SubCategoryExists(id))
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

        //// POST api/SubCategory
        //[ResponseType(typeof(SubCategory))]
        //public IHttpActionResult PostSubCategory(SubCategory subcategory)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.SubCategories.Add(subcategory);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = subcategory.ID }, subcategory);
        //}

        //// DELETE api/SubCategory/5
        //[ResponseType(typeof(SubCategory))]
        //public IHttpActionResult DeleteSubCategory(int id)
        //{
        //    SubCategory subcategory = db.SubCategories.Find(id);
        //    if (subcategory == null)
        //    {
        //        return NotFound();
        //    }

        //    db.SubCategories.Remove(subcategory);
        //    db.SaveChanges();

        //    return Ok(subcategory);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubCategoryExists(int id)
        {
            return db.SubCategories.Count(e => e.ID == id) > 0;
        }
    }
}