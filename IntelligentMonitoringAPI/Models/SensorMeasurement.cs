using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models
{
    public class SensorMeasurement
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string DeviceNetworkId { get; set; }

        [StringLength(50)]
        public string SensorId { get; set; }

        public DateTime? CreatedTimeStamp { get; set; }

        public decimal Value { get; set; }

        [StringLength(200)]
        public string MeasurementUnit { get; set; }
    }
}