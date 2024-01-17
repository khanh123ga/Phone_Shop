using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_HQK_shop.Models;
namespace LTW_HQK_shop.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            ShopEntities1 db = new ShopEntities1();
            List<BaiViet> baiviet = db.BaiViets.ToList();
            return View(baiviet);
        }
        public ActionResult Chitietbaiviet(string mabv)
        {
            ShopEntities1 db = new ShopEntities1();
            BaiViet bv = db.BaiViets.Where(s => s.mabv == mabv).First<BaiViet>();
            return View(bv);
        }
    }
}