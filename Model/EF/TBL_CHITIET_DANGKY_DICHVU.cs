namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_CHITIET_DANGKY_DICHVU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_CHITIET_DANGKY_DICHVU()
        {
            TBL_CHITIET_LICHHEN = new HashSet<TBL_CHITIET_LICHHEN>();
        }

        [Key]
        public int ID_CHITIET_DKDV { get; set; }

        public int ID_DANGKY { get; set; }

        public int MA_DICHVU { get; set; }

        public double? DON_GIA { get; set; }

        public int? SO_LUONG { get; set; }

        public int? SO_LUONG_CON_LAI { get; set; }

        public double? THANH_TIEN { get; set; }

        public bool? CT_UUDAI { get; set; }

        public double? GIATRI_UUDAI { get; set; }

        public double? TONG_TIEN { get; set; }

        public bool? TRANG_THAI { get; set; }

        public DateTime? MODIFIED { get; set; }

        public virtual DM_DICHVU DM_DICHVU { get; set; }

        public virtual TBL_DANGKY_DICHVU TBL_DANGKY_DICHVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_CHITIET_LICHHEN> TBL_CHITIET_LICHHEN { get; set; }
    }
}
