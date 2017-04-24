using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string SigmaId { get; set; }

        public string Name { get; set; }

        public decimal X { get; set; }

        public decimal Y { get; set; }

        public decimal Z { get; set; }

        public int LocationResourceId { get; set; }

        public string EntityId { get; set; }

        //public PositionEntityType EntityType { get; set; }
    }
}