using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SmartMenuAPIs.Models;

namespace SmartMenuAPIs.Controllers
{
    public class SubCategoryController : ApiController
    {
        private DatabaseContainer db = new DatabaseContainer();

        // GET api/SubCategory
        public IEnumerable<SubCategory> GetSubCategories()
        {
            var subcategories = db.SubCategories.Include(s => s.Category);
            return subcategories.AsEnumerable();
        }

        //Get api/SubCategory
        public IEnumerable<SubCategory> GetSubCategories(int CategoryID)
        {
            var subcategories = db.SubCategories
                .Where(x => x.CategoryID == CategoryID);//.Include(s => s.Category);
            return subcategories.AsEnumerable();
        }


        // GET api/SubCategory/5
        
        //public SubCategory GetSubCategory(int id)
        //{
        //    SubCategory subcategory = db.SubCategories.Find(id);
        //    if (subcategory == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }

        //    return subcategory;
        //}
        // PUT api/SubCategory/5
        public HttpResponseMessage PutSubCategory(int id, SubCategory subcategory)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != subcategory.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(subcategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/SubCategory
        public HttpResponseMessage PostSubCategory(SubCategory subcategory)
        {
            if (ModelState.IsValid)
            {
                db.SubCategories.Add(subcategory);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, subcategory);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = subcategory.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/SubCategory/5
        public HttpResponseMessage DeleteSubCategory(int id)
        {
            SubCategory subcategory = db.SubCategories.Find(id);
            if (subcategory == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.SubCategories.Remove(subcategory);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, subcategory);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}