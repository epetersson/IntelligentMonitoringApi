using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class DeviceNetworkDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string TenantName { get; set; }

        public string AuthToken { get; set; }

        public DateTime? UpdatedTimeStamp { get; set; }
    }
}