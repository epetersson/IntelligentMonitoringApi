using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models
{
    public class RealTimeToken
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string DeviceNetworkId { get; set; }

        public string Token { get; set; }

        public DateTime? CreatedTimeStamp { get; set; }

        public DateTime? ExpiresTimeStamp { get; set; }
    }
}