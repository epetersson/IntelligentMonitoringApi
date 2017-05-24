using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class CustomEventDto
    {
        public int Id { get; set; }

        public DateTime? CreatedTimeStamp { get; set; }

        public bool Active { get; set; }

        public bool Seen { get; set; }

        public string Information { get; set; }

        public string EventCategoryName { get; set; }

        public string RuleName { get; set; }

        public string RuleDescription { get; set; }

        public int SeverityLevel { get; set; }

        public string TriggerName { get; set; }

        public string TriggerOperator { get; set; }

        public string DeviceId { get; set; }

        public string DeviceName { get; set; }
    }
}