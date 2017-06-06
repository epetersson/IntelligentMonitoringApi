﻿using System;
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
    /// Class defines endpoints related to Sensors
    /// </summary>
    public class SensorsController : ApiController
    {
        
        private IntelliMonDbContext _context;
        private DeviceNetwork deviceNetwork;

        /// <summary>
        /// Constructor initates db context
        /// </summary>
        public SensorsController()
        {
            _context = new IntelliMonDbContext();
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
        /// Get all Sensors
        /// </summary>
        /// <returns>JSON-wrapped array of Sensor</returns>
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
        
        /// <summary>
        /// Get a Sensor by its Id
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>Sensor</returns>
        [HttpGet]
        public IHttpActionResult GetSensor(string id)
        {
            var sensor = _context.Sensors.SingleOrDefault(c => c.Id == id);

            if (sensor == null)
                return NotFound();

            return Ok(Mapper.Map<Sensor, SensorDto>(sensor));
        }

        /// <summary>
        /// Get all SensorMeasurements by a Sensors' Id
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>JSON-wrapped array of SensorMeasurements</returns>
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
    }
}
