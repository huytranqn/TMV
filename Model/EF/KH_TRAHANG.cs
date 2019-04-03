namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_TRAHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KH_TRAHANG()
        {
            KH_CHITIET_TRAHANG = new HashSet<KH_CHITIET_TRAHANG>();
        }

        [Key]
        [StringLength(50)]
        public string MA_TRAHANG { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_BANHANG { get; set; }

        public DateTime NGAY_TRAHANG { get; set; }

        [Required]
        [StringLength(50)]
        public string KHACHHANG_TRA { get; set; }

        [Required]
        [StringLength(50)]
        public string NHANVIEN_TRA { get; set; }

        public double? TONGTIEN_HANGHOA { get; set; }

        public double? TONGTIEN_GIAMGIA { get; set; }

        public double? TONGTIEN_THANHTOAN { get; set; }

        public double? TONGTIEN_KHACHTRA { get; set; }

        public double? CONGNO_CU { get; set; }

        public double? TONGTIEN_CONLAI { get; set; }

        public int? PHUONGTHUC_THANHTOAN { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }

        public bool TRANG_THAI { get; set; }

        public int? THU_TU { get; set; }

        public virtual HT_NHANVIEN HT_NHANVIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_CHITIET_TRAHANG> KH_CHITIET_TRAHANG { get; set; }

        public virtual TBL_KHACHHANG TBL_KHACHHANG { get; set; }
    }
}
