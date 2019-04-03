namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_BANHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KH_BANHANG()
        {
            KH_CHITIET_BANHANG = new HashSet<KH_CHITIET_BANHANG>();
        }

        [Key]
        [StringLength(50)]
        public string MA_XUATKHO { get; set; }

        public DateTime NGAY_XUAT { get; set; }

        [Required]
        [StringLength(50)]
        public string NV_XUAT { get; set; }

        [StringLength(50)]
        public string KHACHHANG_MUA { get; set; }

        public double? TONGTIEN_HANGHOA { get; set; }

        public double? TONGTIEN_GIAMGIA { get; set; }

        public double? TONGTIEN_THANHTOAN { get; set; }

        public double? TONGTIEN_TRA { get; set; }

        public double? TONGTIEN_CONLAI { get; set; }

        public bool TRANG_THAI { get; set; }

        public int THU_TU { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }

        public int? PHUONGTHUC_THANHTOAN { get; set; }

        [StringLength(50)]
        public string NV_BAN { get; set; }

        public int? TRANGTHAI_PHIEU { get; set; }

        public virtual HT_NHANVIEN HT_NHANVIEN { get; set; }

        public virtual TBL_KHACHHANG TBL_KHACHHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_CHITIET_BANHANG> KH_CHITIET_BANHANG { get; set; }
    }
}
