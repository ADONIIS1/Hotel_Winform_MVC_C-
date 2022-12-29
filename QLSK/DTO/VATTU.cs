namespace QLSK.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VATTU")]
    public partial class VATTU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VATTU()
        {
            CHITIETLAPDAT = new HashSet<CHITIETLAPDAT>();
        }

        [Key]
        public int IDVATTU { get; set; }

        [Required]
        [StringLength(100)]
        public string TENVATTU { get; set; }

        [Required]
        [StringLength(100)]
        public string XUATXU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETLAPDAT> CHITIETLAPDAT { get; set; }
    }
}
