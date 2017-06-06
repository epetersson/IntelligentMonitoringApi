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
        /// Get all DeviceNetworks.
        /// </summary>
        /// <returns>JSON-wrapped array of DeviceNetworks</returns>
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
        /// Get DeviceNetwork by its id.
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>DeviceNetwork</returns>
        [HttpGet]
        public IHttpActionResult GetDeviceNetwork(string id)
        {
            var deviceNetwork = _context.DeviceNetworks
                .SingleOrDefault(c => c.Id == id);

            if (deviceNetwork == null)
                return NotFound();

            return Ok(Mapper.Map<DeviceNetwork, DeviceNetworkDto>(deviceNetwork));
        }

        //NO CRUD operations for Device Networks
        /*
        /// <summary>
        /// Create a DeviceNetwork.
        /// </summary>
        /// <param name="deviceNetworkDto">DeviceNetworkDto</param>
        /// <returns>Created</returns>
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

        /// <summary>
        /// Update a DeviceNetwork.
        /// </summary>
        /// <param name="id">string</param>
        /// <param name="deviceNetworkDto">DeviceNetworkDto</param>
        /// <returns>Ok</returns>
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
        */
    }
}
