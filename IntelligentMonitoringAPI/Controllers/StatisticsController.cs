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
    /// Class defines the endpoints related to DailyStatistics and HourlyStatistics.
    /// </summary>
    public class StatisticsController : ApiController
    {
        private IntelliMonDbContext _context;

        public StatisticsController()
        {
            _context = new IntelliMonDbContext();
        }

        /// <summary>
        /// Method defines endpoint for getting all DailyStatistics.
        /// </summary>
        /// <returns>Array of DailyStatisticsDtos wrapped in JSON-object</returns>
        [HttpGet]
        public IHttpActionResult GetDailyStatistics()
        {
            var dailyStatisticDtos = _context.DailyStatistics.ToList()
                .Select(Mapper.Map<DailyStatistic, DailyStatisticDto>);

            var response = new DailyStatisticsWrapper() { DailyStatistics = dailyStatisticDtos };

            return Ok(response);
        }

        /// <summary>
        /// Method defines endpoint for getting all HourlyStatistics for specified device.
        /// </summary>
        /// <param name="deviceId">string</param>
        /// <returns>Array of DeviceHistoryDtos wrapped in JSON-object</returns>
        [HttpGet]
        [Route("api/Statistics/{deviceId}/hourly")]
        public IHttpActionResult GetDeviceHistoryByDeviceId(string deviceId)
        {
            var deviceHistoryDtos =
                _context.HourlyStatistics.ToList()
                    .Where(c => c.DeviceId == deviceId)
                    .Select(Mapper.Map<HourlyStatistic, HourlyStatisticDto>);

            var response = new HourlyStatisticsWrapper {HourlyStatistics = deviceHistoryDtos};

            return Ok(response);
        }

        /// <summary>
        /// Method defines endpoint for getting all DailyStatistics for defined Device.
        /// </summary>
        /// <param name="deviceId">string</param>
        /// <returns>Array of DailyStatisticDtos wrapped in JSON-object</returns>
        [HttpGet]
        [Route("api/Statistics/{deviceId}/daily")]
        public IHttpActionResult GetDailyStatistics(string deviceId)
        {
            var dailyStatisticsDto = _context.DailyStatistics
                .ToList()
                .Where(c => c.DeviceId == deviceId)
                .Select(Mapper.Map<DailyStatistic, DailyStatisticDto>);

            var response = new DailyStatisticsWrapper {DailyStatistics = dailyStatisticsDto};

            return Ok(response);
        }

        /// <summary>
        /// Method defines endpoint for getting all DailyStatistics within a timespan for a device. 
        /// </summary>
        /// <param name="deviceId">string</param>
        /// <param name="startDate">DateTime</param>
        /// <param name="endDate">DateTime</param>
        /// <returns>Array of DailyStatisticDtos wrapped in JSON-object</returns>
        [HttpGet]
        public IHttpActionResult GetDailyStatisticForDeviceByDateToDate(string deviceId, DateTime startDate, DateTime endDate)
        {
            var endingDate = endDate.AddDays(1);

            var dailyStatisticDtos = _context.DailyStatistics.ToList()
                .Where(c => c.DeviceId == deviceId)
                .Where(c => c.CreatedTimeStamp >= startDate && c.CreatedTimeStamp <= endingDate)
                .Select(Mapper.Map<DailyStatistic, DailyStatisticDto>);

            var response = new DailyStatisticsWrapper { DailyStatistics = dailyStatisticDtos };

            return Ok(response);
        }
    }
}
