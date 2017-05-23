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
    /// <summary>
    /// Class defines endpoints related to Events.
    /// </summary>
    public class EventsController : ApiController
    {
        private IntelliMonDbContext _context;

        /// <summary>
        /// Constructor initiates the database context.
        /// </summary>
        public EventsController()
        {
            _context = new IntelliMonDbContext();
        }

        /// <summary>
        /// Method defines endpoint for getting all events.
        /// </summary>
        /// <returns>One array of eventDtos and one with customEventDtos wrapped in two JSON-objects</returns>
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

        /// <summary>
        /// Method defines endpoint for getting all events for a device by deviceId.
        /// </summary>
        /// <param name="deviceId">string</param>
        /// <returns>One array of eventDtos and one with customEventDtos wrapped in two JSON-objects</returns>
        [HttpGet]
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

        /// <summary>
        /// Method defines endpoint for getting events for a device within a timespan by deviceId and timespan.
        /// </summary>
        /// <param name="deviceId">string</param>
        /// <param name="startDate">DateTime</param>
        /// <param name="endDate">DateTime</param>
        /// <returns>One array of eventDtos and one with customEventDtos wrapped in two JSON-objects</returns>
        [HttpGet]
        public IHttpActionResult GetEventsForDeviceFromDateToDate(string deviceId, DateTime startDate, DateTime endDate)
        {
            var endingDate = endDate.AddDays(1);

            var eventDtos = _context.Events.ToList()
                .Where(c => c.DeviceId == deviceId)
                .Where(c => c.CreatedDateTime >= startDate && c.CreatedDateTime <= endingDate)
                .Select(Mapper.Map<Event, EventDto>);

            var customEventsDtos = _context.CustomEvents.ToList()
                .Where(c => c.DeviceId == deviceId)
                .Where(c => c.CreatedDateTime >= startDate && c.CreatedDateTime <= endingDate)
                .Select(Mapper.Map<CustomEvent, CustomEventDto>);

            var response = new EventsWrapper {Events = eventDtos, CustomEvents = customEventsDtos};

            return Ok(response);
        }
    }
}
