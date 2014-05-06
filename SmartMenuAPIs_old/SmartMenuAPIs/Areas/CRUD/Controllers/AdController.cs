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
    public class AdController : Controller
    {
        private DatabaseContainer db = new DatabaseContainer();

        //
        // GET: /CRUD/Ad/

        public ActionResult Index()
        {
            return View(db.Ads.ToList());
        }

        //
        // GET: /CRUD/Ad/Details/5

        public ActionResult Details(int id = 0)
        {
            Ad ad = db.Ads.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        //
        // GET: /CRUD/Ad/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CRUD/Ad/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ad ad)
        {
            if (ModelState.IsValid)
            {
                db.Ads.Add(ad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ad);
        }

        //
        // GET: /CRUD/Ad/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ad ad = db.Ads.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        //
        // POST: /CRUD/Ad/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ad ad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ad);
        }

        //
        // GET: /CRUD/Ad/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ad ad = db.Ads.Find(id);
            if (ad == null)
            {
                return HttpNotFound();
            }
            return View(ad);
        }

        //
        // POST: /CRUD/Ad/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ad ad = db.Ads.Find(id);
            db.Ads.Remove(ad);
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