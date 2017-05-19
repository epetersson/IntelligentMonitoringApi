using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using IntelligentMonitoringAPI.Models;
using IntelligentMonitoringAPI.Models.DTOs;
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
                .Select(Mapper.Map<Event, EventDto>);
            
            
            var customEventsDtos = _context.CustomEvents
                .ToList()
                .Select(Mapper.Map<CustomEvent, CustomEventDto>);

            var response = new EventsWrapper { Events = eventDtos, CustomEvents = customEventsDtos };

            return Ok(response);
        }

        [HttpGet]
        [Route("api/events/device/{deviceId}")]
        public IHttpActionResult GetEventsForDevice(string deviceId)
        {
            var deviceEventDtos =
                _context.Events.ToList()
                .Where(c => c.DeviceId == deviceId)
                .Select(Mapper.Map<Event, EventDto>);

            var customEventsDtos = _context.CustomEvents
                .ToList().Where(c => c.DeviceId == deviceId)
                .Select(Mapper.Map<CustomEvent, CustomEventDto>);

            var response = new EventsWrapper {Events = deviceEventDtos, CustomEvents = customEventsDtos};

            return Ok(response);
        }

        [HttpGet]
        public IHttpActionResult GetEventsFromDateToDate(string id, DateTime startDate, DateTime endDate)
        {
            var endingDate = endDate.AddDays(1);

            var eventDtos = _context.Events.ToList()
                .Where(c => c.DeviceId == id)
                .Where(c => c.CreatedDateTime >= startDate && c.CreatedDateTime <= endingDate)
                .Select(Mapper.Map<Event, EventDto>);

            var customEventsDtos = _context.CustomEvents.ToList()
                .Where(c => c.DeviceId == id)
                .Where(c => c.CreatedDateTime >= startDate && c.CreatedDateTime <= endingDate)
                .Select(Mapper.Map<CustomEvent, CustomEventDto>);

            var response = new EventsWrapper {Events = eventDtos, CustomEvents = customEventsDtos};

            return Ok(response);
        }
    }
}
