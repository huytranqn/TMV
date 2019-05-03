namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_LICHHEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_LICHHEN()
        {
            TBL_CHITIET_LICHHEN = new HashSet<TBL_CHITIET_LICHHEN>();
        }

        [Key]
        public int ID_LICHHEN { get; set; }

        public DateTime? NGAY_HEN { get; set; }

        public int? TRANGTHAI_HEN { get; set; }

        public int? PHONG_THUCHIEN { get; set; }

        public int? GIUONG_THUCHIEN { get; set; }

        public int? ID_DANGKY { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }

        public bool? THANH_TOAN { get; set; }

        public DateTime? MODIFIED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_CHITIET_LICHHEN> TBL_CHITIET_LICHHEN { get; set; }

        public virtual TBL_DANGKY_DICHVU TBL_DANGKY_DICHVU { get; set; }

        public virtual TBL_PHONG TBL_PHONG { get; set; }

        public virtual TBL_TRANGTHAI_LICHHEN TBL_TRANGTHAI_LICHHEN { get; set; }
    }
}
