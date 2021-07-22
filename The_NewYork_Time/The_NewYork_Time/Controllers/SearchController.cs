using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using The_NewYork_Time.Models;

namespace The_NewYork_Time.Controllers
{
    public class SearchController : Controller
    {
        private TNYTContext db = new TNYTContext();
        // GET: Search
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            
            ViewBag.CurrentSort = sortOrder;
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "Id" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
            ViewBag.TenSortParm = sortOrder == "Ten" ? "Ten_desc" : "Ten";

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
                case "Id":
                    articles = articles.OrderByDescending(s => s.idarticle);
                    break;
                case "Date":
                    articles = articles.OrderBy(s => s.date);
                    break;
                case "Date_desc":
                    articles = articles.OrderByDescending(s => s.date);
                    break;
                case "Ten":
                    articles = articles.OrderBy(s => s.articlename);
                    break;
                case "Ten_desc":
                    articles = articles.OrderByDescending(s => s.articlename);
                    break;
                default:
                    articles = articles.OrderBy(s => s.idarticle);
                    break;
            }
            //var articles = db.Articles.Include(a => a.Cetegory);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(articles.ToPagedList(pageNumber, pageSize));
        }
    }
}