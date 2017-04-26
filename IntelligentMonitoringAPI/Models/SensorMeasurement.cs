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
        public string SensorId { get; set; }
        public long UnixTimestamp { get; set; }
        public decimal Value { get; set; }
        
    }
}