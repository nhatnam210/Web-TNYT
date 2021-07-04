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
    }
}