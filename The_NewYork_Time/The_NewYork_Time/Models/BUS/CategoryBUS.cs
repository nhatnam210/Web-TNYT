﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNYT;

namespace The_NewYork_Time.Models.BUS
{
    public class CategoryBUS
    {
        public static IEnumerable<Category> ShowCateBySec(int id)
        {
            var db = new TNYTDB();
            return db.Query<Category>("select * from Category where idsection =  '" + id + "'");
        }

        public static IEnumerable<Category> ShowCategoryName(int id)
        {
            var db = new TNYTDB();
            return db.Query<Category>("select * from  Category where idcategory =  '" + id + "'");
        }
    }
}