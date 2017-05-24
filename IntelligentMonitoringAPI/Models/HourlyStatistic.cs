using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace IntelligentMonitoringAPI.Models
{
    public class HourlyStatistic
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DeviceId { get; set; }

        public bool ContactLost { get; set; }

        public long ContactLostTotalTime { get; set; }

        public DateTime? CreatedTimeStamp { get; set; }

        public decimal SignalStrength { get; set; }

        public string SignalMeasurementUnit { get; set; }

        public decimal BatteryLevel { get; set; }
    }
}
