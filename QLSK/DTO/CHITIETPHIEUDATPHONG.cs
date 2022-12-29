namespace QLSK.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETPHIEUDATPHONG")]
    public partial class CHITIETPHIEUDATPHONG
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SOPHIEUDATPHONG { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAPHONG { get; set; }

        public DateTime GIOVAO { get; set; }

        public DateTime GIORA { get; set; }

        public int SONGUOI { get; set; }

        [Required]
        [StringLength(50)]
        public string TINHTRANGPHONG { get; set; }

        public virtual PHONG PHONG { get; set; }

        public virtual PHIEUDATPHONG PHIEUDATPHONG { get; set; }
    }
}
