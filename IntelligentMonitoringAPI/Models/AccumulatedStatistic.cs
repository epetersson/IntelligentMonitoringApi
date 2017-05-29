namespace IntelligentMonitoringAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class AccumulatedStatistic
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string DeviceId { get; set; }

        public DateTime? UpdatedTimeStamp { get; set; }

        public decimal AverageSignalStrength { get; set; }

        public decimal MaxSignalStrength { get; set; }

        public decimal MinSignalStrength { get; set; }

        public decimal AverageBatteryLevel { get; set; }
    }
}
