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
    
    public partial class Khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Khachhang()
        {
            this.donHangs = new HashSet<donHang>();
        }
    
        public string makh { get; set; }
        public string tenkh { get; set; }
        public string matKhau { get; set; }
        public string soDT { get; set; }
        public string eMail { get; set; }
        public Nullable<bool> gioitinh { get; set; }
        public string diachi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<donHang> donHangs { get; set; }
    }
}
