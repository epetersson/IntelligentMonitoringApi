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
            var sensorDtos = _context.Sensors.ToList()
                .Select(Mapper.Map<Sensor, SensorDto>);

            var response = new SensorsWrapper { Sensors = sensorDtos };

            return Ok(response);
        }
        
        [HttpGet]
        public IHttpActionResult GetSensor(string id)
        {
            var sensor = _context.Sensors.SingleOrDefault(c => c.Id == id);

            if (sensor == null)
                return NotFound();

            var sensorDto = Mapper.Map<Sensor, SensorDto>(sensor);

            var response = new SensorWrapper { Sensor = sensorDto };

            return Ok(response);
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

            var response = new SensorWrapper { Sensor = sensorDto };

            return Created(new Uri(Request.RequestUri + "/" + sensor.Id), response);
        }

        
        [HttpPut]
        public IHttpActionResult UpdateSensor(string id, SensorDto sensorDto)
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
        public IHttpActionResult DeleteSensor(string id)
        {
            var device = _context.Sensors.SingleOrDefault(c => c.Id == id);
            if (device == null)
                return NotFound();

            _context.Sensors.Remove(device);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("api/sensors/{sensorId}/measurements")]
        public IHttpActionResult GetSensorMeasurements(string sensorId)
        {
            var sensorMeasurementsDtos = _context.SensorMeasurements
                .Where(c => c.SensorId == sensorId)
                .ToList()
                .Select(Mapper.Map<SensorMeasurement, SensorMeasurementDto>);

            if (!sensorMeasurementsDtos.Any())
                return NotFound();

            var response = new SensorMeasurementsWrapper { Measurements = sensorMeasurementsDtos };

            return Ok(response);
        }

        [HttpPost]
        [Route("api/sensors/{sensorId}/measurements/")]
        public IHttpActionResult CreateSensorMeasurement(string sensorId, SensorMeasurementDto sensorMeasurementDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var sensorMeasurement = Mapper.Map<SensorMeasurementDto, SensorMeasurement>(sensorMeasurementDto);

            _context.SensorMeasurements.Add(sensorMeasurement);
            _context.SaveChanges();

            sensorMeasurementDto.Id = sensorMeasurement.Id;

            return Created(new Uri(Request.RequestUri + "/" + sensorMeasurement.Id), sensorMeasurementDto);
        }

    }
}
