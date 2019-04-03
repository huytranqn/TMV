namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_GIUONG
    {
        [Key]
        public int ID_GIUONG { get; set; }

        [StringLength(250)]
        public string TEN_GIUONG { get; set; }

        public int? ID_PHONG { get; set; }

        public bool? HOAT_DONG { get; set; }

        public bool? DA_CHON { get; set; }

        public virtual TBL_PHONG TBL_PHONG { get; set; }
    }
}
