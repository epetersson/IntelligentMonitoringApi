using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class LocationDeviceDto
    {
        [Required]
        [StringLength(50)]
        public string ExternalId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}