﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models
{
    public class Location
    {
        [StringLength(50)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string ParentLocationName { get; set; }

        public string ParentLocationId { get; set; }

        public int LocationType { get; set; }

        [StringLength(50)]
        public string DeviceNetworkId { get; set; }
    }
}