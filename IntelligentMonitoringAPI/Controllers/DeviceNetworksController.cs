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

namespace IntelligentMonitoringAPI.Controllers
{
    public class DeviceNetworksController : ApiController
    {
        private IntelliMonDbContext _context;

        public DeviceNetworksController()
        {
            _context = new IntelliMonDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetDeviceNetworks()
        {
            var deviceNetworkDtos = _context.DeviceNetworks.ToList()
                .Select(Mapper.Map<DeviceNetwork, DeviceNetworkDto>);

            var response = new DeviceNetworksWrapper { DeviceNetworks = deviceNetworkDtos };

            return Ok(response);
        }

        [HttpGet]
        public IHttpActionResult GetDeviceNetwork(string id)
        {
            var deviceNetwork = _context.DeviceNetworks
                .SingleOrDefault(c => c.Id == id);

            if (deviceNetwork == null)
                return NotFound();

            var deviceNetworkDto = Mapper.Map<DeviceNetwork, DeviceNetworkDto>(deviceNetwork);

            var response = new DeviceNetworkWrapper { DeviceNetwork = deviceNetworkDto };

            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult CreateDeviceNetwork(DeviceNetworkDto deviceNetworkDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var deviceNetwork = Mapper.Map<DeviceNetworkDto, DeviceNetwork>(deviceNetworkDto);

            _context.DeviceNetworks.Add(deviceNetwork);
            _context.SaveChanges();

            deviceNetworkDto.Id = deviceNetwork.Id;

            var response = new DeviceNetworkWrapper { DeviceNetwork = deviceNetworkDto };

            return Created(new Uri(Request.RequestUri + "/" + deviceNetwork.Id), response);
        }

        [HttpPut]
        public IHttpActionResult UpdateDeviceNetwork(string id, DeviceNetworkDto deviceNetworkDto)
        {
            var deviceNetworkInDb = _context.DeviceNetworks.SingleOrDefault(c => c.Id == id);

            if (deviceNetworkInDb == null)
                return NotFound();

            Mapper.Map(deviceNetworkDto, deviceNetworkInDb);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteDeviceNetwork(string id)
        {
            var deviceNetwork = _context.DeviceNetworks.SingleOrDefault(c => c.Id == id);
            if (deviceNetwork == null)
                return NotFound();

            _context.DeviceNetworks.Remove(deviceNetwork);
            _context.SaveChanges();

            return Ok();
        }
    }
}
