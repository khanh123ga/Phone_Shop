using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_HQK_shop.Models;
namespace LTW_HQK_shop.Areas.Admin.Controllers
{
    public class TrangchuController : Controller
    {
        // GET: Admin/Trangchu
        public ActionResult Index()
        {
            Adminn x = (Adminn)Session["TTdangnhap"];
            if (x == null)
            {
                Response.Redirect("~/Index");
            }

            //return RedirectToAction("Index", "Trangchu", new { Areas = "Admin" });
            return View("~/Areas/Admin/Views/Trangchu/Index.cshtml");
        }

    }
}