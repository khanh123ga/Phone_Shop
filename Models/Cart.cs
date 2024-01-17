using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTW_HQK_shop.Models
{

    public class CartItem
    {
        public SanPham sanpham { get; set; }
        public int soluong { get; set; }
    }

    // gio hang
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();

        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }

        // them vao gio hang
        public void Add(SanPham sp, int sl = 1)
        {
            var item = items.FirstOrDefault(s => s.sanpham.maSP == sp.maSP);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    sanpham = sp,
                    soluong = sl
                });

            }
            else
            {
                item.soluong += sl;
            }
        }

        // phuong thuc update 
        public void Update(int id, int sl)
        {
            var item = items.Find(s => s.sanpham.maSP == id);
            if (item != null)
            {
                item.soluong = sl;
            }
        }

        //phuong thuc tong gia tien
        public double tongtien()
        {
            var tongtien = items.Sum(s => s.sanpham.giaBan * s.soluong);
            return tongtien;
        }

        // phuong thuc xoa san pham 

        public void xoasanpham(int id)
        {
            items.RemoveAll(x => x.sanpham.maSP == id);
        }

        // phuong thuc tinh tong so luong mua sam 
        public int tongsoluonghang()
        {
            return items.Sum(s => s.soluong);
        }
        // xoa gio hang de thuc hien oder
        public void xoagiohang()
        {
            items.Clear(); 
        }

    }
}