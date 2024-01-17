using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTW_HQK_shop.Models;
namespace LTW_HQK_shop.Areas.Admin.Controllers
{
    public class DanhsachbaivietController : Controller
    {
        ShopEntities1 db = new ShopEntities1();
        // GET: Admin/Danhsachbaiviet
        public ActionResult Index()
        {
            ShopEntities1 db = new ShopEntities1();
            var danhsachbv = db.BaiViets.ToList();
            return View(danhsachbv);
            //return RedirectToAction("Index", "Danhsachbaiviet", new { Areas = "Admin" });
            //return View("~/Areas/Admin/Views/Danhsachbaiviet/Index.cshtml");
        }
        public ActionResult Delete(string maBV)
        {
            BaiViet bv = db.BaiViets.Find(maBV);
            db.BaiViets.Remove(bv);
            db.SaveChanges();
            capNhatGiaoDien();
            return View("Index");
        }
        [HttpPost]
        public ActionResult Active(string maBV)
        {
            BaiViet bv = db.BaiViets.Find(maBV);
            if (bv.daduyet == true)
            {
                bv.daduyet = false;
            }
            else
            {
                bv.daduyet = true;
            }
            db.SaveChanges();
            capNhatGiaoDien();
            return View("Index");
        }
        [HttpGet]
        public ActionResult UpdateBV(string maBV)
        {
            BaiViet bv = db.BaiViets.Where(m => m.mabv.Equals(maBV)).FirstOrDefault();
            return View(bv);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdateBV(BaiViet x, HttpPostedFileBase hinhDaiDien)
        {
            BaiViet y = db.BaiViets.Find(x.mabv);
            y.mabv = x.mabv;
            y.tenbv = x.tenbv;
            y.ndtomtat = x.ndtomtat;
            y.noidung = x.noidung;
            y.ngaydang = x.ngaydang;
            y.daduyet = x.daduyet;
            y.taikhoan = x.taikhoan;
            if (hinhDaiDien != null)
            {
                //Vị trí lưu hình
                string virPath = "/Assets/Images/tintuc/";
                string phyPath = Server.MapPath("~/" + virPath);
                string EXT = Path.GetExtension(hinhDaiDien.FileName);
                string nameF = "HDD" + x.mabv + EXT;
                hinhDaiDien.SaveAs(phyPath + nameF);
                y.hinhDD = virPath + nameF;
            }
            db.SaveChanges();
            if (ModelState.IsValid)
                ModelState.Clear();
            return RedirectToAction("Index");
        }
        private void capNhatGiaoDien()
        {
            List<BaiViet> bv = db.BaiViets.OrderByDescending(m => m.ngaydang).ToList<BaiViet>();
            ViewData["DanhSachBV"] = bv;
        }
    }
}