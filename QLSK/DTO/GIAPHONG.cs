namespace QLSK.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIAPHONG")]
    public partial class GIAPHONG
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKIEUPHONG { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDLOAIPHONG { get; set; }

        public double? GIANGAY { get; set; }

        public double? GIAGIO { get; set; }

        public virtual KIEUPHONG KIEUPHONG { get; set; }

        public virtual LOAIPHONG LOAIPHONG { get; set; }
    }
}
