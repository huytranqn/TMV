namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class APP_KHAOSAT_TRALOI
    {
        [Key]
        public int ID_TRALOI { get; set; }

        public int? ID_KHAOSAT { get; set; }

        [StringLength(50)]
        public string MA_KHACHHANG { get; set; }

        [StringLength(250)]
        public string TEN_NHANVIEN { get; set; }

        [StringLength(50)]
        public string NOIDUNG_TRALOI { get; set; }

        public DateTime? MODIFIED { get; set; }

        public DateTime? NGAY_TRALOI { get; set; }

        public virtual APP_KHAOSAT APP_KHAOSAT { get; set; }

        public virtual TBL_KHACHHANG TBL_KHACHHANG { get; set; }
    }
}
