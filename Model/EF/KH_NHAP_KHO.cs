namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_NHAP_KHO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KH_NHAP_KHO()
        {
            KH_CHITIET_NHAPKHO = new HashSet<KH_CHITIET_NHAPKHO>();
        }

        [Key]
        [StringLength(50)]
        public string MA_NHAPKHO { get; set; }

        public int? ID_KHO { get; set; }

        public DateTime? NGAY_NHAP { get; set; }

        [StringLength(50)]
        public string NHANVIEN_NHAP { get; set; }

        public int? NHA_CUNG_CAP { get; set; }

        public double? TONG_SL { get; set; }

        public double? TONG_DG { get; set; }

        public double? TONG_TT { get; set; }

        public double? CHIET_KHAU { get; set; }

        public double? TIEN_CK { get; set; }

        public double? THUE_VAT { get; set; }

        public double? TIENTHUE_VAT { get; set; }

        public double? TONGTIEN_SAUTHUE { get; set; }

        public double? TIENTRA_NCC { get; set; }

        public double? TIENNO_NCC { get; set; }

        public int? PHUONGTHUC_THANHTOAN { get; set; }

        [StringLength(250)]
        public string BANG_CHU { get; set; }

        public bool? TRANG_THAI { get; set; }

        [StringLength(250)]
        public string GHI_CHU { get; set; }

        public int? THU_TU { get; set; }

        public DateTime? MODIFIED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_CHITIET_NHAPKHO> KH_CHITIET_NHAPKHO { get; set; }

        public virtual KH_KHO KH_KHO { get; set; }

        public virtual KH_NHA_CUNG_CAP KH_NHA_CUNG_CAP { get; set; }
    }
}
