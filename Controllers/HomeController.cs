using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_HQK_shop.Models;
namespace LTW_HQK_shop.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        // hàm lấy danh sách sản phẩm
        public ActionResult Index()
        {

            ShopEntities1 db = new ShopEntities1();
            List<SanPham> sanpham = db.SanPhams.ToList();
            List<LoaiSP> loaisp = db.LoaiSPs.ToList();
            ViewData["danhsachsanpham"] = sanpham;
            ViewData["loaisanpham"] = loaisp;
            return View();
        }

        //chi tiết sản phẩm
        public ActionResult Detail(int id)
        {
            ShopEntities1 db = new ShopEntities1();
            var chitietsanpham = db.SanPhams.Where(n => n.maSP == id).FirstOrDefault();
            return View(chitietsanpham);
        }

        //hàm lấy danh sách sản phẩm theo loại
        public ActionResult ProductCatogary(int id)
        {
            ShopEntities1 db = new ShopEntities1();
            var phanloaisanpham = db.SanPhams.Where(n => n.maLoai == id).OrderByDescending(z => z.ngaydang).ToList();
            return View(phanloaisanpham);
        }

    }
}