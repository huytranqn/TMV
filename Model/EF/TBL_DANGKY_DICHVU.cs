namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_DANGKY_DICHVU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_DANGKY_DICHVU()
        {
            TBL_CHITIET_DANGKY_DICHVU = new HashSet<TBL_CHITIET_DANGKY_DICHVU>();
            TBL_LICHHEN = new HashSet<TBL_LICHHEN>();
        }

        [Key]
        public int ID_DANGKY { get; set; }

        [StringLength(50)]
        public string MA_KHACHHANG { get; set; }

        [StringLength(50)]
        public string NHANVIEN_LAP { get; set; }

        public DateTime? NGAY_LAP { get; set; }

        public double? TONGTIEN_DICHVU { get; set; }

        public double? TONGTIEN_GIAMGIA { get; set; }

        public double? TONGTIEN_THANHTOAN { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }

        public bool? HOAT_DONG { get; set; }

        public double? TIEN_THE { get; set; }

        public double? TIEN_MAT { get; set; }

        [StringLength(250)]
        public string NV_BANDICHVU { get; set; }

        public DateTime? MODIFIED { get; set; }

        public bool? LOAI_DANGKY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_CHITIET_DANGKY_DICHVU> TBL_CHITIET_DANGKY_DICHVU { get; set; }

        public virtual TBL_KHACHHANG TBL_KHACHHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_LICHHEN> TBL_LICHHEN { get; set; }
    }
}
