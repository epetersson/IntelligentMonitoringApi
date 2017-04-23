using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class SensorMeasurementDto
    {
        public int Id { get; set; }

        public int? Value { get; set; }

        public int? Sensor_Id { get; set; }
    }
}