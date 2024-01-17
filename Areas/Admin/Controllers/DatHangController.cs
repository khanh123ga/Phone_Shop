using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_HQK_shop.Models;
namespace LTW_HQK_shop.Areas.Admin.Controllers
{
    public class DatHangController : Controller
    {
        // GET: Admin/DatHang
        public ActionResult Index()
        {
            
            //return RedirectToAction("Index", "Dathang", new { Areas = "Admin" });
            return View("~/Areas/Admin/Views/Dathang/Index.cshtml");
        }
    }
}