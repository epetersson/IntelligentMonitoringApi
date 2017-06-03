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
    /// Class defines endpoints related to LocationResource
    /// </summary>
    public class LocationResourcesController : ApiController
    {
        private IntelliMonDbContext _context;

        /// <summary>
        /// Constructor initiates the database context.
        /// </summary>
        public LocationResourcesController()
        {
            _context = new IntelliMonDbContext();
        }

        /// <summary>
        /// Get all LocationResources
        /// </summary>
        /// <returns>JSON-wrapped array of LocationResources</returns>
        [HttpGet]
        public IHttpActionResult GetLocationResources()
        {
            var locationResourceDtos = _context.LocationResources
                .ToList()
                .Select(Mapper.Map<LocationResource, LocationResourceDto>);

            var response = new LocationResourcesWrapper {LocationResources = locationResourceDtos};

            return Ok(response);
        }

        /// <summary>
        /// Get a LocationResource by its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>LocationResource</returns>
        [HttpGet]
        public IHttpActionResult GetLocationResource(string id)
        {
            var locationResource = _context.LocationResources
                .SingleOrDefault(c => c.Id == id);

            if (locationResource == null)
                return NotFound();

            return Ok(Mapper.Map<LocationResource, LocationResourceDto>(locationResource));
        }
    }
}
