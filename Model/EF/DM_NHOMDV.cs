namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DM_NHOMDV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DM_NHOMDV()
        {
            DM_LOAIDV = new HashSet<DM_LOAIDV>();
        }

        [Key]
        public int MA_NHOMDV { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tên Nhóm")]
        public string TEN_NHOMDV { get; set; }

        [Display(Name = "Thứ Tự")]
        public int THU_TU { get; set; }

        [StringLength(250)]
        [Display(Name = "Khu Dịch Vụ")]
        public string KHU_DV { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình Ảnh")]
        public string HINH_ANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DM_LOAIDV> DM_LOAIDV { get; set; }
    }
}
