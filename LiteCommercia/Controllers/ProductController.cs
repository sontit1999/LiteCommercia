using LiteCommercia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommercia.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? page)
        {
            var listSP = UtilsDatabase.getDaTaBase().Products.ToList();
            int phanDu = listSP.Count % 8;
            int numberPage = 0;
            if (phanDu > 0)
            {
                numberPage = listSP.Count / 8 + 1;
            }
            else
            {
                numberPage = listSP.Count / 8;
            }
            if (page.HasValue)
            {  
                listSP = listSP.GetRange((int)((page - 1) * 8)-1, 8);
            }
            else
            {
                if (listSP.Count < 8)
                {
                    listSP = (List<Product>)listSP.Take(listSP.Count);
                }
                else
                {
                    listSP = listSP.GetRange(0, 8);
                }
                
            }
            ViewBag.numberPage = numberPage;
            ViewBag.listSP = listSP;   
            return View();
        }
        public ActionResult detail(int? id = 0)
        {
            var sp = UtilsDatabase.getDaTaBase().Products.Where(p => p.ProductID == id).FirstOrDefault();
            var listAttribute = UtilsDatabase.getDaTaBase().ProductAttributes.Where(p => p.ProductID == id).ToList();
            var listGallery  = UtilsDatabase.getDaTaBase().ProductGalleries.Where(p => p.ProductID == id).ToList();
            if (listGallery == null)
            {
                listGallery = new List<ProductGallery>(); 
            }
            ViewBag.sp = sp;
            ViewBag.listAttribute = listAttribute;
            ViewBag.listGallery = listGallery;
            return View();
        }
        public ActionResult Search(string keyword="")
        {
            var listSP = UtilsDatabase.getDaTaBase().Products.Where(p=>p.ProductName.Contains(keyword.Trim())).ToList();
            ViewBag.keyword = keyword;
            ViewBag.listSP = listSP;
            return View();
        }
    }
}