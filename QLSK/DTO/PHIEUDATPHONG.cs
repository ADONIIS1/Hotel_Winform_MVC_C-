namespace QLSK.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUDATPHONG")]
    public partial class PHIEUDATPHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUDATPHONG()
        {
            CHITIETPHIEUDATPHONG = new HashSet<CHITIETPHIEUDATPHONG>();
            HOADON = new HashSet<HOADON>();
            PHIEUSDDV = new HashSet<PHIEUSDDV>();
        }

        [Key]
        public int SOPHIEUDATPHONG { get; set; }

        public DateTime NGAYDATPHONG { get; set; }

        public double TONGTIENDATPHONG { get; set; }

        [Required]
        [StringLength(20)]
        public string CMND { get; set; }

        public int MANV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUDATPHONG> CHITIETPHIEUDATPHONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADON { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUSDDV> PHIEUSDDV { get; set; }
    }
}
