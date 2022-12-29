namespace QLSK.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEULAPDAT")]
    public partial class PHIEULAPDAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEULAPDAT()
        {
            CHITIETLAPDAT = new HashSet<CHITIETLAPDAT>();
        }

        [Key]
        public int SOPHIEULAPDAT { get; set; }

        public DateTime? NGAYLAPDAT { get; set; }

        public int? MANV { get; set; }

        public int? MAPHONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETLAPDAT> CHITIETLAPDAT { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
