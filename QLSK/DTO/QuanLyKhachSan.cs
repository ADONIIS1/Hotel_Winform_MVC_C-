using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLSK.DTO
{
    public partial class QuanLyKhachSan : DbContext
    {
        public QuanLyKhachSan()
            : base("name=QuanLyKhachSan")
        {
        }

        public virtual DbSet<CHITIETLAPDAT> CHITIETLAPDAT { get; set; }
        public virtual DbSet<CHITIETPHIEUDATPHONG> CHITIETPHIEUDATPHONG { get; set; }
        public virtual DbSet<CHITIETSDDICHVU> CHITIETSDDICHVU { get; set; }
        public virtual DbSet<DICHVU> DICHVU { get; set; }
        public virtual DbSet<GIAPHONG> GIAPHONG { get; set; }
        public virtual DbSet<HOADON> HOADON { get; set; }
        public virtual DbSet<KIEUPHONG> KIEUPHONG { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANG { get; set; }
        public virtual DbSet<LOAIDICHVU> LOAIDICHVU { get; set; }
        public virtual DbSet<LOAIPHONG> LOAIPHONG { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIEN { get; set; }
        public virtual DbSet<PHIEUDATPHONG> PHIEUDATPHONG { get; set; }
        public virtual DbSet<PHIEULAPDAT> PHIEULAPDAT { get; set; }
        public virtual DbSet<PHIEUSDDV> PHIEUSDDV { get; set; }
        public virtual DbSet<PHONG> PHONG { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOAN { get; set; }
        public virtual DbSet<VATTU> VATTU { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DICHVU>()
                .HasMany(e => e.CHITIETSDDICHVU)
                .WithRequired(e => e.DICHVU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KIEUPHONG>()
                .HasMany(e => e.GIAPHONG)
                .WithRequired(e => e.KIEUPHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KIEUPHONG>()
                .HasMany(e => e.PHONG)
                .WithRequired(e => e.KIEUPHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.PHIEUDATPHONG)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAIPHONG>()
                .HasMany(e => e.GIAPHONG)
                .WithRequired(e => e.LOAIPHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAIPHONG>()
                .HasMany(e => e.PHONG)
                .WithRequired(e => e.LOAIPHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.PHIEUDATPHONG)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUDATPHONG>()
                .HasMany(e => e.CHITIETPHIEUDATPHONG)
                .WithRequired(e => e.PHIEUDATPHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEULAPDAT>()
                .HasMany(e => e.CHITIETLAPDAT)
                .WithRequired(e => e.PHIEULAPDAT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUSDDV>()
                .HasMany(e => e.CHITIETSDDICHVU)
                .WithRequired(e => e.PHIEUSDDV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.CHITIETPHIEUDATPHONG)
                .WithRequired(e => e.PHONG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VATTU>()
                .HasMany(e => e.CHITIETLAPDAT)
                .WithRequired(e => e.VATTU)
                .WillCascadeOnDelete(false);
        }
    }
}
