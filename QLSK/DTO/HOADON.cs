namespace QLSK.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        public int IDHOADON { get; set; }

        public DateTime? NGAYLAP { get; set; }

        public double TONGTIEN { get; set; }

        public int TINHTRANG { get; set; }

        public int? SOPHIEUDATPHONG { get; set; }

        public int? SOPHIEUSDDV { get; set; }

        public int? MANV { get; set; }

        public int? MAPHONG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual PHONG PHONG { get; set; }

        public virtual PHIEUDATPHONG PHIEUDATPHONG { get; set; }

        public virtual PHIEUSDDV PHIEUSDDV { get; set; }
    }
}
