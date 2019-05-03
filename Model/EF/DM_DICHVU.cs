namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DM_DICHVU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DM_DICHVU()
        {
            TBL_CHITIET_DANGKY_DICHVU = new HashSet<TBL_CHITIET_DANGKY_DICHVU>();
        }

        [Key]
        public int MA_DICHVU { get; set; }

        [Required]
        [StringLength(250)]
        public string TEN_DICHVU { get; set; }

        public int MA_LOAIDV { get; set; }

        public double GIA_DICHVU { get; set; }

        public double? GIA_KHUYENMAI { get; set; }

        [StringLength(50)]
        public string THOIGIAN_LAMVIEC { get; set; }

        public int THU_TU { get; set; }

        public bool NGUNG_KINHDOANH { get; set; }

        [StringLength(50)]
        public string HINH_ANH { get; set; }

        [Column(TypeName = "ntext")]
        public string MOTA_CHITIET { get; set; }

        public DateTime? MODIFIED { get; set; }

        public virtual DM_LOAIDV DM_LOAIDV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_CHITIET_DANGKY_DICHVU> TBL_CHITIET_DANGKY_DICHVU { get; set; }
    }
}
