namespace IntelligentMonitoringAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class WeeklyStatistic
    {
        public int Id { get; set; }

        public DateTime? TimeStamp { get; set; }

        public decimal Average { get; set; }

        public decimal Peak { get; set; }

        public decimal Low { get; set; }

        public long CollectiveContactLostTime { get; set; }

        public int CollectiveContactLostCount { get; set; }

        [StringLength(50)]
        public string FailureProneDeviceId { get; set; }
    }
}
