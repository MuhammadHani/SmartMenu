using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartMenuAPIs.Models;

namespace SmartMenuAPIs.Areas.CRUD.Controllers
{
    public class AdResourceController : Controller
    {
        private DatabaseContainer db = new DatabaseContainer();

        //
        // GET: /CRUD/AdResource/

        public ActionResult Index()
        {
            var adsresources = db.AdsResources.Include(a => a.Ad);
            return View(adsresources.ToList());
        }

        //
        // GET: /CRUD/AdResource/Details/5

        public ActionResult Details(int id = 0)
        {
            AdsResource adsresource = db.AdsResources.Find(id);
            if (adsresource == null)
            {
                return HttpNotFound();
            }
            return View(adsresource);
        }

        //
        // GET: /CRUD/AdResource/Create

        public ActionResult Create()
        {
            ViewBag.AdID = new SelectList(db.Ads, "ID", "TitleEN");
            return View();
        }

        //
        // POST: /CRUD/AdResource/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdsResource adsresource)
        {
            if (ModelState.IsValid)
            {
                db.AdsResources.Add(adsresource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdID = new SelectList(db.Ads, "ID", "TitleEN", adsresource.AdID);
            return View(adsresource);
        }

        //
        // GET: /CRUD/AdResource/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AdsResource adsresource = db.AdsResources.Find(id);
            if (adsresource == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdID = new SelectList(db.Ads, "ID", "TitleEN", adsresource.AdID);
            return View(adsresource);
        }

        //
        // POST: /CRUD/AdResource/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdsResource adsresource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adsresource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdID = new SelectList(db.Ads, "ID", "TitleEN", adsresource.AdID);
            return View(adsresource);
        }

        //
        // GET: /CRUD/AdResource/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AdsResource adsresource = db.AdsResources.Find(id);
            if (adsresource == null)
            {
                return HttpNotFound();
            }
            return View(adsresource);
        }

        //
        // POST: /CRUD/AdResource/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdsResource adsresource = db.AdsResources.Find(id);
            db.AdsResources.Remove(adsresource);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}