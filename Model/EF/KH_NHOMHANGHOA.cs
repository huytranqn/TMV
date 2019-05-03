namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_NHOMHANGHOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KH_NHOMHANGHOA()
        {
            KH_HANGHOA = new HashSet<KH_HANGHOA>();
        }

        [Key]
        public int ID_NHOMHH { get; set; }

        [Required]
        [StringLength(250)]
        public string TEN_NHOMHH { get; set; }

        public int THU_TU { get; set; }

        public bool TRANG_THAI { get; set; }

        [StringLength(50)]
        public string HINH_ANH { get; set; }

        public DateTime? MODIFIED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_HANGHOA> KH_HANGHOA { get; set; }
    }
}
