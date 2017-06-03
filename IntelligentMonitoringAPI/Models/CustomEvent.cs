namespace IntelligentMonitoringAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class CustomEvent
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string DeviceNetworkId { get; set; }

        public DateTime? CreatedTimeStamp { get; set; }

        public bool Active { get; set; }

        public bool Seen { get; set; }

        public string Information { get; set; }

        public string EventCategoryName { get; set; }

        public string RuleName { get; set; }

        public string RuleDescription { get; set; }

        public int SeverityLevel { get; set; }

        public string TriggerName { get; set; }

        [StringLength(50)]
        public string TriggerOperator { get; set; }

        [StringLength(50)]
        public string DeviceId { get; set; }

        public string DeviceName { get; set; }
    }
}
