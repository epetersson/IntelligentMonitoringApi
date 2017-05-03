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
    [DisplayName("Devices")]
    public class DeviceDto
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