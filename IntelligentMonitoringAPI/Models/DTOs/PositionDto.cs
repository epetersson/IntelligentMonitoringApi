﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class PositionDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal X { get; set; }

        public decimal Y { get; set; }

        public decimal Z { get; set; }

        public string LocationResourceId { get; set; }

        public string EntityId { get; set; }

        public string EntityType { get; set; }
    }
}