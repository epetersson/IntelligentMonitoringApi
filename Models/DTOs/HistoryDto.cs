using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class HistoryDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string External_Id { get; set; }

        public int Device_Id { get; set; }

        public int? BatteryMeasurement { get; set; }

        public int? SignalStrength { get; set; }

        //public SimpleDeviceDto Device { get; set; }
    }
}