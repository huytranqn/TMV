namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_KHO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KH_KHO()
        {
            KH_CHITIET_TRAHANG = new HashSet<KH_CHITIET_TRAHANG>();
            KH_NHAP_KHO = new HashSet<KH_NHAP_KHO>();
            KH_TONKHO = new HashSet<KH_TONKHO>();
        }

        [Key]
        public int ID_KHO { get; set; }

        [StringLength(250)]
        public string TEN_KHO { get; set; }

        [StringLength(500)]
        public string DIA_CHI { get; set; }

        [StringLength(50)]
        public string DIEN_THOAI { get; set; }

        public bool? TRANG_THAI { get; set; }

        public DateTime? MODIFIED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_CHITIET_TRAHANG> KH_CHITIET_TRAHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_NHAP_KHO> KH_NHAP_KHO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_TONKHO> KH_TONKHO { get; set; }
    }
}
