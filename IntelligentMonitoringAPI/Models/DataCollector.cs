namespace IntelligentMonitoringAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class DataCollector
    {
        [StringLength(50)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string DataCollectorTypeName { get; set; }

        public long LastSeen { get; set; }

        public bool ContactLost { get; set; }

        public DateTime? ContactLostTimeStamp { get; set; }

        public string DataCollectorTemplateName { get; set; }

        public DateTime? UpdatedTimeStamp { get; set; }

        [StringLength(50)]
        public string PositionId { get; set; }

        [StringLength(50)]
        public string LocationId { get; set; }

        public string LocationName { get; set; }

        [StringLength(50)]
        public string InternalDeviceId { get; set; }

        public long LastConnectionTimeStamp { get; set; }

        public int LastUpdateStatusCode { get; set; }

        public int RegisteredDeviceCount { get; set; }

        public string Note { get; set; }
    }
}
