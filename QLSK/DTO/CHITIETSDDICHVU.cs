namespace QLSK.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETSDDICHVU")]
    public partial class CHITIETSDDICHVU
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SOPHIEUSDDV { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDDICHVU { get; set; }

        public int SOLUONG { get; set; }

        public virtual DICHVU DICHVU { get; set; }

        public virtual PHIEUSDDV PHIEUSDDV { get; set; }
    }
}
