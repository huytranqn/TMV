namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_CHIET_KHAU
    {
        [Key]
        public int ID_CK { get; set; }

        [StringLength(50)]
        public string TEN_CK { get; set; }

        public int? THU_TU { get; set; }
    }
}
