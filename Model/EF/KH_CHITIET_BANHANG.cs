namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_CHITIET_BANHANG
    {
        [Key]
        public int ID_CHITIET_BANHANG { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_XUATKHO { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_HANGHOA { get; set; }

        public int? SO_LUONG { get; set; }

        public double? GIA_BAN { get; set; }

        public double? GIA_KM { get; set; }

        public bool? CT_KM { get; set; }

        public double? THANH_TIEN { get; set; }

        public int ID_KHO { get; set; }

        public bool TRANG_THAI { get; set; }

        public int? SL_CONLAI { get; set; }

        public DateTime? MODIFIED { get; set; }

        public virtual KH_BANHANG KH_BANHANG { get; set; }

        public virtual KH_HANGHOA KH_HANGHOA { get; set; }
    }
}
