using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_HQK_shop.Models;
namespace LTW_HQK_shop.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // chứng thực 

        //login admin
        public ActionResult Index(string acc, string pass)
        {
            string mk = Security.maHoaSHA256(pass);
            Adminn ttdn = new ShopEntities1().Adminns.Where(x => x.taikhoan.Equals(acc.ToLower().Trim()) && x.matKhau.Equals(pass)).First<Adminn>();
            bool isAuthentic = ttdn == null && ttdn.taikhoan.Equals(acc.ToLower().Trim()) && ttdn.matKhau.Equals(pass);
            if (!isAuthentic)
            {
                Session["TTdangnhap"] = ttdn;

                //return RedirectToAction("Index", "Trangchu", new { Areas = "Admin" });
                return View("~/Areas/Admin/Views/Trangchu/Index.cshtml");
            }
            return RedirectToAction("Index", "Login");



        }

       
    }
}