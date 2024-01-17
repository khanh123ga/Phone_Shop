using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_HQK_shop.Models;
namespace LTW_HQK_shop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        ShopEntities1 db = new ShopEntities1();

        public ActionResult Index()
        {
            return View();
        }
        // phương thức lấy giỏ hàng 
        public Cart Getcart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;

            }
            return cart;

        }



        // phương thức thêm vào giỏ hàng 
        public ActionResult AddToCart(int id)
        {
            var sanpham = db.SanPhams.SingleOrDefault(s => s.maSP == id);

            if (sanpham != null)
            {
                Getcart().Add(sanpham);
            }

            return RedirectToAction("ShowToCart", "Cart");
        }


        // phương thức hiển thị giỏ hàng 
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("Index", "Cart");
            Cart cart = Session["Cart"] as Cart;

            return View(cart);


        }

        // phương thức cập nhập giỏ hàng 
        public ActionResult Update(FormCollection from)
        {
            Cart cart = Session["Cart"] as Cart;
            int id = int.Parse(from["id"]);
            int sl = int.Parse(from["sl"]);
            cart.Update(id, sl);
            return RedirectToAction("ShowToCart", "Cart");

        }

        // phương thức xóa mặt hàng  

        public ActionResult Remove(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.xoasanpham(id);
            return RedirectToAction("ShowToCart", "Cart");
        }

        //Tính Item trong vỏ hàng 
        public PartialViewResult BagCart()
        {
            int tong_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            {
                tong_item = cart.tongsoluonghang();
                ViewBag.tong_item = tong_item;
            }
            return PartialView("BagCart");
        }

      
    }
}