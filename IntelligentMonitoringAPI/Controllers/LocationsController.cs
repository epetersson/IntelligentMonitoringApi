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
using IntelligentMonitoringAPI.Tools;

namespace IntelligentMonitoringAPI.Controllers
{
    /// <summary>
    /// Class defines endpoints related to Location
    /// </summary>
    public class LocationsController : ApiController
    {
        private IntelliMonDbContext _context;
        private DeviceNetwork deviceNetwork;

        /// <summary>
        /// Constructor initiates the database context.
        /// </summary>
        public LocationsController()
        {
            _context = new IntelliMonDbContext();
            var authorization = _context.AuthorizationTokens.FirstOrDefault();

            deviceNetwork = DeviceNetworkFetcher.FetchNetwork(_context, authorization);
        }

        /// <summary>
        /// Get all Locations
        /// </summary>
        /// <returns>JSON-Wrapped array of Location</returns>
        [HttpGet]
        public IHttpActionResult GetLocations()
        {
            var locationDtos = _context.Locations
                .Where(obj => String.Compare(obj.DeviceNetworkId, deviceNetwork.Id) == 0).ToList()
                .Select(Mapper.Map<Location, LocationDto>);

            var response = new LocationsWrapper {Locations = locationDtos};

            return Ok(response);
        }

        /// <summary>
        /// Get a Location by its Id
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>Location</returns>
        [HttpGet]
        public IHttpActionResult GetLocation(string id)
        {
            var location = _context.Locations.SingleOrDefault(c => c.Id == id);

            if (location == null)
                return NotFound();

            return Ok(Mapper.Map<Location, LocationDto>(location));
        }

        /// <summary>
        /// Get all Devices within a Location by its Id
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>JSON-wrapped array with Devices</returns>
        [HttpGet]
        [Route("api/Locations/{id}/devices")]
        public IHttpActionResult GetDevicesInLocation(string id)
        {
            var locationDeviceDtos = _context.Devices
                .Where(c => c.LocationId == id)
                .ToList()
                .Select(Mapper.Map<Device, DeviceDto>);

            if (!locationDeviceDtos.Any())
                return NotFound();

            var response = new DevicesWrapper { Devices = locationDeviceDtos };

            return Ok(response);
        }
    }
}
