namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_KHACHHANG()
        {
            APP_CHITIET_SINHNHAT_KHACHHANG = new HashSet<APP_CHITIET_SINHNHAT_KHACHHANG>();
            APP_KHAOSAT_TRALOI = new HashSet<APP_KHAOSAT_TRALOI>();
            KH_BANHANG = new HashSet<KH_BANHANG>();
            KH_HINH_ANH = new HashSet<KH_HINH_ANH>();
            KH_PHANLOAI_KHACHHANG = new HashSet<KH_PHANLOAI_KHACHHANG>();
            KH_TRAHANG = new HashSet<KH_TRAHANG>();
            TBL_CONGNO_KHACHHANG = new HashSet<TBL_CONGNO_KHACHHANG>();
            TBL_DANGKY_DICHVU = new HashSet<TBL_DANGKY_DICHVU>();
            TBL_TAIKHOAN_KHACHHANG = new HashSet<TBL_TAIKHOAN_KHACHHANG>();
            TBL_TUVAN_DICHVU = new HashSet<TBL_TUVAN_DICHVU>();
        }

        [Key]
        [StringLength(50)]
        public string MA_KHACHHANG { get; set; }

        [StringLength(500)]
        public string HO_TEN { get; set; }

        [StringLength(500)]
        public string DIA_CHI { get; set; }

        [StringLength(50)]
        public string DIEN_THOAI { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        public DateTime? NGAY_SINH { get; set; }

        public bool? GIOI_TINH { get; set; }

        public double? NO_DAU_KY { get; set; }

        [StringLength(50)]
        public string SO_THE { get; set; }

        public DateTime? NGAY_KICHHOAT { get; set; }

        public DateTime? NGAY_HETHAN { get; set; }

        public double? SO_TIEN { get; set; }

        public double? TIEN_SU_DUNG_DV { get; set; }

        public int? DIEM_TICH_LUY { get; set; }

        public bool? KICHHOAT_THE { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }

        public bool NGUNG_HOATDONG { get; set; }

        [StringLength(10)]
        public string SO_CMND { get; set; }

        [StringLength(250)]
        public string MAT_KHAU { get; set; }

        public DateTime? MODIFIED { get; set; }
        public bool? BIRTHDAY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APP_CHITIET_SINHNHAT_KHACHHANG> APP_CHITIET_SINHNHAT_KHACHHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APP_KHAOSAT_TRALOI> APP_KHAOSAT_TRALOI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_BANHANG> KH_BANHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_HINH_ANH> KH_HINH_ANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_PHANLOAI_KHACHHANG> KH_PHANLOAI_KHACHHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_TRAHANG> KH_TRAHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_CONGNO_KHACHHANG> TBL_CONGNO_KHACHHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_DANGKY_DICHVU> TBL_DANGKY_DICHVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_TAIKHOAN_KHACHHANG> TBL_TAIKHOAN_KHACHHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_TUVAN_DICHVU> TBL_TUVAN_DICHVU { get; set; }
    }
}
