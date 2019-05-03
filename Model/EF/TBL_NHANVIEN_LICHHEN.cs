namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_NHANVIEN_LICHHEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_NHANVIEN_LICHHEN()
        {
            TBL_CHITIET_NHANVIEN_LICHHEN = new HashSet<TBL_CHITIET_NHANVIEN_LICHHEN>();
        }

        [Key]
        public int ID_THUCHIEN { get; set; }

        public int ID_CHITIET { get; set; }

        [Required]
        [StringLength(50)]
        public string THOIGIAN_TU { get; set; }

        [Required]
        [StringLength(50)]
        public string THOIGIAN_DEN { get; set; }

        public DateTime? MODIFIED { get; set; }

        public virtual TBL_CHITIET_LICHHEN TBL_CHITIET_LICHHEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_CHITIET_NHANVIEN_LICHHEN> TBL_CHITIET_NHANVIEN_LICHHEN { get; set; }
    }
}
