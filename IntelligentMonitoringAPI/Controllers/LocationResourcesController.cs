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
    public class LocationResourcesController : ApiController
    {
        private IntelliMonDbContext _context;

        public LocationResourcesController()
        {
            _context = new IntelliMonDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetLocationResources()
        {
            var locationResourceDtos = _context.LocationResources
                .ToList()
                .Select(Mapper.Map<LocationResource, LocationResourceDto>);

            var response = new LocationResourcesWrapper {LocationResources = locationResourceDtos};

            return Ok(response);
        }

        [HttpGet]
        public IHttpActionResult GetLocationResource(string id)
        {
            var locationResource = _context.LocationResources.SingleOrDefault(c => c.Id == id);

            if (locationResource == null)
                return NotFound();

            return Ok(Mapper.Map<LocationResource, LocationResourceDto>(locationResource));
        }


    }
}
