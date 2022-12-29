namespace QLSK.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            PHIEUDATPHONG = new HashSet<PHIEUDATPHONG>();
        }

        [Key]
        [StringLength(20)]
        public string CMND { get; set; }

        [Required]
        [StringLength(100)]
        public string TENKHACHHANG { get; set; }

        [Required]
        [StringLength(15)]
        public string SDT { get; set; }

        [Required]
        [StringLength(100)]
        public string DIACHI { get; set; }

        public bool GIOITINH { get; set; }

        [Required]
        [StringLength(50)]
        public string QUOCTICH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDATPHONG> PHIEUDATPHONG { get; set; }
    }
}
