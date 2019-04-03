namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_HANGHOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KH_HANGHOA()
        {
            KH_CHITIET_BANHANG = new HashSet<KH_CHITIET_BANHANG>();
            KH_CHITIET_TRAHANG = new HashSet<KH_CHITIET_TRAHANG>();
            KH_TONKHO = new HashSet<KH_TONKHO>();
        }

        [Key]
        [StringLength(50)]
        public string MA_HANGHOA { get; set; }

        [Required]
        [StringLength(250)]
        public string TEN_HANGHOA { get; set; }

        public double DON_GIA { get; set; }

        [StringLength(500)]
        public string MO_TA { get; set; }

        public int ID_DVT { get; set; }

        [StringLength(500)]
        public string HINH_ANH { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }

        public bool TRANG_THAI { get; set; }

        public int ID_NHOMHH { get; set; }

        public int THU_TU { get; set; }

        public int? ID_NCC { get; set; }

        [StringLength(50)]
        public string MA_VACH { get; set; }

        [Column(TypeName = "ntext")]
        public string MOTA_CHITIET { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_CHITIET_BANHANG> KH_CHITIET_BANHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_CHITIET_TRAHANG> KH_CHITIET_TRAHANG { get; set; }

        public virtual KH_DONVITINH KH_DONVITINH { get; set; }

        public virtual KH_NHA_CUNG_CAP KH_NHA_CUNG_CAP { get; set; }

        public virtual KH_NHOMHANGHOA KH_NHOMHANGHOA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_TONKHO> KH_TONKHO { get; set; }
    }
}
