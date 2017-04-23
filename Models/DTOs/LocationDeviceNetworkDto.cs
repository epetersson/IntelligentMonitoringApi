using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class LocationDeviceNetworkDto
    {
        [Required]
        [StringLength(50)]
        public string External_id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}