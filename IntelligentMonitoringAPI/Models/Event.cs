using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models
{
    public class Event
    {
        public string Id { get; set; }
        //public bool IsSensorDeleted { get; set; }
        //public bool IsDeviceDeleted { get; set; }
        //public bool IsEventCategoryDeleted { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ResetDateTime { get; set; }
        public bool Active { get; set; }
        //public EventStatus Status { get; set; }
        public string Information { get; set; }
        public string EventCategoryId { get; set; }
        public string EventCategoryName { get; set; }
        public int EventCategoryTypeId { get; set; }
        public string RuleId { get; set; }
        public string RuleName { get; set; }
        public int SeverityLevel { get; set; }
        public string RuleDescription { get; set; }
        public string TriggerId { get; set; }
        public string TriggerName { get; set; }
        public decimal TriggerLimit { get; set; }
        //public CompareOperators TriggerOperator { get; set; }
        public decimal TriggerValue { get; set; }
        public decimal ResetValue { get; set; }
        public int SensorId { get; set; }
        public string SensorName { get; set; }
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
    }
}