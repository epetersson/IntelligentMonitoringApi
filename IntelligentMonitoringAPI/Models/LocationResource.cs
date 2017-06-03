using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models
{
    public class LocationResource
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string DeviceNetworkId { get; set; }

        public string Name { get; set; }

        public string Label { get; set; }

        public string ResourceType { get; set; }

        public string Uri { get; set; }

        public decimal StartPositionX { get; set; }

        public decimal StartPositionY { get; set; }

        public decimal StartPositionZ { get; set; }

        public decimal StartZoomLevel { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string MimeType { get; set; }

        public string FileExtension { get; set; }

        public DateTime? UpdatedTimeStamp { get; set; }

        [StringLength(50)]
        public string ParentLocationId { get; set; }

        public int ChildPositionCount { get; set; }
    }
}