using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_HQK_shop.Models;
namespace LTW_HQK_shop.Areas.Admin.Controllers
{
    public class ThemsanphammoiController : Controller
    {
        // GET: Admin/Themsanphammoi
        public ActionResult Index()
        {
            
            return View("~/Areas/Admin/Views/Themsanphammoi/Index.cshtml");
        }
    }
}