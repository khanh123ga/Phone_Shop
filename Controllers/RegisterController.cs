using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_HQK_shop.Models;
namespace LTW_HQK_shop.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        ShopEntities1 db = new ShopEntities1();

        [HttpGet]
      
        // hàm đăng ký tài khoản 

        [HttpPost]
        public ActionResult Dangky(Khachhang user)
        {
            // kiểm tra dữ liệu truyền vào 
            if (ModelState.IsValid)
            {
                // check email và sđt có bị trùng lặp
                var checkmail = db.Khachhangs.FirstOrDefault(s => s.eMail == user.eMail);
                var checkphone = db.Khachhangs.FirstOrDefault(s => s.soDT == user.soDT);
                if (checkmail == null || checkphone == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Khachhangs.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.error = "Email và số điện thoại này đã tồn tại";
                    return View();
                }
            }
            return View();
        }
    }
}