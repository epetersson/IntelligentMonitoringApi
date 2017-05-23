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
    /// <summary>
    /// Class defines the endpoints related to DeviceNetwork.
    /// </summary>
    public class DeviceNetworksController : ApiController
    {
        private IntelliMonDbContext _context;
        
        /// <summary>
        /// Constructor initiates the database context.
        /// </summary>
        public DeviceNetworksController()
        {
            _context = new IntelliMonDbContext();
        }

        /// <summary>
        /// Method defines the endpoint for getting all DeviceNetworks.
        /// </summary>
        /// <returns>Array of DeviceNetworkDtos wrapped in JSON-object</returns>
        [HttpGet]
        public IHttpActionResult GetDeviceNetworks()
        {
            var deviceNetworkDtos = _context.DeviceNetworks
                .ToList()
                .Select(Mapper.Map<DeviceNetwork, DeviceNetworkDto>);

            var response = new DeviceNetworksWrapper { DeviceNetworks = deviceNetworkDtos };

            return Ok(response);
        }

        /// <summary>
        /// Method defines endpoint for getting a DeviceNetwork by defined id.
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>DeviceNetworkDto</returns>
        [HttpGet]
        public IHttpActionResult GetDeviceNetwork(string id)
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
        public IHttpActionResult UpdateDeviceNetwork(string id, DeviceNetworkDto deviceNetworkDto)
        {
            var deviceNetworkInDb = _context.DeviceNetworks
                .SingleOrDefault(c => c.Id == id);

            if (deviceNetworkInDb == null)
                return NotFound();

            Mapper.Map(deviceNetworkDto, deviceNetworkInDb);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteDeviceNetwork(string id)
        {
            var deviceNetwork = _context.DeviceNetworks
                .SingleOrDefault(c => c.Id == id);

            if (deviceNetwork == null)
                return NotFound();

            _context.DeviceNetworks.Remove(deviceNetwork);
            _context.SaveChanges();

            return Ok();
        }
    }
}
