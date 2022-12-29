namespace QLSK.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUSDDV")]
    public partial class PHIEUSDDV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUSDDV()
        {
            CHITIETSDDICHVU = new HashSet<CHITIETSDDICHVU>();
            HOADON = new HashSet<HOADON>();
        }

        [Key]
        public int SOPHIEUSDDV { get; set; }

        public int? MAPHONG { get; set; }

        public DateTime? NGAYSDDV { get; set; }

        public double? TONGTIENDV { get; set; }

        public int? SOPHIEUDATPHONG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETSDDICHVU> CHITIETSDDICHVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADON { get; set; }

        public virtual PHIEUDATPHONG PHIEUDATPHONG { get; set; }

        public virtual PHONG PHONG { get; set; }
    }
}
