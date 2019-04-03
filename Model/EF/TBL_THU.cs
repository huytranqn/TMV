namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_THU
    {
        public int ID { get; set; }

        public DateTime? NGAY { get; set; }

        [StringLength(250)]
        public string NHAN_VIEN { get; set; }

        [StringLength(50)]
        public string ID_DANGKY { get; set; }

        [Column(TypeName = "ntext")]
        public string LY_DO { get; set; }

        public double? SO_TIEN { get; set; }

        public bool? TRANG_THAI { get; set; }

        public double? SO_TIEN_THU { get; set; }

        public double? CON_NO { get; set; }

        [StringLength(50)]
        public string M_KH { get; set; }

        public bool? LOAI { get; set; }
    }
}
