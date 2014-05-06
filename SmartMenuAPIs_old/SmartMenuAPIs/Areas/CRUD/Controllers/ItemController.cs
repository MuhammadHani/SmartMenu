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
    public class ItemController : Controller
    {
        private DatabaseContainer db = new DatabaseContainer();

        //
        // GET: /CRUD/Item/

        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.SubCategory);
            return View(items.ToList());
        }

        //
        // GET: /CRUD/Item/Details/5

        public ActionResult Details(int id = 0)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // GET: /CRUD/Item/Create

        public ActionResult Create()
        {
            ViewBag.SubCategoryID = new SelectList(db.SubCategories, "ID", "NameEN");
            return View();
        }

        //
        // POST: /CRUD/Item/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubCategoryID = new SelectList(db.SubCategories, "ID", "NameEN", item.SubCategoryID);
            return View(item);
        }

        //
        // GET: /CRUD/Item/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubCategoryID = new SelectList(db.SubCategories, "ID", "NameEN", item.SubCategoryID);
            return View(item);
        }

        //
        // POST: /CRUD/Item/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubCategoryID = new SelectList(db.SubCategories, "ID", "NameEN", item.SubCategoryID);
            return View(item);
        }

        //
        // GET: /CRUD/Item/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        //
        // POST: /CRUD/Item/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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