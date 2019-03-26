namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HT_NHANVIEN
    {
        [Key]
        [StringLength(50)]
        public string TEN_DANGNHAP { get; set; }

        [StringLength(50)]
        public string MAT_KHAU { get; set; }

        [StringLength(500)]
        public string TEN_NHANVIEN { get; set; }

        [StringLength(500)]
        public string DIA_CHI { get; set; }

        [StringLength(50)]
        public string SO_DIENTHOAI { get; set; }

        public int? MA_BOPHAN { get; set; }

        public bool? HOAT_DONG { get; set; }
    }
}
