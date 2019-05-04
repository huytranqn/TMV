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
        [Display(Name ="Nội dung")]
        public string NOIDUNG_KHAOSAT { get; set; }

        [StringLength(50)]
        [Display(Name = "Phương án 1")]
        public string PHUONGAN_1 { get; set; }

        [StringLength(50)]
        [Display(Name = "Phương án 2")]
        public string PHUONGAN_2 { get; set; }

        [StringLength(50)]
        [Display(Name = "Phương án 3")]
        public string PHUONGAN_3 { get; set; }

        [StringLength(50)]
        [Display(Name = "Đáp án")]
        public string TRA_LOI { get; set; }

        [Display(Name = "Trạng thái")]
        public bool TRANG_THAI { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? MODIFIED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APP_KHAOSAT_TRALOI> APP_KHAOSAT_TRALOI { get; set; }
    }
}
