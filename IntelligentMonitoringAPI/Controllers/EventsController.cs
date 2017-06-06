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
using WebGrease.Css.Ast.Selectors;

namespace IntelligentMonitoringAPI.Controllers
{
    /// <summary>
    /// Class defines endpoints related to Events.
    /// </summary>
    public class EventsController : ApiController
    {
        private IntelliMonDbContext _context;
        private DeviceNetwork deviceNetwork;

        /// <summary>
        /// Constructor initiates the database context.
        /// </summary>
        public EventsController()
        {
            _context = new IntelliMonDbContext();

            var authorization = _context.AuthorizationTokens.FirstOrDefault();

            if (authorization != null)
            {
                if (!String.IsNullOrEmpty(authorization.Token))
                {
                    deviceNetwork = _context.DeviceNetworks.Where(obj => String.Compare(obj.AuthToken, authorization.Token) == 0).FirstOrDefault();
                }
                else
                {
                    deviceNetwork = _context.DeviceNetworks.OrderByDescending(d => d.UpdatedTimeStamp).FirstOrDefault();
                }
            }
            else
            {
                deviceNetwork = _context.DeviceNetworks.OrderByDescending(d => d.UpdatedTimeStamp).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get all events.
        /// </summary>
        /// <returns>Two JSON-wrapped arrays of Events and CustomEvents</returns>
        [HttpGet]
        public IHttpActionResult GetEvents()
        {
            var eventDtos = _context.Events
                .Where(obj => String.Compare(obj.DeviceNetworkId, deviceNetwork.Id) == 0)
                .ToList()
                .Select(Mapper.Map<Event, EventDto>);
            
            
            var customEventsDtos = _context.CustomEvents
                .Where(obj => String.Compare(obj.DeviceNetworkId, deviceNetwork.Id) == 0)
                .ToList()
                .Select(Mapper.Map<CustomEvent, CustomEventDto>);

            var response = new EventsWrapper { Events = eventDtos, CustomEvents = customEventsDtos };

            return Ok(response);
        }

        /// <summary>
        /// Get events for a device by Id or Start Date, End Date or within a timespan.
        /// </summary>
        /// <param name="deviceId">string</param>
        /// <param name="startDate">DateTime</param>
        /// <param name="endDate">DateTime</param>
        /// <returns>Two JSON-wrapped arrays of Events and CustomEvents</returns>
        [HttpGet]
        public IHttpActionResult GetEventsForDeviceFromDateToDate(string deviceId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var eventDtos =
                _context.Events.ToList()
                    .Where(c => c.DeviceId == deviceId)
                    .Select(Mapper.Map<Event, EventDto>);

            var customEventsDtos = _context.CustomEvents
                .ToList().Where(c => c.DeviceId == deviceId)
                .Select(Mapper.Map<CustomEvent, CustomEventDto>);



            if (startDate != null && endDate == null)
            {
                eventDtos = _context.Events.ToList()
                    .Where(c => c.DeviceId == deviceId)
                    .Where(c => c.CreatedTimeStamp.Value.Date >= startDate || c.CreatedTimeStamp >= startDate)
                    .Select(Mapper.Map<Event, EventDto>);

                customEventsDtos = _context.CustomEvents.ToList()
                    .Where(c => c.DeviceId == deviceId)
                    .Where(c => c.CreatedTimeStamp.Value.Date >= startDate || c.CreatedTimeStamp >= startDate)
                    .Select(Mapper.Map<CustomEvent, CustomEventDto>);
            }
            else if (startDate == null && endDate != null)
            {
                eventDtos = _context.Events.ToList()
                    .Where(c => c.DeviceId == deviceId)
                    .Where(c => c.CreatedTimeStamp.Value.Date <= endDate || c.CreatedTimeStamp <= endDate)
                    .Select(Mapper.Map<Event, EventDto>);

                customEventsDtos = _context.CustomEvents.ToList()
                    .Where(c => c.DeviceId == deviceId)
                    .Where(c => c.CreatedTimeStamp.Value.Date <= endDate || c.CreatedTimeStamp <= endDate)
                    .Select(Mapper.Map<CustomEvent, CustomEventDto>);
            }
            else if (startDate != null && endDate != null)
            {
                eventDtos = _context.Events.ToList()
                    .Where(c => c.DeviceId == deviceId)
                    .Where(c => (c.CreatedTimeStamp.Value.Date >= startDate || c.CreatedTimeStamp >= startDate)
                                && (c.CreatedTimeStamp.Value.Date <= endDate || c.CreatedTimeStamp <= endDate))
                    .Select(Mapper.Map<Event, EventDto>);

                customEventsDtos = _context.CustomEvents.ToList()
                    .Where(c => c.DeviceId == deviceId)
                    .Where(c => (c.CreatedTimeStamp.Value.Date >= startDate || c.CreatedTimeStamp >= startDate)
                                && (c.CreatedTimeStamp.Value.Date <= endDate || c.CreatedTimeStamp <= endDate))
                    .Select(Mapper.Map<CustomEvent, CustomEventDto>);
            }

            var response = new EventsWrapper {Events = eventDtos, CustomEvents = customEventsDtos};

            return Ok(response);
        }


        /// <summary>
        /// Update an Event.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eventDto"></param>
        /// <returns>Ok</returns>
        [HttpPut]
        public IHttpActionResult UpdateEvent(string id, EventDto eventDto)
        {
            var eventInDb = _context.Events
                .SingleOrDefault(c => c.Id == id);

            if (eventInDb == null)
                return NotFound();

            Mapper.Map(eventDto, eventInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
