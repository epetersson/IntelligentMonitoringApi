using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string SigmaId { get; set; }

        public string Name { get; set; }

        public string ParentLocationName { get; set; }

        public int ParentLocationId { get; set; }

        public int LocationType { get; set; }

        public int DeviceNetworkId { get; set; }

        //public string DeviceNetworkName { get; set; }
    }
}