using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models
{
    public class LocationResource
    {
        public int Id { get; set; }
        public string SigmaId { get; set; } 
        public string Name { get; set; }

        public string Label { get; set; }

        //public LocationResourceType ResourceType { get; set; }

        public Uri Path { get; set; }

        public decimal StartPositionX { get; set; }

        public decimal StartPositionY { get; set; }

        public decimal StartPositionZ { get; set; }

        public decimal StartZoomLevel { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}