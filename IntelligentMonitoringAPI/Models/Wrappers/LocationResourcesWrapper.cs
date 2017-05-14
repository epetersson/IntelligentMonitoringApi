using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntelligentMonitoringAPI.Models.DTOs;

namespace IntelligentMonitoringAPI.Models.Wrappers
{
    public class LocationResourcesWrapper
    {
        public IEnumerable<LocationResourceDto> LocationResources { get; set; }
    }
}