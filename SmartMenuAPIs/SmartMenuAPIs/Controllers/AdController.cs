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
    public class AdController : ApiController
    {
        private DatabaseContainer db = new DatabaseContainer();

        // GET api/Ad
        public IEnumerable<Ad> GetAds()
        {
            return db.Ads.Include(x => x.AdsResources).AsEnumerable();
        }

        // GET api/Ad/5
        public Ad GetAd(int id)
        {
            Ad ad = db.Ads.Find(id);
            if (ad == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return ad;
        }

        // PUT api/Ad/5
        public HttpResponseMessage PutAd(int id, Ad ad)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != ad.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(ad).State = EntityState.Modified;

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

        // POST api/Ad
        public HttpResponseMessage PostAd(Ad ad)
        {
            if (ModelState.IsValid)
            {
                db.Ads.Add(ad);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, ad);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = ad.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Ad/5
        public HttpResponseMessage DeleteAd(int id)
        {
            Ad ad = db.Ads.Find(id);
            if (ad == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Ads.Remove(ad);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ad);
        }




        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}