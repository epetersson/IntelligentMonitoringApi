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
    public class PositionsController : ApiController
    {
        private IntelliMonDbContext _context;

        public PositionsController()
        {
            _context = new IntelliMonDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetPosition(string id)
        {
            var position = _context.Positions.SingleOrDefault(c => c.Id == id);

            if (position == null)
                return NotFound();

            var positionDto = Mapper.Map<Position, PositionDto>(position);

            var response = new PositionWrapper { Position = positionDto };

            return Ok(response);
        }

    }
}
