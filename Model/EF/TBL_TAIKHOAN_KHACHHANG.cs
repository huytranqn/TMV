namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_TAIKHOAN_KHACHHANG
    {
        [Key]
        public int ID_TAIKHOAN { get; set; }

        [Required]
        [StringLength(50)]
        public string MA_KHACHHANG { get; set; }

        public double SO_TIEN { get; set; }

        public DateTime NGAY_NOP { get; set; }

        [StringLength(500)]
        public string LY_DO { get; set; }

        public DateTime? MODIFIED { get; set; }

        public virtual TBL_KHACHHANG TBL_KHACHHANG { get; set; }
    }
}
