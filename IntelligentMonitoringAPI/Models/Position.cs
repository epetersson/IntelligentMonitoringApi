namespace IntelligentMonitoringAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Position")]
    public partial class Position
    {
        public int Id { get; set; }

        [Column("External-Id")]
        [Required]
        [StringLength(50)]
        public string External_Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }

        [StringLength(50)]
        public string EType { get; set; }

        [Column("E-Id")]
        public int? E_Id { get; set; }

        [Column("LocationResource-Id")]
        public int LocationResource_Id { get; set; }

        public virtual LocationResource LocationResource { get; set; }
    }
}
