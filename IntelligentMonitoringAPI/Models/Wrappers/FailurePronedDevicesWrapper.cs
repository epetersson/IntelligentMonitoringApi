﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntelligentMonitoringAPI.Models.DTOs;

namespace IntelligentMonitoringAPI.Models.Wrappers
{
    public class FailurePronedDevicesWrapper
    {
        public IEnumerable<FailurePronedDeviceDto> FailurePronedDevices { get; set; }
    }
}