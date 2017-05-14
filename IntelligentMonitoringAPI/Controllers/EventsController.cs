using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using IntelligentMonitoringAPI.Models;
using IntelligentMonitoringAPI.Models.Wrappers;
using IntelligentMonitoringBackend.ModelsDTO;

namespace IntelligentMonitoringAPI.Controllers
{
    public class EventsController : ApiController
    {
        private IntelliMonDbContext _context;

        public EventsController()
        {
            _context = new IntelliMonDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetEvents()
        {
            var eventDtos = _context.Events
                .ToList()
                .Select(Mapper.Map<Event, EventDTO>);

            var response = new EventsWrapper { Events = eventDtos };

            return Ok(response);
        }

        [HttpGet]
        [Route("api/events/device/{deviceId}")]
        public IHttpActionResult GetEventsForDevice(string deviceId)
        {
            var deviceEventDtos =
                _context.Events.ToList()
                .Where(c => c.DeviceId == deviceId)
                .Select(Mapper.Map<Event, EventDTO>);

            var response = new EventsWrapper {Events = deviceEventDtos};

            return Ok(response);
        }
    }
}
