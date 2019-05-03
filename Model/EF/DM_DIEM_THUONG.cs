namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DM_DIEM_THUONG
    {
        [Key]
        public int ID_GIA_TRI_DIEM { get; set; }

        public double? GIA_MIN { get; set; }

        public double? GIA_MAX { get; set; }

        public int? SO_DIEM { get; set; }

        public DateTime? MODIFIED { get; set; }
    }
}
