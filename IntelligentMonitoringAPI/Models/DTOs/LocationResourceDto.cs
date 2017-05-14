﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class LocationResourceDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Label { get; set; }

        public string ResourceType { get; set; }

        public string ParentLocationId { get; set; }

        public string Uri { get; set; }

        public decimal StartPositionX { get; set; }

        public decimal StartPositionY { get; set; }

        public decimal StartPositionZ { get; set; }

        public decimal StartZoomLevel { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string MimeType { get; set; }

        public string FileExtension { get; set; }
    }
}