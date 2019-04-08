namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class APP_SINHNHAT_KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public APP_SINHNHAT_KHACHHANG()
        {
            APP_CHITIET_SINHNHAT_KHACHHANG = new HashSet<APP_CHITIET_SINHNHAT_KHACHHANG>();
        }

        [Key]
        public int ID_SINHNHAT { get; set; }

        [Column(TypeName = "ntext")]
        [Display (Name ="Nội Dung")]
        public string NOI_DUNG { get; set; }

        public bool? TRANG_THAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APP_CHITIET_SINHNHAT_KHACHHANG> APP_CHITIET_SINHNHAT_KHACHHANG { get; set; }
    }
}
