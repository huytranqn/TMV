namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_CHITIET_TRAHANG
    {
        [Key]
        public int ID_CHITIET_TRAHANG { get; set; }

        [StringLength(50)]
        public string MA_HANGHOA { get; set; }

        [StringLength(50)]
        public string MA_TRAHANG { get; set; }

        public int? SO_LUONG { get; set; }

        public double? GIA_BAN { get; set; }

        public double? GIA_KM { get; set; }

        public bool? CT_KM { get; set; }

        public double? THANH_TIEN { get; set; }

        public int? KHO_NHAN { get; set; }

        [StringLength(250)]
        public string GHI_CHU { get; set; }

        public DateTime? MODIFIED { get; set; }

        public virtual KH_HANGHOA KH_HANGHOA { get; set; }

        public virtual KH_KHO KH_KHO { get; set; }

        public virtual KH_TRAHANG KH_TRAHANG { get; set; }
    }
}
