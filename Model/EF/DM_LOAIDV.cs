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
        public int MA_LOAIDV { get; set; }

        [Required]
        [StringLength(250)]
        public string TEN_LOAIDV { get; set; }

        public int THU_TU { get; set; }

        public int MA_NHOMDV { get; set; }

        public bool? HOAT_DONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DM_DICHVU> DM_DICHVU { get; set; }

        public virtual DM_NHOMDV DM_NHOMDV { get; set; }
    }
}
