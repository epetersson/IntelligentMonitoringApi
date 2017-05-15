using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntelligentMonitoringAPI.Models.DTOs;

namespace IntelligentMonitoringAPI.Models.Wrappers
{
    public class DeviceHistoriesWrapper
    {
        public IEnumerable<DeviceHistoryDto> DeviceHistories { get; set; }
    }
}