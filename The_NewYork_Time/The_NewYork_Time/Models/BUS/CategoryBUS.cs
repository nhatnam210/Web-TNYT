using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNYT;

namespace The_NewYork_Time.Models.BUS
{
    public class CategoryBUS
    {
        public static IEnumerable<Category> DanhSachCaTe(int id)
        {
            var db = new TNYTDB();
            return db.Query<Category>("select * from Category where idsection =  '" + id + "'");
        }
        public static IEnumerable<Category> ShowsectionName(int id)
        {
            var db = new TNYTDB();
            return db.Query<Category>("select * from Category where idsection =  '" + id + "'");
        }

       

        public static IEnumerable<Category> CateGoryNameNav(int id)
        {
            var db = new TNYTDB();
            return db.Query<Category>("select * from  Category where idsection =  '" + id + "'");
        }

        

    }
}