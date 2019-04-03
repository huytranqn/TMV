namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_CHITIET_NHAPKHO
    {
        [Key]
        public int ID_CHITIET_NHAPKHO { get; set; }

        [StringLength(50)]
        public string MA_HANGHOA { get; set; }

        [StringLength(50)]
        public string MA_NHAPKHO { get; set; }

        public double? SL_NHAP { get; set; }

        public double? DG_NHAP { get; set; }

        public double? CHIET_KHAU { get; set; }

        public double? TT_NHAP { get; set; }

        public virtual KH_NHAP_KHO KH_NHAP_KHO { get; set; }
    }
}
