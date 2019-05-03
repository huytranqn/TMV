namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_TANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_TANG()
        {
            TBL_PHONG = new HashSet<TBL_PHONG>();
        }

        [Key]
        public int ID_TANG { get; set; }

        [StringLength(500)]
        public string TEN_TANG { get; set; }

        public DateTime? MODIFIED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_PHONG> TBL_PHONG { get; set; }
    }
}
