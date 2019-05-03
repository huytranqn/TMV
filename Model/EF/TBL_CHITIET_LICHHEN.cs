namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_CHITIET_LICHHEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_CHITIET_LICHHEN()
        {
            TBL_NHANVIEN_LICHHEN = new HashSet<TBL_NHANVIEN_LICHHEN>();
        }

        [Key]
        public int ID_CHITIET { get; set; }

        public int? ID_LICHHEN { get; set; }

        public int? ID_CHITIET_DKDV { get; set; }

        public int? TRANG_THAI_LH { get; set; }

        public int? TT_THANHTOAN { get; set; }

        public DateTime? MODIFIED { get; set; }

        public virtual TBL_CHITIET_DANGKY_DICHVU TBL_CHITIET_DANGKY_DICHVU { get; set; }

        public virtual TBL_LICHHEN TBL_LICHHEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_NHANVIEN_LICHHEN> TBL_NHANVIEN_LICHHEN { get; set; }
    }
}
