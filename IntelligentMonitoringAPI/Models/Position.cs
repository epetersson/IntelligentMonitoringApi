﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace IntelligentMonitoringAPI.Models
{
    public class Position
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string DeviceNetworkId { get; set; }

        public string Name { get; set; }

        public decimal X { get; set; }

        public decimal Y { get; set; }

        public decimal Z { get; set; }

        public string EntityId { get; set; }

        public string EntityType { get; set; }

        public DateTime? UpdatedTimeStamp { get; set; }

        [StringLength(50)]
        public string LocationResourceId { get; set; }

        [StringLength(50)]
        public string ParentLocationId { get; set; }

        public string ParentLocationName { get; set; }
    }
}