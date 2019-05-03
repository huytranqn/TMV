namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class APP_GIOITHIEU
    {
        [Key]
        public int ID_GIOITHIEU { get; set; }

        [StringLength(500)]
        public string MOTA_VANTAT { get; set; }

        [Column(TypeName = "ntext")]
        public string NOIDUNG_CHITIET { get; set; }

        public bool TRANG_THAI { get; set; }

        public DateTime? MODIFIED { get; set; }
    }
}
