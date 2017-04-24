using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public string SigmaId { get; set; }
        //public string DataCollectorName { get; set; }
        //public string LocationName { get; set; }
        public bool IsRegistered { get; set; }
        //public string SensorCollectionTypeName { get; set; }
        public long LastSeen { get; set; }
        public bool ContactLost { get; set; }
        public long ContactLostTime { get; set; }
        public string Name { get; set; }
        //public string DataCollectorId { get; set; }
        //public int LocationId { get; set; }
    }
}