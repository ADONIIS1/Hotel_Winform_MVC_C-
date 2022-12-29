namespace QLSK.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETLAPDAT")]
    public partial class CHITIETLAPDAT
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SOPHIEULAPDAT { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDVATTU { get; set; }

        [StringLength(100)]
        public string TINHTRANG { get; set; }

        public virtual VATTU VATTU { get; set; }

        public virtual PHIEULAPDAT PHIEULAPDAT { get; set; }
    }
}
