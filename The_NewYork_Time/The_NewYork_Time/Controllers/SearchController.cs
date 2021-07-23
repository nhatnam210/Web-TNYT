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
               
                default:
                    articles = articles.OrderBy(s => s.Id);
                    break;
            }
            //var articles = db.Articles.Include(a => a.Cetegory);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(articles.ToPagedList(pageNumber, pageSize));
        }
    }
}