using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntelligentMonitoringAPI.Models;

namespace IntelligentMonitoringBackend.ModelsDTO
{
   public class EventDTO
    {
        /*
        public EventDTO(Event eventO){
            Id = eventO.Id;
            IsSensorDeleted = eventO.IsSensorDeleted.ToString();
            IsDeviceDeleted = eventO.IsSensorCollectionDeleted.ToString();
            CreatedDateTime = eventO.CreatedDateTime.ToString();
            ResetDateTime = eventO.ResetDateTime.ToString();
            Active = eventO.Active.ToString();
            switch (eventO.Status)
            {
                case EventStatus.Active:
                    Status = "Active";
                    break;
                case EventStatus.AutomaticReset:
                    Status = "AutomaticReset";
                    break;
                case EventStatus.ManualReset:
                    Status = "ManualReset";
                    break;
                case EventStatus.ManualTest:
                    Status = "ManualTest";
                    break;
            }
            Information = eventO.Information;
            EventCategoryName = eventO.EventCategoryName;
            RuleName = eventO.RuleName;
            SeverityLevel = eventO.SeverityLevel.ToString();
            RuleDescription = eventO.RuleDescription;
            TriggerName = eventO.TriggerName;
            TriggerLimit = eventO.TriggerLimit.ToString();
            switch (eventO.TriggerOperator)
            {
                case CompareOperators.Equals:
                    TriggerOperator = "Equals";
                    break;
                case CompareOperators.GreaterEqual:
                    TriggerOperator = "GreaterEqual";
                    break;
                case CompareOperators.GreaterThan:
                    TriggerOperator = "GreaterThan";
                    break;
                case CompareOperators.LowerEqual:
                    TriggerOperator = "LowerEqual";
                    break;
                case CompareOperators.LowerThan:
                    TriggerOperator = "LowerThan";
                    break;
                case CompareOperators.NotEquals:
                    TriggerOperator = "NotEquals";
                    break;
            }
            TriggerValue = eventO.TriggerValue.ToString();
            ResetValue = eventO.ResetValue.ToString();
            SensorId = eventO.SensorId;
            SensorName = eventO.SensorName;
            DeviceId = eventO.SensorCollectionId;
            DeviceName = eventO.SensorCollectionName;

        }*/

        public string Id { get; set; }
        public string IsSensorDeleted { get; set; }
        public string IsDeviceDeleted { get; set; }
        public string CreatedDateTime { get; set; }
        public string ResetDateTime { get; set; }
        public string Active { get; set; }
        public string Status { get; set; }
        public string Information { get; set; }
        public string EventCategoryName { get; set; }
        public string RuleName { get; set; }
        public string RuleDescription { get; set; }
        public string SeverityLevel { get; set; }
        public string TriggerName { get; set; }
        public string TriggerLimit { get; set; }
        public string TriggerOperator { get; set; }
        public string TriggerValue { get; set; }
        public string ResetValue { get; set; }
        public string SensorId { get; set; }
        public string SensorName { get; set; }
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
    }
}
