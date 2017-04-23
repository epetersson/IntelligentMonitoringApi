using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class SensorDto
    {
        [Required]
        [StringLength(50)]
        public string External_Id { get; set; }

        public int Device_Id { get; set; }

        public int? LatestMeasurement { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        //public Device Device { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<SensorMeasurement> SensorMeasurements { get; set; }
    }
}