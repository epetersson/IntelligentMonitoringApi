namespace IntelligentMonitoringAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("History")]
    public partial class History
    {
        public int Id { get; set; }

        [Column("External-Id")]
        [Required]
        [StringLength(50)]
        public string External_Id { get; set; }

        [Column("Device-Id")]
        public int Device_Id { get; set; }

        public int? BatteryMeasurement { get; set; }

        public int? SignalStrength { get; set; }

        public virtual Device Device { get; set; }
    }
}
