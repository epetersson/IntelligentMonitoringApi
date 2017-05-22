using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.DTOs
{
    public class DailyStatisticDto
    {
        public int Id { get; set; }

        public string DeviceId { get; set; }

        public DateTime? TimeStamp { get; set; }

        public decimal Average { get; set; }

        public decimal Peak { get; set; }

        public decimal Low { get; set; }

        public long CollectiveContactLostTime { get; set; }

        public int CollectiveContactLostCount { get; set; }
    }
}