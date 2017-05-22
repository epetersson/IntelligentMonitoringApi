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

        public DevicesController()
        {
            _context = new IntelliMonDbContext();
        }

        /// <summary>
        /// Endpoint returns all Devices
        /// </summary>
        /// <returns>Array of DeviceDtos wrapped in JSON-Object</returns>
        [HttpGet]
        public IHttpActionResult GetDevices()
        {
            var deviceDtos = _context.Devices.ToList()
                .Select(Mapper.Map<Device, DeviceDto>);          

            var response = new DevicesWrapper {Devices = deviceDtos};

            return Ok(response);
        }

        /// <summary>
        /// Method defines endpoint for getting a deviced by id.
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>DeviceDto</returns>
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
        /// Method defines endpoint for getting a device by name
        /// </summary>
        /// <param name="deviceName">string</param>
        /// <returns>DeviceDto</returns>
        [HttpGet]
        public IHttpActionResult GetDeviceByName(string deviceName)
        {
            var device = _context.Devices.SingleOrDefault(c => c.Name == deviceName);

            if (device == null)
                return NotFound();

            return Ok(Mapper.Map<Device, DeviceDto>(device));
        }

        /// <summary>
        /// Method defines endpoint for getting all sensors within a device by the devices' id.
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>Array of SensorDtos wrapped in JSON-object</returns>
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
        /// Method defines endpoint for getting a devices' position by id.
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>PositionDto</returns>
        [HttpGet]
        [Route("api/Devices/{id}/position")]
        public IHttpActionResult GetDevicePosition(string id)
        {
            var device = _context.Devices.SingleOrDefault(c => c.Id == id);

            var position = _context.Positions.SingleOrDefault(c => c.Id == device.PositionId);

            if (position == null)
                return NotFound();

            return Ok(Mapper.Map<Position, PositionDto>(position));
        }

        /// <summary>
        /// Method defines endpoint for getting events of a device by id.
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>Array of EventDtos wrapped in JSON-object</returns>
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

        [HttpPost]
        public IHttpActionResult CreateDevice(DeviceDto deviceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var device = Mapper.Map<DeviceDto, Device>(deviceDto);

            _context.Devices.Add(device);
            _context.SaveChanges();

            deviceDto.Id = device.Id;

            return Created(new Uri(Request.RequestUri + "/" + device.Id), deviceDto);
        }
        
        
        [HttpPut]
        public IHttpActionResult UpdateDevice(string id, DeviceDto deviceDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var deviceInDb = _context.Devices.SingleOrDefault(c => c.Id == id);

            if (deviceInDb == null)
                return NotFound();

            Mapper.Map(deviceDto, deviceInDb);

            _context.SaveChanges();

            return Ok();

        }

        [HttpDelete]
        public IHttpActionResult DeleteDevice(string id)
        {
            var device = _context.Devices.SingleOrDefault(c => c.Id == id);

            if (device == null)
                return NotFound();

            _context.Devices.Remove(device);
            _context.SaveChanges();

            return Ok();
        }
    }
}
