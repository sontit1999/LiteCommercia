using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiteCommercia.Models
{
    public class UtilsDatabase
    {
        private static DataClasses1DataContext db = null;
        public static DataClasses1DataContext getDaTaBase()
        {
            if (db == null)
            {
                db = new DataClasses1DataContext();
            }
            return db;
        }
    }
}