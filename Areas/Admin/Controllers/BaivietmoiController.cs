using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_HQK_shop.Models;
namespace LTW_HQK_shop.Areas.Admin.Controllers
{
    public class BaivietmoiController : Controller
    {
        // GET: Admin/Baivietmoi
        public ActionResult Index()
        {
            return View("~/Areas/Admin/Views/BaivietMoi/Index.cshtml");
        }
       

    }
}