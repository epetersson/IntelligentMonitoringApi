using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Class defines endpoints related to Position
    /// </summary>
    public class PositionsController : ApiController
    {
        private IntelliMonDbContext _context;

        /// <summary>
        /// Constructor initiates the db context
        /// </summary>
        public PositionsController()
        {
            _context = new IntelliMonDbContext();
        }

        /// <summary>
        /// Get all Positions.
        /// </summary>
        /// <returns>JSON-wrapped array of Positions</returns>
        [HttpGet]
        public IHttpActionResult GetPositions()
        {
            var positionDtos = _context.Positions
                .ToList()
                .Select(Mapper.Map<Position, PositionDto>);

            var response = new PositionsWrapper {Positions = positionDtos};

            return Ok(response);
        }

        /// <summary>
        /// Get a Position by its id.
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>Position</returns>
        [HttpGet]
        public IHttpActionResult GetPosition(string id)
        {
            var position = _context.Positions.SingleOrDefault(c => c.Id == id);

            if (position == null)
                return NotFound();

            return Ok(Mapper.Map<Position, PositionDto>(position));
        }

        /// <summary>
        /// Get a Devices' Position by its id
        /// </summary>
        /// <param name="deviceId">string</param>
        /// <returns>Position</returns>
        [HttpGet]
        public IHttpActionResult GetPositionForDevice(string deviceId)
        {
            var device = _context.Devices.SingleOrDefault(c => c.Id == deviceId);

            var position = _context.Positions.SingleOrDefault(c => c.Id == device.PositionId);

            if (position == null)
                return NotFound();

            return Ok(Mapper.Map<Position, PositionDto>(position));
        }

    }
}
