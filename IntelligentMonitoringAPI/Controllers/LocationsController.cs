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
            GetDeviceNetwork();
        }

        public void GetDeviceNetwork()
        {
            var authorization = _context.AuthorizationTokens.FirstOrDefault();

            if (authorization != null)
            {
                if (!String.IsNullOrEmpty(authorization.Token))
                {
                    deviceNetwork = _context.DeviceNetworks.Where(obj => String.Compare(obj.AuthToken, authorization.Token) == 0).FirstOrDefault();
                }
                else
                {
                    deviceNetwork = _context.DeviceNetworks.OrderByDescending(d => d.UpdatedTimeStamp).FirstOrDefault();
                }
            }
            else
            {
                deviceNetwork = _context.DeviceNetworks.OrderByDescending(d => d.UpdatedTimeStamp).FirstOrDefault();
            }
        }
        /// <summary>
        /// Get all Locations
        /// </summary>
        /// <returns>JSON-Wrapped array of LocationDtos</returns>
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
        /// <returns>LocationDto</returns>
        [HttpGet]
        public IHttpActionResult GetLocation(string id)
        {
            var location = _context.Locations.SingleOrDefault(c => c.Id == id);

            if (location == null)
                return NotFound();

            return Ok(Mapper.Map<Location, LocationDto>(location));
        }

        /// <summary>
        /// Get all Devices with in a Location by its Id
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>JSON-wrapped array with DeviceDtos</returns>
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

        [HttpPost]
        public IHttpActionResult CreateLocation(LocationDto locationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var location = Mapper.Map<LocationDto, Location>(locationDto);

            _context.Locations.Add(location);
            _context.SaveChanges();

            locationDto.Id = location.Id;

            var response = new LocationWrapper { Location = locationDto };

            return Created(new Uri(Request.RequestUri + "/" + location.Id), response);
        }

        [HttpPut]
        public IHttpActionResult UpdateLocation(string id, LocationDto locationDto)
        {
            var locationInDb = _context.Locations.SingleOrDefault(c => c.Id == id);

            if (locationInDb == null)
                return NotFound();

            Mapper.Map(locationDto, locationInDb);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteLocation(string id)
        {
            var location = _context.Locations.SingleOrDefault(c => c.Id == id);

            if (location == null)
                return NotFound();

            _context.Locations.Remove(location);
            _context.SaveChanges();

            return Ok();
        }
    }
}
