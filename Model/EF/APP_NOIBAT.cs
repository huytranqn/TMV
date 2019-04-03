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

        [StringLength(250)]
        public string HINHANH_VIDEO { get; set; }

        public int? LOAI { get; set; }

        public bool? TRANG_THAI { get; set; }
    }
}
