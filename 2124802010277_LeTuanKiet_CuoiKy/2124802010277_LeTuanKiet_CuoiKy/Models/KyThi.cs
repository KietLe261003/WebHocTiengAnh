//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _2124802010277_LeTuanKiet_CuoiKy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KyThi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KyThi()
        {
            this.CauHois = new HashSet<CauHoi>();
            this.ChiTietThiSinhs = new HashSet<ChiTietThiSinh>();
        }
    
        public string IdKyThi { get; set; }
        public string TenKyThi { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
        public Nullable<int> SoThiSinh { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public Nullable<bool> TinhTrang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CauHoi> CauHois { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietThiSinh> ChiTietThiSinhs { get; set; }
    }
}
