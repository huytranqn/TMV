namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_TUVAN_DICHVU
    {
        [Key]
        public int ID_TUVAN { get; set; }

        [StringLength(50)]
        public string MA_KHACHHANG { get; set; }

        public DateTime? NGAY_TUVAN { get; set; }

        [StringLength(250)]
        public string NHANVIEN_TUVAN { get; set; }

        [StringLength(500)]
        public string NOIDUNG_TUVAN { get; set; }

        [StringLength(500)]
        public string GHI_CHU { get; set; }

        public virtual TBL_KHACHHANG TBL_KHACHHANG { get; set; }
    }
}
