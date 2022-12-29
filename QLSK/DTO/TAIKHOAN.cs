namespace QLSK.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [Key]
        [StringLength(50)]
        public string TENTAIKHOAN { get; set; }

        [Required]
        [StringLength(1000)]
        public string MATKHAU { get; set; }

        public int? MANV { get; set; }

        public int QUYEN { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
