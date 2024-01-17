using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_HQK_shop.Models;
namespace LTW_HQK_shop.Areas.Admin.Controllers
{
    public class LoaisanphamController : Controller
    {
        private static bool capnhap = false;
        // GET: Admin/Loaisanpham
        [HttpGet]
        public ActionResult Index()
        {
           
            List<LoaiSP> lsp = new ShopEntities1().LoaiSPs.OrderBy(x => x.tenLoai).ToList<LoaiSP>();
            ViewData["danhsachloai"] = lsp;
            //return RedirectToAction("Index", "Loaisanpham", new { Areas = "Admin" });
            return View("~/Areas/Admin/Views/Loaisanpham/Index.cshtml");
        }

        public ActionResult Themloai(LoaiSP x)
        {
            ShopEntities1 db = new ShopEntities1();
            // add loại san pham 
            if (!capnhap)
            {
                db.LoaiSPs.Add(x);

            }
            else
            {
                LoaiSP y = db.LoaiSPs.Find(x.maLoai);
                y.tenLoai = x.tenLoai;
                y.ghichu = x.ghichu;
                capnhap = false;
            }

            db.SaveChanges();
            // cập nhập lên view
            if (ModelState.IsValid)
                ModelState.Clear();
            List<LoaiSP> lsp = db.LoaiSPs.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            ViewData["danhsachloai"] = lsp;
            return View("~/Areas/Admin/Views/Loaisanpham/Index.cshtml");

        }
        [HttpPost]
        public ActionResult Xoa(int maloai)
        {
            ShopEntities1 db = new ShopEntities1();
            LoaiSP x = db.LoaiSPs.Find(maloai);
            db.LoaiSPs.Remove(x);
            db.SaveChanges();
            List<LoaiSP> lsp = db.LoaiSPs.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            ViewData["danhsachloai"] = lsp;

            return View("~/Areas/Admin/Views/Loaisanpham/Index.cshtml");

        }

        [HttpPost]
        public ActionResult Chinhsua(int maloai)
        {
            ShopEntities1 db = new ShopEntities1();
            LoaiSP x = db.LoaiSPs.Find(maloai);
            capnhap = true;
            List<LoaiSP> lsp = db.LoaiSPs.OrderBy(z => z.tenLoai).ToList<LoaiSP>();
            ViewData["danhsachloai"] = lsp;

            return View("~/Areas/Admin/Views/Loaisanpham/Index.cshtml", x);


        }


    }
}