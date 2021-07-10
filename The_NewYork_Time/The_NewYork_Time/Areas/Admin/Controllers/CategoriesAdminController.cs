using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using The_NewYork_Time.Models;

namespace The_NewYork_Time.Areas.Admin.Controllers
{
    public class CategoriesAdminController : Controller
    {
        private TNYTContext db = new TNYTContext();
        [Authorize(Roles = "Admin")]
        // GET: Admin/CategoriesAdmin
        public ActionResult Index()
        {
            var cetegories = db.Cetegories.Include(c => c.Section);
            return View(cetegories.ToList());
        }

        // GET: Admin/CategoriesAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Cetegories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/CategoriesAdmin/Create
        public ActionResult Create()
        {
            ViewBag.idsection = new SelectList(db.Sections, "idsection", "sectionname");
            return View();
        }

        // POST: Admin/CategoriesAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcategory,categoryname,idsection")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Cetegories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idsection = new SelectList(db.Sections, "idsection", "sectionname", category.idsection);
            return View(category);
        }

        // GET: Admin/CategoriesAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Cetegories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.idsection = new SelectList(db.Sections, "idsection", "sectionname", category.idsection);
            return View(category);
        }

        // POST: Admin/CategoriesAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcategory,categoryname,idsection")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idsection = new SelectList(db.Sections, "idsection", "sectionname", category.idsection);
            return View(category);
        }

        // GET: Admin/CategoriesAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Cetegories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/CategoriesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Cetegories.Find(id);
            db.Cetegories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
