namespace IntelligentMonitoringAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SensorMeasurement")]
    public partial class SensorMeasurement
    {
        public int Id { get; set; }

        public int? Value { get; set; }

        [Column("Sensor-Id")]
        public int? Sensor_Id { get; set; }

        public virtual Sensor Sensor { get; set; }
    }
}
