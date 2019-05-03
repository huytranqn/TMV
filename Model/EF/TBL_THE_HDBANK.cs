namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_THE_HDBANK
    {
        [Key]
        [StringLength(50)]
        public string SO_THE { get; set; }

        [StringLength(50)]
        public string LOAI_THE { get; set; }

        [StringLength(50)]
        public string NGAY_PHATHANH { get; set; }

        public DateTime? MODIFIED { get; set; }
    }
}
