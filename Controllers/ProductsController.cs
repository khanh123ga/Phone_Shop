using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_HQK_shop.Models;
namespace LTW_HQK_shop.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Detail(int id)
        {
            ShopEntities1 db = new ShopEntities1();
            var chitietsanpham = db.SanPhams.Where(n => n.maSP == id).FirstOrDefault();
            return View(chitietsanpham);
        }
    }
}