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
    public class DeviceNetworksController : ApiController
    {
        /*
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

            return Ok(deviceNetworkDtos);
        }

        [HttpGet]
        public IHttpActionResult GetDeviceNetwork(int id)
        {
            var deviceNetwork = _context.DeviceNetworks
                .SingleOrDefault(c => c.Id == id);

            if (deviceNetwork == null)
                return NotFound();

            return Ok(Mapper.Map<DeviceNetwork, DeviceNetworkDto>(deviceNetwork));
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

            return Created(new Uri(Request.RequestUri + "/" + deviceNetwork.Id), deviceNetworkDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateDeviceNetwork(int id, DeviceNetworkDto deviceNetworkDto)
        {
            var deviceNetworkInDb = _context.DeviceNetworks.SingleOrDefault(c => c.Id == id);

            if (deviceNetworkInDb == null)
                return NotFound();

            Mapper.Map(deviceNetworkDto, deviceNetworkInDb);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteDeviceNetwork(int id)
        {
            var deviceNetwork = _context.DeviceNetworks.SingleOrDefault(c => c.Id == id);
            if (deviceNetwork == null)
                return NotFound();

            _context.DeviceNetworks.Remove(deviceNetwork);
            _context.SaveChanges();

            return Ok();
        }*/
    }
}
