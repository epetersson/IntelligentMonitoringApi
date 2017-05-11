namespace IntelligentMonitoringAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class DeviceHistory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DeviceId { get; set; }

        public string ContactLostCount { get; set; }

        public string ContactLostTotalTime { get; set; }

        public string ContactLostTimeStamp { get; set; }

        public DateTime? CreatedTimeStamp { get; set; }

        public decimal SignalStrength { get; set; }

        public decimal BatteryLevel { get; set; }

        public bool LastDeviceState { get; set; }
    }
}
