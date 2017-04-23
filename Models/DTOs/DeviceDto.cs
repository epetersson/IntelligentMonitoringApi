using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class DeviceDto
    {
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

        //public Location Location { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public ICollection<History> Histories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<SensorDto> Sensors { get; set; }
    }
}