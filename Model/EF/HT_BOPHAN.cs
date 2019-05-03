namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HT_BOPHAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HT_BOPHAN()
        {
            HT_NHANVIEN = new HashSet<HT_NHANVIEN>();
        }

        [Key]
        public int MA_BOPHAN { get; set; }

        [Required]
        [StringLength(500)]
        public string TEN_BOPHAN { get; set; }

        public bool? TRANG_THAI { get; set; }

        public DateTime? MODIFIED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HT_NHANVIEN> HT_NHANVIEN { get; set; }
    }
}
