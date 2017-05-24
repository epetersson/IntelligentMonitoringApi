using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class SensorMeasurementDto
    {
        public int Id { get; set; }

        public string SensorId { get; set; }

        public DateTime? CreatedTimeStamp { get; set; }

        public decimal Value { get; set; }

        public string MeasurementUnit { get; set; }
    }
}