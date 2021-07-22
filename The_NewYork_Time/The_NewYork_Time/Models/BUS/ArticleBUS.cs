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
        public static IEnumerable<Article> DanhSachArticleTop2(int id)
        {
            var db = new TNYTDB();
            return db.Query<Article>("SELECT top 1 * FROM Article WHERE idarticle IN(SELECT Max(idarticle - 1)  from Article a , Section s, Category c where a.idcategory = c.idcategory and c.idsection = s.idsection and s.idsection = '" + id + "' GROUP BY  idarticle)ORDER BY idarticle DESC");

        }
        public static IEnumerable<Article> DanhSachArticleTop3(int id)
        {
            var db = new TNYTDB();
            return db.Query<Article>("SELECT top 1 * FROM Article WHERE idarticle IN(SELECT Max(idarticle - 2)  from Article a , Section s, Category c where a.idcategory = c.idcategory and c.idsection = s.idsection and s.idsection = '" + id + "' GROUP BY  idarticle)ORDER BY idarticle DESC");

        }
        public static IEnumerable<Article> DanhSachArticleTop4(int id)
        {
            var db = new TNYTDB();
            return db.Query<Article>("SELECT top 1 * FROM Article WHERE idarticle IN(SELECT Max(idarticle - 3)  from Article a , Section s, Category c where a.idcategory = c.idcategory and c.idsection = s.idsection and s.idsection = '" + id + "' GROUP BY  idarticle)ORDER BY idarticle DESC");

        }

        public static IEnumerable<Article> DanhsachArticleLastest(int id)
        {
            var db = new TNYTDB();
            return db.Query<Article>("select * from Article a , Section s , Category c  where a.idcategory = c.idcategory and c.idsection = s.idsection and s.idsection = '" + id + "' ORDER BY idarticle DESC ");

        }

        public static IEnumerable<Article> ShowArticleToCate(int id)
        {
            var db = new TNYTDB();
            return db.Query<Article>("select top 5 * from Article a , Category c where a.idcategory = c.idcategory and c.idcategory = '" + id + "' ORDER BY idarticle DESC");

        }
        public static IEnumerable<Article> ShowArticleRandomHome()
        {
            var db = new TNYTDB();
            return db.Query<Article>("select top 4 * from Article order by NEWID()");

        }
        public static IEnumerable<Article> DanhsachArticleLastestIndex()
        {
            var db = new TNYTDB();
            return db.Query<Article>("select top 1 * from Article  ORDER BY idarticle DESC ");

        }
        
        public static IEnumerable<Article> ShowArticleSectionchan(int id)
        {
            var db = new TNYTDB();
            return db.Query<Article>("select top 6 * from Article a , Category c , Section s where a.idcategory = c.idcategory and c.idsection = s.idsection and s.idsection = '" + id + "' ORDER BY idarticle DESC");

        }
        public static IEnumerable<Article> ShowArticleSectionle(int id)
        {
            var db = new TNYTDB();
            return db.Query<Article>("select top 6 * from Article a , Category c , Section s where a.idcategory = c.idcategory and c.idsection = s.idsection and s.idsection = '" + id + "' ORDER BY idarticle DESC");

        }

        public static IEnumerable<Article> Show2ndArticleHome()
        {
            var db = new TNYTDB();
            return db.Query<Article>("SELECT top 1 * FROM Article WHERE idarticle IN(SELECT Max(idarticle - 1) from Article a , Section s, Category c where a.idcategory = c.idcategory and c.idsection = s.idsection GROUP BY idarticle)ORDER BY idarticle DESC");

        }
        public static IEnumerable<Article> Show3rdArticleHome()
        {
            var db = new TNYTDB();
            return db.Query<Article>("SELECT top 1 * FROM Article WHERE idarticle IN(SELECT Max(idarticle - 2) from Article a , Section s, Category c where a.idcategory = c.idcategory and c.idsection = s.idsection GROUP BY idarticle)ORDER BY idarticle DESC");

        }
    }
}