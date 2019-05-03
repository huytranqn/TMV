namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_HINH_ANH
    {
        [Key]
        public int ID_HINH { get; set; }

        [StringLength(50)]
        public string MA_KHACHHANG { get; set; }

        [StringLength(250)]
        public string TEN_HINH { get; set; }

        public DateTime? NGAY_NHAP { get; set; }

        public int? LOAI { get; set; }

        public DateTime? MODIFIED { get; set; }

        public virtual TBL_KHACHHANG TBL_KHACHHANG { get; set; }
    }
}
