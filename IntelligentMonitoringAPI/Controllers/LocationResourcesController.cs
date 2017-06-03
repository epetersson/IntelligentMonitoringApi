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
        private DeviceNetwork deviceNetwork;

        /// <summary>
        /// Constructor initiates the database context.
        /// </summary>
        public LocationResourcesController()
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
        /// Get all LocationResources
        /// </summary>
        /// <returns>JSON-wrapped array of LocationDtos</returns>
        [HttpGet]
        public IHttpActionResult GetLocationResources()
        {
            var locationResourceDtos = _context.LocationResources
                .Where(obj => String.Compare(obj.DeviceNetworkId, deviceNetwork.Id) == 0).ToList()
                .Select(Mapper.Map<LocationResource, LocationResourceDto>);

            var response = new LocationResourcesWrapper {LocationResources = locationResourceDtos};

            return Ok(response);
        }

        /// <summary>
        /// Get a LocationResource by its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
