namespace IntelligentMonitoringAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Device")]
    public partial class Device
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Device()
        {
            Histories = new HashSet<History>();
            Sensors = new HashSet<Sensor>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ExternalId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string LocationName { get; set; }

        [Column("Location-Id")]
        public int Location_Id { get; set; }

        [Column("Position-Id")]
        public int? Position_Id { get; set; }

        public int SignalStrength { get; set; }

        public int LatestBatteryMeasurement { get; set; }

        public DateTime? LastSeen { get; set; }

        [MaxLength(1)]
        public byte[] ContactLost { get; set; }

        public virtual Location Location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<History> Histories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sensor> Sensors { get; set; }
    }
}
