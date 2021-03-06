﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class LocationDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int LocationType { get; set; }

        public int ChildLocationCount { get; set; }

        public string ParentLocationId { get; set; }

        public string ParentLocationName { get; set; }

        public DateTime UpdatedTimeStamp { get; set; }

        public string DeviceNetworkId { get; set; }
    }
}