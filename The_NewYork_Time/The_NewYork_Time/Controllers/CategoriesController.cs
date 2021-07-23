using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using The_NewYork_Time.Models;

namespace The_NewYork_Time.Controllers
{
    public class CategoriesController : Controller
    {
        private TNYTContext db = new TNYTContext();

        // GET: Categories
        public ActionResult Index()
        {
            var cetegories = db.Categories.Include(c => c.Section);
            return View(cetegories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            ViewBag.idsection = new SelectList(db.Sections, "idsection", "sectionname");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcategory,categoryname,idsection")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idsection = new SelectList(db.Sections, "idsection", "sectionname", category.idsection);
            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.idsection = new SelectList(db.Sections, "idsection", "sectionname", category.idsection);
            return View(category);
        }

        // POST: Categories/Edit/5
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

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
        public ActionResult Article(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Article article = db.Articles.Find(id);
            var objArticle = db.Articles.Where(p => p.Id == id);

            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            var userID = User.Identity.GetUserId();
            foreach (Article item in objArticle)
            {
                //lấy danh sanh tham gia khóa học
                if (userID != null)
                {
                    item.isLogin = true;
                    //Kiểm tra user đó chưa tham gia khóa học
                    Storage find = db.Storages.FirstOrDefault(p => p.ArticleId == item.Id && p.UserId == userID);
                    if (find == null)
                        item.isShowSave = true;
                }
            }
            
            return View(article);
        }
    }
}
