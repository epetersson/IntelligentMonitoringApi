using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace IntelligentMonitoringAPI.Models
{
    public class Device
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string DeviceNetworkId { get; set; }

        public string Name { get; set; }

        public string DeviceTypeName { get; set; }

        public DateTime? UpdatedTimeStamp { get; set; }

        public bool IsRegistered { get; set; }

        public long LastSeen { get; set; }

        public bool ContactLost { get; set; }

        public int ContactLostCount { get; set; }

        public DateTime? ContactLostTimeStamp { get; set; }

        public long ContactLostTotalTime { get; set; }

        public decimal ContactLostThreshold { get; set; }

        public decimal SignalStrength { get; set; }

        public string SignalMeasurementUnit { get; set; }

        public decimal BatteryLevel { get; set; }

        public bool LastDeviceState { get; set; }

        public int EventCount { get; set; }

        public int SensorCount { get; set; }

        [StringLength(50)]
        public string DataCollectorId { get; set; }

        public string DataCollectorName { get; set; }

        [StringLength(50)]
        public string PositionId { get; set; }

        [StringLength(50)]
        public string LocationId { get; set; }

        public string LocationName { get; set; }
    }
}