namespace QLSK.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DICHVU")]
    public partial class DICHVU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DICHVU()
        {
            CHITIETSDDICHVU = new HashSet<CHITIETSDDICHVU>();
        }

        [Key]
        public int IDDICHVU { get; set; }

        [Required]
        [StringLength(100)]
        public string TENDICHVU { get; set; }

        public double DONGIABAN { get; set; }

        [StringLength(100)]
        public string DVT { get; set; }

        public int? IDLOAIDICHVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETSDDICHVU> CHITIETSDDICHVU { get; set; }

        public virtual LOAIDICHVU LOAIDICHVU { get; set; }
    }
}
