namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_PHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_PHONG()
        {
            TBL_GIUONG = new HashSet<TBL_GIUONG>();
            TBL_LICHHEN = new HashSet<TBL_LICHHEN>();
        }

        [Key]
        public int ID_PHONG { get; set; }

        [StringLength(500)]
        public string TEN_PHONG { get; set; }

        [StringLength(500)]
        public string MO_TA { get; set; }

        public int? ID_TANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_GIUONG> TBL_GIUONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_LICHHEN> TBL_LICHHEN { get; set; }

        public virtual TBL_TANG TBL_TANG { get; set; }
    }
}
