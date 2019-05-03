namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class APP_KHAOSAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public APP_KHAOSAT()
        {
            APP_KHAOSAT_TRALOI = new HashSet<APP_KHAOSAT_TRALOI>();
        }

        [Key]
        public int ID_KHAOSAT { get; set; }

        [StringLength(500)]
        public string NOIDUNG_KHAOSAT { get; set; }

        [StringLength(50)]
        public string PHUONGAN_1 { get; set; }

        [StringLength(50)]
        public string PHUONGAN_2 { get; set; }

        [StringLength(50)]
        public string PHUONGAN_3 { get; set; }

        [StringLength(50)]
        public string TRA_LOI { get; set; }

        public bool TRANG_THAI { get; set; }

        public DateTime? MODIFIED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APP_KHAOSAT_TRALOI> APP_KHAOSAT_TRALOI { get; set; }
    }
}
