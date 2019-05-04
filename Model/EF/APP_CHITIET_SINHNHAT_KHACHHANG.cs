namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class APP_CHITIET_SINHNHAT_KHACHHANG
    {
        [Key]
        [Display(Name = "STT")]
        public int ID_CHITIET_SINHNHAT { get; set; }

        [Display(Name = "Mã sinh nhật")]
        public int? ID_SINHNHAT { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã khách hàng")]
        public string MA_KHACHHANG { get; set; }

        [Display(Name = "Tháng sinh nhật")]
        public int? THANG_SINHNHAT { get; set; }

        [Display(Name = "Năm sinh nhật")]
        public int? NAM_SINHNHAT { get; set; }

        [StringLength(250)]
        [Display(Name = "Ghi chú")]
        public string GHI_CHU { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? MODIFIED { get; set; }

        public virtual APP_SINHNHAT_KHACHHANG APP_SINHNHAT_KHACHHANG { get; set; }

        public virtual TBL_KHACHHANG TBL_KHACHHANG { get; set; }
    }
}
