using System;
using System.Collections.Generic;
using System.Linq;
using TNYT;
namespace The_NewYork_Time.Models.BUS
{
    public class SectionBUS
    {
        public static IEnumerable<Section> ShowsectionName(int id)
        {
            var db = new TNYTDB();
            return db.Query<Section>("select * from Section where idsection =  '" + id + "'");
        }

        public static IEnumerable<Section> DanhSachSection()
        {
            var db = new TNYTDB();
            return db.Query<Section>("select * from  Section ");
        }
        public static IEnumerable<Section> Sectionchan()
        {
            var db = new TNYTDB();
            return db.Query<Section>("select * from Section where idsection % 2 = 0 ");

        }
    }
}