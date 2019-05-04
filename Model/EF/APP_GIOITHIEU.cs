namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class APP_GIOITHIEU
    {
        [Key]
        public int ID_GIOITHIEU { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string MOTA_VANTAT { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        public string NOIDUNG_CHITIET { get; set; }

        [Display(Name = "Trạng thái")]
        public bool TRANG_THAI { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? MODIFIED { get; set; }
    }
}
