//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LTW_HQK_shop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Adminn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adminn()
        {
            this.BaiViets = new HashSet<BaiViet>();
            this.donHangs = new HashSet<donHang>();
            this.SanPhams = new HashSet<SanPham>();
        }
    
        public string taikhoan { get; set; }
        public string hodem { get; set; }
        public string hoten { get; set; }
        public string diachi { get; set; }
        public string matKhau { get; set; }
        public string soDT { get; set; }
        public string eMail { get; set; }
        public string gioitinh { get; set; }
        public bool trangthai { get; set; }
        public string ghichu { get; set; }
        public string hinhDD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet> BaiViets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<donHang> donHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
