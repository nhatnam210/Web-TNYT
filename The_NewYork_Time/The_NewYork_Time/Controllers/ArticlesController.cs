using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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

namespace The_NewYork_Time.Views
{
    public class ArticlesController : Controller
    {
        private TNYTContext db = new TNYTContext();

        // GET: Articles
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.Category);
            return View(articles.ToList());
        }

        // GET: Articles/Details/5
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

        // GET: Articles/Create
        public ActionResult Create()
        {
            ViewBag.idcategory = new SelectList(db.Categories, "idcategory", "categoryname");
            return View();
        }

        // POST: Articles/Create
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

            ViewBag.idcategory = new SelectList(db.Categories, "idcategory", "categoryname", article.idcategory);
            return View(article);
        }

        // GET: Articles/Edit/5
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
            ViewBag.idcategory = new SelectList(db.Categories, "idcategory", "categoryname", article.idcategory);
            return View(article);
        }

        // POST: Articles/Edit/5
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
            ViewBag.idcategory = new SelectList(db.Categories, "idcategory", "categoryname", article.idcategory);
            return View(article);
        }

        // GET: Articles/Delete/5
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

        // POST: Articles/Delete/5
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

        [Authorize]
        public ActionResult Attending(int? page)
        {
            ApplicationUser currentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var listFavorites = db.Storages.Where(p => p.UserId == currentUser.Id).ToList();
            var article = new List<Article>();
            foreach (Storage temp in listFavorites)
            {
                Article objCourse = temp.Article;
                
                article.Add(objCourse);
            }
            
            //var articles = db.Articles.Include(a => a.Cetegory);
            int pageSize = 1;
            int pageNumber = (page ?? 1);
            return View(article.ToPagedList(pageNumber, pageSize));
            
        }
    }
}
