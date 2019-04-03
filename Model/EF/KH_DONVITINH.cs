namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_DONVITINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KH_DONVITINH()
        {
            KH_HANGHOA = new HashSet<KH_HANGHOA>();
        }

        [Key]
        public int ID_DVT { get; set; }

        [StringLength(250)]
        public string TEN_DVT { get; set; }

        public int? THU_TU { get; set; }

        public bool? TRANG_THAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KH_HANGHOA> KH_HANGHOA { get; set; }
    }
}
