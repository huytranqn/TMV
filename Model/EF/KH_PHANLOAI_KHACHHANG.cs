namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_PHANLOAI_KHACHHANG
    {
        [Key]
        public int ID_PHANLOAI { get; set; }

        public int? ID_LOAIKH { get; set; }

        [StringLength(50)]
        public string MA_KHACHHANG { get; set; }

        public DateTime? NGAY_PHANLOAI { get; set; }

        [StringLength(250)]
        public string GHI_CHU { get; set; }

        public virtual KH_LOAI_KHACHHANG KH_LOAI_KHACHHANG { get; set; }

        public virtual TBL_KHACHHANG TBL_KHACHHANG { get; set; }
    }
}
