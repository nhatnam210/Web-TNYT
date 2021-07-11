using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNYT;

namespace The_NewYork_Time.Models.BUS
{
    public class ArticleBUS
    {
        public static IEnumerable<Article> DanhSachArticleTheoCate(int id)
        {
            var db = new TNYTDB();
            return db.Query<Article>("select * from Article where idcategory =  '" + id + "'");
        }

        public static IEnumerable<Article> DanhSachArticleRandom(int id)
        {
            var db = new TNYTDB();
            return db.Query<Article>("SELECT TOP 10 * FROM Article as a, Category as c, Section as s where a.idcategory = c.idcategory and c.idsection= s.idsection and s.idsection = '"+ id +"' ORDER BY NEWID()");
        }
        public static IEnumerable<Article> DanhSachArticleTop1(int id)
        {
            var db = new TNYTDB();
            return db.Query<Article>("select top 1 * from Article a , Section s , Category c  where a.idcategory = c.idcategory and c.idsection = s.idsection and s.idsection = '" + id + "' ORDER BY idarticle DESC ");
            
        }
        //public static IEnumerable<Article> DanhSachArticleTop2(int id)
        //{
        //    var db = new TNYTDB();
        //    return db.Execute("exec  TOP2 @idsection= '" + id + "'");

        //}

        public static IEnumerable<Article> DanhsachArticleLastest(int id)
        {
            var db = new TNYTDB();
            return db.Query<Article>("select * from Article a , Section s , Category c  where a.idcategory = c.idcategory and c.idsection = s.idsection and s.idsection = '" + id + "' ORDER BY idarticle DESC ");

        }
        public static IEnumerable<Article> DetailArticle(int id)
        {
            var db = new TNYTDB();
            return db.Query<Article>("select * from Article a , Category c where a.idcategory = c.idcategory and idarticle = '" + id + "'");

        }
    }
}