using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_HQK_shop.Models;
namespace LTW_HQK_shop.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("Index", "Cart");
            Cart cart = Session["Cart"] as Cart;

            return View(cart);
        }

        public ActionResult Success()
        {
           

            return View();
        }

        // checkout 
        public ActionResult Index(FormCollection form)
        {
            ShopEntities1 db = new ShopEntities1();
            Cart cart = Session["Cart"] as Cart;
            try
            {

                donHang donhang = new donHang();
                donhang.ngaydat = DateTime.Now;
                donhang.tenKH = form["kh_ten"];
                donhang.soDT = form["kh_dienthoai"];
                donhang.eMail = form["kh_email"];
                donhang.diachigiaohang = form["kh_diachigiaohang"];
                db.donHangs.Add(donhang);
                // dùng vòng lặp lấy item của vỏ hàng để lưu vào bảng  
                foreach (var item in cart.Items)
                {
                    chiTietDH ctdh = new chiTietDH();
                    ctdh.iddh = donhang.iddh;
                    ctdh.maSP = item.sanpham.maSP;
                    ctdh.giaBan = item.sanpham.giaBan;
                    ctdh.soLuong = item.soluong;
                    db.chiTietDHs.Add(ctdh);
                    db.SaveChanges();
                    cart.xoagiohang();
                }


                return RedirectToAction("Success", "Checkout");
            }
            catch
            {
                return Content("Vui Long Kiem Tra Lai Thong Tin");
            }
        

    }

    }
}