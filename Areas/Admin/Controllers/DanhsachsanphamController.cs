using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_HQK_shop.Models;
namespace LTW_HQK_shop.Areas.Admin.Controllers
{
    public class DanhsachsanphamController : Controller
    {
        // GET: Admin/Danhsachsanpham
        public ActionResult Index()
        {
           
                List<SanPham> sp = new ShopEntities1().SanPhams.OrderByDescending(x => x.ngaydang).ToList<SanPham>();
                ViewData["danhsachsanpham"] = sp;
                //return RedirectToAction("Index", "Danhsachsanpham", new { Areas = "Admin" });
                return View("~/Areas/Admin/Views/Danhsachsanpham/Index.cshtml");

        }
        [HttpPost]
        public ActionResult Xoa(string masp)
        {
            ShopEntities1 shop = new ShopEntities1();
            SanPham x = shop.SanPhams.Find(masp);
            shop.SanPhams.Remove(x);
            shop.SaveChanges();
            ViewData["danhsachsanpham"] = shop.SanPhams.OrderByDescending(m => m.ngaydang).ToList<SanPham>();
            return View("~/Areas/Admin/Views/Danhsachsanpham/Index.cshtml");
        }

        public ActionResult Duyet(int masp)
        {
            ShopEntities1 shop = new ShopEntities1();
            SanPham x = shop.SanPhams.Find(masp);
            if (x.daduyet == true)
            {
                x.daduyet = false;
            }
            else
            {
                x.daduyet = true;
            }
            shop.SaveChanges();
            ViewData["danhsachsanpham"] = shop.SanPhams.OrderByDescending(m => m.ngaydang).ToList<SanPham>();
            return View("~/Areas/Admin/Views/Danhsachsanpham/Index.cshtml");
        }

        [HttpGet]
        public ActionResult Chinhsua(int masp)
        {
            ShopEntities1 db = new ShopEntities1();
            SanPham sp = db.SanPhams.Where(m => m.maSP.Equals(masp)).FirstOrDefault();
            return View(sp);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Chinhsua(SanPham x, int loaiSP, HttpPostedFileBase hinhSP)
        {
            ShopEntities1 db = new ShopEntities1();
            SanPham y = db.SanPhams.Find(x.maSP);
            y.maSP = x.maSP;
            y.tenSP = x.tenSP;
            y.ndtomtat = x.ndtomtat;
            y.ngaydang = x.ngaydang;
            y.daduyet = x.daduyet;
            y.maLoai = loaiSP;
            y.taikhoan = x.taikhoan;
            if (hinhSP != null)
            {
                //Vị trí lưu hình
                string virPath = "/Images/";
                string phyPath = Server.MapPath("~/" + virPath);
                string EXT = Path.GetExtension(hinhSP.FileName);
                string nameF = "HDD" + x.maSP + EXT;
                hinhSP.SaveAs(phyPath + nameF);
                y.hinhDD = virPath + nameF;
            }
            db.SaveChanges();
            if (ModelState.IsValid)
                ModelState.Clear();
            return RedirectToAction("~/Areas/Admin/Views/Danhsachsanpham/Index.cshtml");


        }
     }
}