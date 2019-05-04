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
        [Display(Name = "STT")]
        public int MA_DICHVU { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tên dịch vụ")]
        public string TEN_DICHVU { get; set; }

        [Display(Name = "Mã dịch vụ")]
        public int MA_LOAIDV { get; set; }

        [Display(Name = "Giá dịch vụ")]
        public double GIA_DICHVU { get; set; }

        [Display(Name = "Gía khuyễn mãi")]
        public double? GIA_KHUYENMAI { get; set; }

        [StringLength(50)]
        [Display(Name = "Thời gian làm việc")]
        public string THOIGIAN_LAMVIEC { get; set; }

        [Display(Name = "Thứ tự")]
        public int THU_TU { get; set; }

        [Display(Name = "Trạng thái")]
        public bool NGUNG_KINHDOANH { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình ảnh")]
        public string HINH_ANH { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả chi tiết")]
        public string MOTA_CHITIET { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? MODIFIED { get; set; }

        [Display(Name = "Loại dịch vụ")]
        public virtual DM_LOAIDV DM_LOAIDV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_CHITIET_DANGKY_DICHVU> TBL_CHITIET_DANGKY_DICHVU { get; set; }
    }
}
