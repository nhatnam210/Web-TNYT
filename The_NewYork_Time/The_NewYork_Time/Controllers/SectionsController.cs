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
    public class SectionsController : Controller
    {
        private TNYTContext db = new TNYTContext();

        // GET: Sections
        
        public ActionResult Category(int id, int page = 1, int pagesize = 5)
        {
            var ds = The_NewYork_Time.Models.BUS.ArticleBUS.DanhSachArticleTheoCate(id).ToPagedList(page, pagesize);
            
            return View(ds);
        }
    }

}
