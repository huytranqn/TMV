namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_CONGNO_KHACHHANG
    {
        [Key]
        public int ID_CONGNO_KH { get; set; }

        [StringLength(50)]
        public string MA_KHACHHANG { get; set; }

        public double? NO_HIENTAI { get; set; }

        public DateTime? NGAY_DIEUCHINH { get; set; }

        [StringLength(250)]
        public string MO_TA { get; set; }

        public virtual TBL_KHACHHANG TBL_KHACHHANG { get; set; }
    }
}
