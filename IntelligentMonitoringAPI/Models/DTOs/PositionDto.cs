using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class PositionDto
    {
        [StringLength(50)]
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal X { get; set; }

        public decimal Y { get; set; }

        public decimal Z { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [StringLength(50)]
        public string LocationResourceId { get; set; }

        public string ParentLocationId { get; set; }

        public string ParentLocationName { get; set; }

        public string EntityId { get; set; }

        public string EntityType { get; set; }
    }
}