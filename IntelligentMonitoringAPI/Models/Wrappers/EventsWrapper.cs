using IntelligentMonitoringBackend.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models.Wrappers
{
    public class EventsWrapper
    {
        public IEnumerable<EventDTO> Events { get; set; }
    }
}