namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HT_NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HT_NHANVIEN()
        {
            KH_BANHANG = new HashSet<KH_BANHANG>();
            KH_TRAHANG = new HashSet<KH_TRAHANG>();
            TBL_CHITIET_NHANVIEN_LICHHEN = new HashSet<TBL_CHITIET_NHANVIEN_LICHHEN>();
        }

        [Key]
        [StringLength(50)]
        public string TEN_DANGNHAP { get; set; }

        [StringLength(50)]
        public string MAT_KHAU { get; set; }

        [StringLength(500)]
        public string TEN_NHANVIEN { get; set; }

        [StringLength(500)]
        public string DIA_CHI { get; set; }

        [StringLength(50)]
        public string SO_DIENTHOAI { get; set; }

        public int? MA_BOPHAN { get; set; }

        public bool? HOAT_DONG { get; set; }

        public DateTime? MODIFIED { get; set; }

        public virtual HT_BOPHAN HT_BOPHAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_BANHANG> KH_BANHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_TRAHANG> KH_TRAHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_CHITIET_NHANVIEN_LICHHEN> TBL_CHITIET_NHANVIEN_LICHHEN { get; set; }
    }
}
