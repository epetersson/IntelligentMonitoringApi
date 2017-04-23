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
        public IEnumerable<DeviceDto> GetDevices()
        {
            return _context.Devices.ToList().Select(Mapper.Map<Device, DeviceDto>);
        }

        [HttpGet]
        public DeviceDto GetDevice(string id)
        {
            var device = _context.Devices.SingleOrDefault(c => c.ExternalId == id);

            return Mapper.Map<Device, DeviceDto>(device);
        }
    }
}
