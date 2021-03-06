using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TNYT;
using The_NewYork_Time.Models;
using PagedList;

namespace The_NewYork_Time.Areas.Admin.Controllers
{
    public class AspNetUsersAdminController : Controller
    {
        private TNYTContext db = new TNYTContext();

        [Authorize(Roles = "Admin")]
        // GET: Admin/AspNetUsersAdmin
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.TenSortParm = String.IsNullOrEmpty(sortOrder) ? "Ten" : "";


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
            var users = from s in db.AspNetUsers
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.UserName.Contains(searchString));
                //|| s.author.Contains(searchString)
                //|| s.description.Contains(searchString)
                //|| s.content1.Contains(searchString));
            }
            //sắp xếp 
            switch (sortOrder)
            {
                case "Ten":
                    users = users.OrderByDescending(s => s.UserName);
                    break;

                default:
                    users = users.OrderBy(s => s.UserName);
                    break;
            }
            //var articles = db.Articles.Include(a => a.Cetegory);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/AspNetUsersAdmin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // GET: Admin/AspNetUsersAdmin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: Admin/AspNetUsersAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {

            var deleteUser = db.Storages
                .Where(s => s.UserId == id)
                .Select(s => s);

            foreach (var item in deleteUser)
            {
                db.Storages.Remove(item);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(aspNetUser);
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
