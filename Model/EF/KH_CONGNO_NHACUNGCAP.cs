namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_CONGNO_NHACUNGCAP
    {
        [Key]
        public int ID_CONGNO_NCC { get; set; }

        public int? ID_NCC { get; set; }

        public double? NO_HIENTAI { get; set; }

        public DateTime? NGAY_DIEUCHINH { get; set; }

        [StringLength(250)]
        public string MO_TA { get; set; }

        public virtual KH_NHA_CUNG_CAP KH_NHA_CUNG_CAP { get; set; }
    }
}
