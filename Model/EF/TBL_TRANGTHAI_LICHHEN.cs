namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_TRANGTHAI_LICHHEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_TRANGTHAI_LICHHEN()
        {
            TBL_LICHHEN = new HashSet<TBL_LICHHEN>();
        }

        [Key]
        public int ID_TRANGTHAI { get; set; }

        [Required]
        [StringLength(500)]
        public string TEN_TRANGTHAI { get; set; }

        public int THU_TU { get; set; }

        public DateTime? MODIFIED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_LICHHEN> TBL_LICHHEN { get; set; }
    }
}
