using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models
{
    public class SensorMeasurement
    {
        public int Id { get; set; }

        public int? Value { get; set; }

        public int? SensorId { get; set; }
    }
}