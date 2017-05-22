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
    public class PositionsController : ApiController
    {
        private IntelliMonDbContext _context;

        public PositionsController()
        {
            _context = new IntelliMonDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetPositions()
        {
            var positionDtos = _context.Positions
                .ToList()
                .Select(Mapper.Map<Position, PositionDto>);

            var response = new PositionsWrapper {Positions = positionDtos};

            return Ok(response);
        }

        [HttpGet]
        public IHttpActionResult GetPosition(string id)
        {
            var position = _context.Positions.SingleOrDefault(c => c.Id == id);

            if (position == null)
                return NotFound();

            return Ok(Mapper.Map<Position, PositionDto>(position));
        }

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
