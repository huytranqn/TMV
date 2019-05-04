namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DM_LOAIDV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DM_LOAIDV()
        {
            DM_DICHVU = new HashSet<DM_DICHVU>();
        }

        [Key]
        [Display(Name = "STT")]
        public int MA_LOAIDV { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tên lọai dịch vụ")]
        public string TEN_LOAIDV { get; set; }

        [Display(Name = "Thứ tụ")]
        public int THU_TU { get; set; }

        [Display(Name = "Nhóm dịch vụ")]
        public int MA_NHOMDV { get; set; }

        [Display(Name = "Trạng thái")]
        public bool? HOAT_DONG { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình ảnh")]
        public string HINH_ANH { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? MODIFIED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DM_DICHVU> DM_DICHVU { get; set; }

        public virtual DM_NHOMDV DM_NHOMDV { get; set; }
    }
}
