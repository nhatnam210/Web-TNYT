﻿using System;
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
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.Cetegory);
            return View(articles.ToList());
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