using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class DeviceHistoryDto
    {
        public int Id { get; set; }

        public string DeviceId { get; set; }

        public bool ContactLost { get; set; }

        public string ContactLostTotalTime { get; set; }

        public DateTime? CreatedTimeStamp { get; set; }

        public decimal SignalStrength { get; set; }

        public decimal BatteryLevel { get; set; }
    }
}