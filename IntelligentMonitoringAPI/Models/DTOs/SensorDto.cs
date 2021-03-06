﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class SensorDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string SensorTypeId { get; set; }

        public string SensorTypeName { get; set; }

        public string MeasurementUnit { get; set; }

        public string DeviceId { get; set; }

        public string DeviceName { get; set; }

        public bool IsVirtual { get; set; }

        public DateTime UpdatedTimeStamp { get; set; }
    }
}