using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Http.Description;
using AutoMapper;
using IntelligentMonitoringAPI.Models;
using IntelligentMonitoringAPI.Models.DTOs;
using IntelligentMonitoringAPI.Models.Wrappers;
using IntelligentMonitoringBackend.ModelsDTO;
using Newtonsoft.Json;

namespace IntelligentMonitoringAPI.Controllers
{
    /// <summary>
    /// Class defines endpoints related to Device.
    /// </summary>
    public class DevicesController : ApiController
    {
        
        private IntelliMonDbContext _context;

        /// <summary>
        /// Constructor initiates the database context.
        /// </summary>
        public DevicesController()
        {
            _context = new IntelliMonDbContext();
        }

        /// <summary>
        /// Get all Devices
        /// </summary>
        /// <returns>JSON-wrapped array of Devices</returns>
        [HttpGet]
        public IHttpActionResult GetDevices()
        {
            var deviceDtos = _context.Devices.ToList()
                .Select(Mapper.Map<Device, DeviceDto>);          

            var response = new DevicesWrapper {Devices = deviceDtos};

            return Ok(response);
        }

        /// <summary>
        /// Get a device by its id.
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>Device</returns>
        [HttpGet]
        public IHttpActionResult GetDevice(string id)
        {
            var device = _context.Devices
                .SingleOrDefault(c => c.Id == id);

            if (device == null)
                return NotFound();
            
            return Ok(Mapper.Map<Device, DeviceDto>(device));
        }

        /// <summary>
        /// Get a device by name.
        /// </summary>
        /// <param name="deviceName">string</param>
        /// <returns>Device</returns>
        [HttpGet]
        public IHttpActionResult GetDeviceByName(string deviceName)
        {
            var device = _context.Devices
                .SingleOrDefault(c => c.Name == deviceName);

            if (device == null)
                return NotFound();

            return Ok(Mapper.Map<Device, DeviceDto>(device));
        }

        /// <summary>
        /// Get all sensors within a device by the devices' id.
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>JSON-wrapped array of Sensors</returns>
        [HttpGet]
        [Route("api/Devices/{id}/sensors")]
        public IHttpActionResult GetDeviceSensors(string id)
        {
            var deviceSensorDtos = _context.Sensors
                .Where(c => c.DeviceId == id)
                .ToList()
                .Select(Mapper.Map<Sensor, SensorDto>);

            if (!deviceSensorDtos.Any())
                return NotFound();

            var response = new SensorsWrapper { Sensors = deviceSensorDtos };

            return Ok(response);
        }

        /// <summary>
        /// Get a devices' position by Id.
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>Position</returns>
        [HttpGet]
        [Route("api/Devices/{id}/position")]
        public IHttpActionResult GetDevicePosition(string id)
        {
            var device = _context.Devices
                .SingleOrDefault(c => c.Id == id);

            var position = _context.Positions
                .SingleOrDefault(c => c.Id == device.PositionId);

            if (position == null)
                return NotFound();

            return Ok(Mapper.Map<Position, PositionDto>(position));
        }

        /// <summary>
        /// Get events for a device by its id.
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>JSON-wrapped array of Events</returns>
        [HttpGet]
        [Route("api/Devices/{id}/events")]
        public IHttpActionResult GetEventsForDevice(string id)
        {
            var deviceEventDtos =
                _context.Events.ToList()
                    .Where(c => c.DeviceId == id)
                    .Select(Mapper.Map<Event, EventDto>);

            var customEventsDtos = _context.CustomEvents
                .ToList().Where(c => c.DeviceId == id)
                .Select(Mapper.Map<CustomEvent, CustomEventDto>);

            var response = new EventsWrapper { Events = deviceEventDtos, CustomEvents = customEventsDtos };

            return Ok(response);
        }

        /// <summary>
        /// Get all Failure Proned Devices
        /// </summary>
        /// <returns>JSON-wrapped array of FailurePronedDevices</returns>
        [HttpGet]
        [Route("api/Devices/FailureProned")]
        public IHttpActionResult GetFailurePronedDevices()
        {
            var failurePronedDeviceDtos = _context.FailurePronedDevices
                .ToList()
                .Select(Mapper.Map<FailurePronedDevice,FailurePronedDeviceDto>);

            var response = new FailurePronedDevicesWrapper {FailurePronedDevices = failurePronedDeviceDtos};

            return Ok(response);
        }
    }
}
