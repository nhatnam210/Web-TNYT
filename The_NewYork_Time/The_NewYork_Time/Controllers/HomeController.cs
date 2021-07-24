using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using The_NewYork_Time.Models;

namespace The_NewYork_Time.Controllers
{
    public class HomeController : Controller
    {
        private TNYTContext db = new TNYTContext();


        public ActionResult Index()
        {
            return View(db.Sections.ToList());
        }


        public ActionResult Section(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        
    }
}