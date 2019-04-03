namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KH_TONKHO
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_KHO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MA_HANGHOA { get; set; }

        public double SL_TON { get; set; }

        public DateTime? NGAY_KTTON { get; set; }

        public virtual KH_HANGHOA KH_HANGHOA { get; set; }

        public virtual KH_KHO KH_KHO { get; set; }
    }
}
