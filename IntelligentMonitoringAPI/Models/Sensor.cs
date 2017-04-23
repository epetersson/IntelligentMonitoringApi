namespace IntelligentMonitoringAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sensor")]
    public partial class Sensor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sensor()
        {
            SensorMeasurements = new HashSet<SensorMeasurement>();
        }

        public int Id { get; set; }

        [Column("External-Id")]
        [Required]
        [StringLength(50)]
        public string External_Id { get; set; }

        [Column("Device-Id")]
        public int Device_Id { get; set; }

        public int? LatestMeasurement { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual Device Device { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SensorMeasurement> SensorMeasurements { get; set; }
    }
}
