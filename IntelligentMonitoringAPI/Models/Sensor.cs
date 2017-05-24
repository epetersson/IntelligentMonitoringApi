using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace IntelligentMonitoringAPI.Models
{
    public class Sensor
    {
        [StringLength(50)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string SensorTypeId { get; set; }

        public string SensorTypeName { get; set; }

        public string MeasurementUnit { get; set; }

        [StringLength(50)]
        public string DeviceId { get; set; }

        public string DeviceName { get; set; }

        public bool IsVirtual { get; set; }

        public DateTime? UpdatedTimeStamp { get; set; }
    }
}