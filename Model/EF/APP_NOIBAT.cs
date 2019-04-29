namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class APP_NOIBAT
    {
        [Key]
        public int ID_NOIBAT { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Tên")]
        public string TENHINH_VIDEO { get; set; }

        [Display(Name = "Hình Ảnh/Video")]
        [StringLength(250)]
        public string HINHANH_VIDEO { get; set; }

        [Display(Name = "Loại")]
        public int? LOAI { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool TRANG_THAI { get; set; }
    }
}
