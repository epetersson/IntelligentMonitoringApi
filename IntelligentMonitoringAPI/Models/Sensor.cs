using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public string SigmaId { get; set; }
        public string DeviceName { get; set; }
        public string SensorType { get; set; }
        public string Name { get; set; }
        public int DeviceId { get; set; }
        public string SensorTypeId { get; set; }
        public bool IsVirtual { get; set; }
    }
}