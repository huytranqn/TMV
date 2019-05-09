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
        [Display(Name = "STT")]
        public int ID_NOIBAT { get; set; }

        [StringLength(250)]
        [Display(Name = "Hình ảnh/ Video")]
        public string HINHANH_VIDEO { get; set; }

        [Display(Name = "Loại")]
        public int? LOAI { get; set; }

        [Display(Name = "Trạng thái")]
        public bool TRANG_THAI { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? MODIFIED { get; set; }
    }
}
