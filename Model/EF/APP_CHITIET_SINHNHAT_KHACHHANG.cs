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
        public int ID_CHITIET_SINHNHAT { get; set; }

        public int? ID_SINHNHAT { get; set; }

        [StringLength(50)]
        public string MA_KHACHHANG { get; set; }

        [StringLength(250)]
        public string GHI_CHU { get; set; }

        public virtual APP_SINHNHAT_KHACHHANG APP_SINHNHAT_KHACHHANG { get; set; }

        public virtual TBL_KHACHHANG TBL_KHACHHANG { get; set; }
    }
}
