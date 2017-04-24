using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using IntelligentMonitoringAPI.Models;
using IntelligentMonitoringAPI.Models.DTOs;

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
            var customersDto = _context.Devices.ToList()
                .Select(Mapper.Map<Device, DeviceDto>);

            return Ok(customersDto);
        }

        [HttpGet]
        public IHttpActionResult GetDevice(string id)
        {
            var device = _context.Devices
                .SingleOrDefault(c => c.SigmaId == id);

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

            return Created(new Uri(Request.RequestUri + "/" + device.Id), deviceDto);
        }
        
        
        [HttpPut]
        public IHttpActionResult UpdateDevice(string id, DeviceDto deviceDto)
        {
            var deviceInDb = _context.Devices.SingleOrDefault(c => c.SigmaId == id);

            if (deviceInDb == null)
                return NotFound();

            Mapper.Map(deviceDto, deviceInDb);
            _context.SaveChanges();

            return Ok();

        }

        [HttpDelete]
        public IHttpActionResult DeleteDevice(string id)
        {
            var device = _context.Devices.SingleOrDefault(c => c.SigmaId == id);

            if (device == null)
                return NotFound();

            _context.Devices.Remove(device);
            _context.SaveChanges();

            return Ok();
        }
    }
}
