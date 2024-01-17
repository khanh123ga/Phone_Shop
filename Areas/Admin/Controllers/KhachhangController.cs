using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_HQK_shop.Models;
namespace LTW_HQK_shop.Areas.Admin.Controllers
{
    public class KhachhangController : Controller
    {
        // GET: Admin/Khachhang
        public ActionResult Index()
        {
            List<Khachhang> kh = new ShopEntities1().Khachhangs.ToList<Khachhang>();
            ViewData["danhsachkhachhang"] = kh;
            //return RedirectToAction("Index", "Khachhang", new { Areas = "Admin" });
            return View("~/Areas/Admin/Views/Khachhang/Index.cshtml");
          
        }
    }
}