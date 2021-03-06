﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class DailyStatisticDto
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string DeviceId { get; set; }

        public DateTime CreatedTimeStamp { get; set; }

        public decimal AverageSignalStrength { get; set; }

        public decimal MaxSignalStrength { get; set; }

        public decimal MinSignalStrength { get; set; }

        public decimal AverageBatteryLevel { get; set; }

        public string SignalMeasurementUnit { get; set; }

        public long CollectiveContactLostTime { get; set; }

        public int CollectiveContactLostCount { get; set; }
    }
}