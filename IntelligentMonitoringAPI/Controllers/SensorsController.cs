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
        private DeviceNetwork deviceNetwork;

        public SensorsController()
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

        [HttpGet]
        public IHttpActionResult GetSensors()
        {
            var sensorDtos = _context.Sensors
                .Where(obj => String.Compare(obj.DeviceNetworkId, deviceNetwork.Id) == 0)
                .ToList()
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

            return Ok(Mapper.Map<Sensor, SensorDto>(sensor));
        }

        [HttpGet]
        [Route("api/Sensors/{id}/measurements")]
        public IHttpActionResult GetSensorMeasurements(string id)
        {
            var sensorMeasurementsDtos = _context.SensorMeasurements
                .Where(c => c.SensorId == id)
                .ToList()
                .Select(Mapper.Map<SensorMeasurement, SensorMeasurementDto>);

            if (!sensorMeasurementsDtos.Any())
                return NotFound();

            var response = new SensorMeasurementsWrapper { Measurements = sensorMeasurementsDtos };

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

            return Created(new Uri(Request.RequestUri + "/" + sensor.Id), sensorDto);
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

        [HttpPost]
        [Route("api/Sensors/{id}/measurements/")]
        public IHttpActionResult CreateSensorMeasurement(string id, SensorMeasurementDto sensorMeasurementDto)
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
