using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using IntelligentMonitoringAPI.Models;
using IntelligentMonitoringAPI.Models.DTOs;
using IntelligentMonitoringAPI.Models.Wrappers;
using Newtonsoft.Json;

namespace IntelligentMonitoringAPI.Controllers
{
    public class DevicesController : ApiController
    {
        
        private IntelliMonDbContext _context;

        public DevicesController()
        {
            _context = new IntelliMonDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetDevices()
        {
            var deviceDtos = _context.Devices.ToList()
                .Select(Mapper.Map<Device, DeviceDto>);
            

            var response = new DevicesWrapper {Devices = deviceDtos};

            return Ok(response);
        }

        [HttpGet]
        public IHttpActionResult GetDevice(string id)
        {
            var device = _context.Devices
                .SingleOrDefault(c => c.Id == id);

            if (device == null)
                return NotFound();
            
            return Ok(Mapper.Map<Device, DeviceDto>(device));
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

        [HttpGet]
        [Route("api/devices/name/{deviceName}")]
        public IHttpActionResult GetDeviceByName(string deviceName)
        {
            var device = _context.Devices.SingleOrDefault(c => c.Name == deviceName);
            
            if (device == null)
                return NotFound();

            return Ok(Mapper.Map<Device,DeviceDto>(device));
        }

        [HttpGet]
        [Route("api/devices/{deviceId}/sensors")]
        public IHttpActionResult GetDeviceSensors(string deviceId)
        {
            var deviceSensorDtos = _context.Sensors
                .Where(c => c.DeviceId == deviceId)
                .ToList()
                .Select(Mapper.Map<Sensor, SensorDto>);

            if (!deviceSensorDtos.Any())
                return NotFound();

            var response = new SensorsWrapper { Sensors = deviceSensorDtos };

            return Ok(response);
        }
    }
}
