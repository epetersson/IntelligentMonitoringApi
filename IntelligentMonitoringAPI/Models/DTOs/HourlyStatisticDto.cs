using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class HourlyStatisticDto
    {
        public int Id { get; set; }

        public string DeviceId { get; set; }

        public bool ContactLost { get; set; }

        public long ContactLostTotalTime { get; set; }

        public DateTime? CreatedTimeStamp { get; set; }

        public decimal SignalStrength { get; set; }

        public string SignalMeasurementUnit { get; set; }

        public decimal BatteryLevel { get; set; }
    }
}