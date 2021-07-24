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
