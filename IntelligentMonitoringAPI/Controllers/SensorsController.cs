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
    public class SensorsController : ApiController
    {
        private IntelliMonDbContext _context;

        public SensorsController()
        {
            _context = new IntelliMonDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetSensors()
        {
            var sensorsDto = _context.Sensors.ToList()
                .Select(Mapper.Map<Sensor, SensorDto>);

            return Ok(sensorsDto);
        }
        
        [HttpGet]
        public IHttpActionResult GetSensor(int id)
        {
            var sensor = _context.Sensors.SingleOrDefault(c => c.Id == id);

            if (sensor == null)
                return NotFound();

            return Ok(Mapper.Map<Sensor, SensorDto>(sensor));
        }
        
        
        [HttpPost]
        public IHttpActionResult CreateSensor(SensorDto sensorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sensor = Mapper.Map<SensorDto, Sensor>(sensorDto);

            _context.Sensors.Add(sensor);
            _context.SaveChanges();

            sensorDto.Id = sensor.Id;

            return Created(new Uri(Request.RequestUri + "/" + sensor.Id), sensorDto);
        }

        
        [HttpPut]
        public IHttpActionResult UpdateSensor(int id, SensorDto sensorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sensorInDb = _context.Sensors.SingleOrDefault(c => c.Id == id);

            if (sensorInDb == null)
                return NotFound();

            Mapper.Map(sensorDto, sensorInDb);

            _context.SaveChanges();

            return Ok();
        }
        
        [HttpDelete]
        public IHttpActionResult DeleteSensor(int id)
        {
            var device = _context.Sensors.SingleOrDefault(c => c.Id == id);
            if (device == null)
                return NotFound();

            _context.Sensors.Remove(device);
            _context.SaveChanges();

            return Ok();
        }
        
    }
}
