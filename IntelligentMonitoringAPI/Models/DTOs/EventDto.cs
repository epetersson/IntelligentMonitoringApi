﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntelligentMonitoringAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace IntelligentMonitoringBackend.ModelsDTO
{
   public class EventDto
    {
        public string Id { get; set; }

        public bool IsSensorDeleted { get; set; }

        public bool IsDeviceDeleted { get; set; }

        public DateTime? CreatedTimeStamp { get; set; }

        public DateTime? ResetTimeStamp { get; set; }

        public bool Active { get; set; }

        public bool Seen { get; set; }

        public string Status { get; set; }

        public string Information { get; set; }

        public string EventCategoryName { get; set; }

        public string RuleName { get; set; }

        public string RuleDescription { get; set; }

        public int SeverityLevel { get; set; }

        public string TriggerName { get; set; }

        public decimal TriggerLimit { get; set; }

        public string TriggerOperator { get; set; }

        public decimal TriggerValue { get; set; }

        public decimal ResetValue { get; set; }

        public string SensorId { get; set; }

        public string SensorName { get; set; }

        public string DeviceId { get; set; }

        public string DeviceName { get; set; }
    }
}
