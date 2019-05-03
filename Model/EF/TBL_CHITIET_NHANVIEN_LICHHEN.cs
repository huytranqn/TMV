namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_CHITIET_NHANVIEN_LICHHEN
    {
        [Key]
        public int ID_CHITIET_NHANVIEN { get; set; }

        public int? ID_THUCHIEN { get; set; }

        [StringLength(50)]
        public string NHANVIEN_THUCHIEN { get; set; }

        public DateTime? MODIFIED { get; set; }

        public virtual HT_NHANVIEN HT_NHANVIEN { get; set; }

        public virtual TBL_NHANVIEN_LICHHEN TBL_NHANVIEN_LICHHEN { get; set; }
    }
}
