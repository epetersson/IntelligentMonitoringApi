namespace IntelligentMonitoringAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class FailurePronedDevice
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DeviceId { get; set; }

        [StringLength(50)]
        public string DeviceNetworkId { get; set; }

        public string DeviceName { get; set; }

        public int ContactLostCount { get; set; }

        public long ContactLostTotalTime { get; set; }

        public decimal AverageSignalStrength { get; set; }

        public decimal MaxSignalStrength { get; set; }

        public decimal MinSignalStrength { get; set; }

        public string SignalMeasurementUnit { get; set; }

        public int EventCount { get; set; }

        public string MostCommonEventName { get; set; }

        public bool Handled { get; set; }

        public DateTime? CreatedTimeStamp { get; set; }

        public DateTime? UpdatedTimeStamp { get; set; }

        [StringLength(50)]
        public string PositionId { get; set; }

        [StringLength(50)]
        public string LocationId { get; set; }

        public string LocationName { get; set; }
    }
}
