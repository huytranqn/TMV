namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TBL_TUVAN_DICHVU
    {
        [Key]
        [Display(Name = "STT")]
        public int ID_TUVAN { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã khách hàng")]
        public string MA_KHACHHANG { get; set; }

        [Display(Name = "Ngày tư vấn")]
        public DateTime? NGAY_TUVAN { get; set; }

        [StringLength(250)]
        [Display(Name = "Nhân viên tư vấn")]
        public string NHANVIEN_TUVAN { get; set; }

        [StringLength(500)]
        [Display(Name = "Nội dung tư vấn")]
        public string NOIDUNG_TUVAN { get; set; }

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string GHI_CHU { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? MODIFIED { get; set; }

        public virtual TBL_KHACHHANG TBL_KHACHHANG { get; set; }
    }
}
