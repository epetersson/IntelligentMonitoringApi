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
    public class LocationsController : ApiController
    {
        private IntelliMonDbContext _context;
        
        public LocationsController()
        {
            _context = new IntelliMonDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetLocations()
        {
            var locationDtos = _context.Locations.ToList()
                .Select(Mapper.Map<Location, LocationDto>);

            return Ok(locationDtos);
        }

        [HttpGet]
        public IHttpActionResult GetLocation(string id)
        {
            var location = _context.Locations.SingleOrDefault(c => c.Id == id);
            if (location == null)
                return NotFound();

            return Ok(Mapper.Map<Location, LocationDto>(location));
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

            return Created(new Uri(Request.RequestUri + "/" + location.Id), locationDto);
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

        [HttpGet]
        [Route("api/locations/{locationId}/devices")]
        public IHttpActionResult GetDevicesInLocation(string locationId)
        {
            var locationDeviceDtos = _context.Devices
                .Where(c => c.LocationId == locationId)
                .ToList()
                .Select(Mapper.Map<Device, DeviceDto>);

            if (!locationDeviceDtos.Any())
                return NotFound();

            return Ok(locationDeviceDtos);
        }
    }
}
