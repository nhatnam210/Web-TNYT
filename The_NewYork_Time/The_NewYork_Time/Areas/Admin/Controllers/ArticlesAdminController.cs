using Intercom.Core;
using PagedList;
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
    public class ArticlesAdminController : Controller
    {
        private TNYTContext db = new TNYTContext();
        [Authorize(Roles = "Admin")]
        // GET: Admin/ArticlesAdmin
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TenSortParm = String.IsNullOrEmpty(sortOrder) ? "Ten" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";

            //phan trang
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            //tìm kiếm
            var articles = from s in db.Articles
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(s => s.articlename.Contains(searchString));   
                                       //|| s.author.Contains(searchString)
                                       //|| s.description.Contains(searchString)
                                       //|| s.content1.Contains(searchString));
            }
            //sắp xếp 
            switch (sortOrder)
            {
                case "Ten":
                    articles = articles.OrderBy(s => s.articlename);
                    break;
                case "Date":
                    articles = articles.OrderBy(s => s.date);
                    break;
                case "Date_desc":
                    articles = articles.OrderByDescending(s => s.date);
                    break;
                default:
                    articles = articles.OrderBy(s => s.articlename);
                    break;
            }
            //var articles = db.Articles.Include(a => a.Cetegory);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(articles.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/ArticlesAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Admin/ArticlesAdmin/Create
        public ActionResult Create()
        {
            ViewBag.idcategory = new SelectList(db.Cetegories, "idcategory", "categoryname");
            return View();
        }

        // POST: Admin/ArticlesAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idarticle,articlename,description,image1,image2,image3,image4a,image4b,image5,content1,content2,content3,content4,content5,author,date,idcategory")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcategory = new SelectList(db.Cetegories, "idcategory", "categoryname", article.idcategory);
            return View(article);
        }

        // GET: Admin/ArticlesAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcategory = new SelectList(db.Cetegories, "idcategory", "categoryname", article.idcategory);
            return View(article);
        }

        // POST: Admin/ArticlesAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idarticle,articlename,description,image1,image2,image3,image4a,image4b,image5,content1,content2,content3,content4,content5,author,date,idcategory")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcategory = new SelectList(db.Cetegories, "idcategory", "categoryname", article.idcategory);
            return View(article);
        }

        // GET: Admin/ArticlesAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Admin/ArticlesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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
