using IntelligentMonitoringBackend.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IntelligentMonitoringAPI.Models.DTOs;

namespace IntelligentMonitoringAPI.Models.Wrappers
{
    public class EventsWrapper
    {
        public IEnumerable<EventDto> Events { get; set; }
        /*
        public IEnumerable<CustomEventDto> CustomEvents { get; set; }*/
    }
}