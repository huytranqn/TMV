namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_LOAI_KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KH_LOAI_KHACHHANG()
        {
            KH_PHANLOAI_KHACHHANG = new HashSet<KH_PHANLOAI_KHACHHANG>();
        }

        [Key]
        public int ID_LOAIKH { get; set; }

        [Required]
        [StringLength(250)]
        public string TEN_LOAIKH { get; set; }

        public bool? TRANG_THAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_PHANLOAI_KHACHHANG> KH_PHANLOAI_KHACHHANG { get; set; }
    }
}
