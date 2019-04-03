namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OnlineTMV : DbContext
    {
        public OnlineTMV()
            : base("name=OnlineTMV4")
        {
        }

        public virtual DbSet<APP_CHITIET_SINHNHAT_KHACHHANG> APP_CHITIET_SINHNHAT_KHACHHANG { get; set; }
        public virtual DbSet<APP_GIOITHIEU> APP_GIOITHIEU { get; set; }
        public virtual DbSet<APP_KHUYENMAI> APP_KHUYENMAI { get; set; }
        public virtual DbSet<APP_NOIBAT> APP_NOIBAT { get; set; }
        public virtual DbSet<APP_SINHNHAT_KHACHHANG> APP_SINHNHAT_KHACHHANG { get; set; }
        public virtual DbSet<ChiTietQuyenHT> ChiTietQuyenHTs { get; set; }
        public virtual DbSet<DM_DICHVU> DM_DICHVU { get; set; }
        public virtual DbSet<DM_DIEM_THUONG> DM_DIEM_THUONG { get; set; }
        public virtual DbSet<DM_LOAIDV> DM_LOAIDV { get; set; }
        public virtual DbSet<DM_NHOMDV> DM_NHOMDV { get; set; }
        public virtual DbSet<HT_BOPHAN> HT_BOPHAN { get; set; }
        public virtual DbSet<HT_NHANVIEN> HT_NHANVIEN { get; set; }
        public virtual DbSet<KH_BANHANG> KH_BANHANG { get; set; }
        public virtual DbSet<KH_CHIET_KHAU> KH_CHIET_KHAU { get; set; }
        public virtual DbSet<KH_CHITIET_BANHANG> KH_CHITIET_BANHANG { get; set; }
        public virtual DbSet<KH_CHITIET_NHAPKHO> KH_CHITIET_NHAPKHO { get; set; }
        public virtual DbSet<KH_CHITIET_TRAHANG> KH_CHITIET_TRAHANG { get; set; }
        public virtual DbSet<KH_CONGNO_NHACUNGCAP> KH_CONGNO_NHACUNGCAP { get; set; }
        public virtual DbSet<KH_DONVITINH> KH_DONVITINH { get; set; }
        public virtual DbSet<KH_HANGHOA> KH_HANGHOA { get; set; }
        public virtual DbSet<KH_HINH_ANH> KH_HINH_ANH { get; set; }
        public virtual DbSet<KH_KHO> KH_KHO { get; set; }
        public virtual DbSet<KH_LOAI_KHACHHANG> KH_LOAI_KHACHHANG { get; set; }
        public virtual DbSet<KH_NHA_CUNG_CAP> KH_NHA_CUNG_CAP { get; set; }
        public virtual DbSet<KH_NHAP_KHO> KH_NHAP_KHO { get; set; }
        public virtual DbSet<KH_NHOMHANGHOA> KH_NHOMHANGHOA { get; set; }
        public virtual DbSet<KH_PHANLOAI_KHACHHANG> KH_PHANLOAI_KHACHHANG { get; set; }
        public virtual DbSet<KH_TONKHO> KH_TONKHO { get; set; }
        public virtual DbSet<KH_TRAHANG> KH_TRAHANG { get; set; }
        public virtual DbSet<QuyenHeThong> QuyenHeThongs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TBL_CHI> TBL_CHI { get; set; }
        public virtual DbSet<TBL_CHITIET_DANGKY_DICHVU> TBL_CHITIET_DANGKY_DICHVU { get; set; }
        public virtual DbSet<TBL_CHITIET_LICHHEN> TBL_CHITIET_LICHHEN { get; set; }
        public virtual DbSet<TBL_CHITIET_NHANVIEN_LICHHEN> TBL_CHITIET_NHANVIEN_LICHHEN { get; set; }
        public virtual DbSet<TBL_CONGNO_KHACHHANG> TBL_CONGNO_KHACHHANG { get; set; }
        public virtual DbSet<TBL_DANGKY_DICHVU> TBL_DANGKY_DICHVU { get; set; }
        public virtual DbSet<TBL_GIUONG> TBL_GIUONG { get; set; }
        public virtual DbSet<TBL_KHACHHANG> TBL_KHACHHANG { get; set; }
        public virtual DbSet<TBL_LICHHEN> TBL_LICHHEN { get; set; }
        public virtual DbSet<TBL_NHANVIEN_LICHHEN> TBL_NHANVIEN_LICHHEN { get; set; }
        public virtual DbSet<TBL_PHONG> TBL_PHONG { get; set; }
        public virtual DbSet<TBL_TAIKHOAN_KHACHHANG> TBL_TAIKHOAN_KHACHHANG { get; set; }
        public virtual DbSet<TBL_TANG> TBL_TANG { get; set; }
        public virtual DbSet<TBL_THE_HDBANK> TBL_THE_HDBANK { get; set; }
        public virtual DbSet<TBL_THU> TBL_THU { get; set; }
        public virtual DbSet<TBL_TRANGTHAI_LICHHEN> TBL_TRANGTHAI_LICHHEN { get; set; }
        public virtual DbSet<TBL_TUVAN_DICHVU> TBL_TUVAN_DICHVU { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<APP_SINHNHAT_KHACHHANG>()
                .HasMany(e => e.APP_CHITIET_SINHNHAT_KHACHHANG)
                .WithOptional(e => e.APP_SINHNHAT_KHACHHANG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ChiTietQuyenHT>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<HT_BOPHAN>()
                .HasMany(e => e.HT_NHANVIEN)
                .WithOptional(e => e.HT_BOPHAN)
                .WillCascadeOnDelete();

            modelBuilder.Entity<HT_NHANVIEN>()
                .HasMany(e => e.KH_BANHANG)
                .WithRequired(e => e.HT_NHANVIEN)
                .HasForeignKey(e => e.NV_XUAT);

            modelBuilder.Entity<HT_NHANVIEN>()
                .HasMany(e => e.KH_TRAHANG)
                .WithRequired(e => e.HT_NHANVIEN)
                .HasForeignKey(e => e.NHANVIEN_TRA);

            modelBuilder.Entity<KH_HANGHOA>()
                .HasMany(e => e.KH_CHITIET_TRAHANG)
                .WithOptional(e => e.KH_HANGHOA)
                .WillCascadeOnDelete();

            modelBuilder.Entity<KH_KHO>()
                .HasMany(e => e.KH_CHITIET_TRAHANG)
                .WithOptional(e => e.KH_KHO)
                .HasForeignKey(e => e.KHO_NHAN)
                .WillCascadeOnDelete();

            modelBuilder.Entity<KH_KHO>()
                .HasMany(e => e.KH_NHAP_KHO)
                .WithOptional(e => e.KH_KHO)
                .WillCascadeOnDelete();

            modelBuilder.Entity<KH_LOAI_KHACHHANG>()
                .HasMany(e => e.KH_PHANLOAI_KHACHHANG)
                .WithOptional(e => e.KH_LOAI_KHACHHANG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<KH_NHA_CUNG_CAP>()
                .HasMany(e => e.KH_CONGNO_NHACUNGCAP)
                .WithOptional(e => e.KH_NHA_CUNG_CAP)
                .WillCascadeOnDelete();

            modelBuilder.Entity<KH_NHA_CUNG_CAP>()
                .HasMany(e => e.KH_HANGHOA)
                .WithOptional(e => e.KH_NHA_CUNG_CAP)
                .WillCascadeOnDelete();

            modelBuilder.Entity<KH_NHA_CUNG_CAP>()
                .HasMany(e => e.KH_NHAP_KHO)
                .WithOptional(e => e.KH_NHA_CUNG_CAP)
                .HasForeignKey(e => e.NHA_CUNG_CAP)
                .WillCascadeOnDelete();

            modelBuilder.Entity<KH_NHAP_KHO>()
                .HasMany(e => e.KH_CHITIET_NHAPKHO)
                .WithOptional(e => e.KH_NHAP_KHO)
                .WillCascadeOnDelete();

            modelBuilder.Entity<KH_TRAHANG>()
                .HasMany(e => e.KH_CHITIET_TRAHANG)
                .WithOptional(e => e.KH_TRAHANG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TBL_CHITIET_DANGKY_DICHVU>()
                .HasMany(e => e.TBL_CHITIET_LICHHEN)
                .WithOptional(e => e.TBL_CHITIET_DANGKY_DICHVU)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TBL_KHACHHANG>()
                .HasMany(e => e.APP_CHITIET_SINHNHAT_KHACHHANG)
                .WithOptional(e => e.TBL_KHACHHANG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TBL_KHACHHANG>()
                .HasMany(e => e.KH_BANHANG)
                .WithOptional(e => e.TBL_KHACHHANG)
                .HasForeignKey(e => e.KHACHHANG_MUA)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TBL_KHACHHANG>()
                .HasMany(e => e.KH_HINH_ANH)
                .WithOptional(e => e.TBL_KHACHHANG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TBL_KHACHHANG>()
                .HasMany(e => e.KH_PHANLOAI_KHACHHANG)
                .WithOptional(e => e.TBL_KHACHHANG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TBL_KHACHHANG>()
                .HasMany(e => e.KH_TRAHANG)
                .WithRequired(e => e.TBL_KHACHHANG)
                .HasForeignKey(e => e.KHACHHANG_TRA);

            modelBuilder.Entity<TBL_KHACHHANG>()
                .HasMany(e => e.TBL_CONGNO_KHACHHANG)
                .WithOptional(e => e.TBL_KHACHHANG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TBL_KHACHHANG>()
                .HasMany(e => e.TBL_DANGKY_DICHVU)
                .WithOptional(e => e.TBL_KHACHHANG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TBL_KHACHHANG>()
                .HasMany(e => e.TBL_TUVAN_DICHVU)
                .WithOptional(e => e.TBL_KHACHHANG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TBL_LICHHEN>()
                .HasMany(e => e.TBL_CHITIET_LICHHEN)
                .WithOptional(e => e.TBL_LICHHEN)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TBL_NHANVIEN_LICHHEN>()
                .HasMany(e => e.TBL_CHITIET_NHANVIEN_LICHHEN)
                .WithOptional(e => e.TBL_NHANVIEN_LICHHEN)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TBL_PHONG>()
                .HasMany(e => e.TBL_GIUONG)
                .WithOptional(e => e.TBL_PHONG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TBL_PHONG>()
                .HasMany(e => e.TBL_LICHHEN)
                .WithOptional(e => e.TBL_PHONG)
                .HasForeignKey(e => e.PHONG_THUCHIEN)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TBL_TANG>()
                .HasMany(e => e.TBL_PHONG)
                .WithOptional(e => e.TBL_TANG)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TBL_TRANGTHAI_LICHHEN>()
                .HasMany(e => e.TBL_LICHHEN)
                .WithOptional(e => e.TBL_TRANGTHAI_LICHHEN)
                .HasForeignKey(e => e.TRANGTHAI_HEN)
                .WillCascadeOnDelete();
        }
    }
}
