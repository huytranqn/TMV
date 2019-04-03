namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_NHA_CUNG_CAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KH_NHA_CUNG_CAP()
        {
            KH_CONGNO_NHACUNGCAP = new HashSet<KH_CONGNO_NHACUNGCAP>();
            KH_HANGHOA = new HashSet<KH_HANGHOA>();
            KH_NHAP_KHO = new HashSet<KH_NHAP_KHO>();
        }

        [Key]
        public int ID_NCC { get; set; }

        [Required]
        [StringLength(250)]
        public string TEN_NCC { get; set; }

        [StringLength(250)]
        public string DIA_CHI { get; set; }

        [StringLength(50)]
        public string DIEN_THOAI { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(50)]
        public string WEBSITE { get; set; }

        public bool TRANG_THAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_CONGNO_NHACUNGCAP> KH_CONGNO_NHACUNGCAP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_HANGHOA> KH_HANGHOA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_NHAP_KHO> KH_NHAP_KHO { get; set; }
    }
}
