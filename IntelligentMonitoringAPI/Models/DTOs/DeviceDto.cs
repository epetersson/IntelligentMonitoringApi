using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{

    public class DeviceDto
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string DataCollectorId { get; set; }

        public string DataCollectorName { get; set; }

        public bool IsRegistered { get; set; }

        public string DeviceTypeName { get; set; }

        public DateTime UpdatedTimeStamp { get; set; }

        public long LastSeen { get; set; }

        public bool ContactLost { get; set; }

        public int ContactLostCount { get; set; }

        public long ContactLostTime { get; set; }

        public long ContactLostTotalTime { get; set; }

        public decimal ContactLostThreshold { get; set; }

        public int EventCount { get; set; }

        public int SensorCount { get; set; }

        public decimal SignalStrength { get; set; }

        public string SignalMeasurementUnit { get; set; }

        public decimal BatteryLevel { get; set; }

        public bool LastDeviceState { get; set; }

        public string Name { get; set; }

        [StringLength(50)]
        public string PositionId { get; set; }

        [StringLength(50)]
        public string LocationId { get; set; }

        public string LocationName { get; set; }

        public Location Location { get; set; }

        public Position Position { get; set; }

    }
}