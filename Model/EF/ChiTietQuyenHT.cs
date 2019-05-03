namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietQuyenHT")]
    public partial class ChiTietQuyenHT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(500)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdQuyenHeThong { get; set; }

        public DateTime? MODIFIED { get; set; }
    }
}
