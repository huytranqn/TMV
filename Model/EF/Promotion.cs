namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROMOTION")]
    public partial class Promotion
    {
        [Key]
        public int ProID { get; set; }

        [Display(Name = "Tiêu đề khuyến mãi")]
        [Column(TypeName = "ntext")]
        [Required]
        public string ProTitle { get; set; }

        [Display(Name = "Nội dung khuyến mãi")]
        [Column(TypeName = "ntext")]
        [Required]
        public string ProContent { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? CreateAt { get; set; }

        [Display(Name = "ngày cập nhật")]
        public DateTime? UpdateAt { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool isActive { get; set; }

    }
}
