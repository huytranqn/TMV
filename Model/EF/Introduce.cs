namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INTRODUCE")]
    public partial class INTRODUCE
    {
        [Key]
        public int InID { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string InTitle { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string InContent { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public bool isActive { get; set; }
    }
}
