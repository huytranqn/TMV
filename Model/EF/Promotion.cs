namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Promotion")]
    public partial class Promotion
    {
        [Key]
        public int PromID { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string PromotionContent { get; set; }

        public DateTime? Time { get; set; }

        public bool isActive { get; set; }
    }
}
