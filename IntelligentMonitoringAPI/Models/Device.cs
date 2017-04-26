using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models
{
    public class Device
    {
        [StringLength(50)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string DeviceTypeName { get; set; }
        public long LastSeen { get; set; }
        public bool ContactLost { get; set; }
        public long ContactLostTime { get; set; }
        public bool IsRegistered { get; set; }        
        [StringLength(50)]
        public string DataCollectorId { get; set; }
        public string DataCollectorName { get; set; }
        [StringLength(50)]
        public string LocationId { get; set; }
        public string LocationName { get; set; }
    }
}