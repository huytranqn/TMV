namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Introduce")]
    public partial class Introduce
    {
        [Key]
        public int InID { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Contents { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Image { get; set; }
    }
}
