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
        private DeviceNetwork deviceNetwork;

        /// <summary>
        /// Constructor initiates the db context
        /// </summary>
        public StatisticsController()
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
        /// Get all DailyStatistics.
        /// </summary>
        /// <returns>JSON-wrapped array of DailyStatistics</returns>
        [HttpGet]
        public IHttpActionResult GetDailyStatistics()
        {
            var dailyStatisticDtos = _context.DailyStatistics
                .Where(obj => String.Compare(obj.DeviceNetworkId, deviceNetwork.Id) == 0)
                .ToList()
                .Select(Mapper.Map<DailyStatistic, DailyStatisticDto>);

            var response = new DailyStatisticsWrapper() { DailyStatistics = dailyStatisticDtos };

            return Ok(response);
        }

        /// <summary>
        /// Get all HourlyStatistics for a Device by its Id.
        /// </summary>
        /// <param name="deviceId">string</param>
        /// <returns>JSON-wrapped array of HourlyStatistics</returns>
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
        /// Get all DailyStatistics for a Device by its Id.
        /// </summary>
        /// <param name="deviceId">string</param>
        /// <returns>JSON-wrapped array of DailyStatistics</returns>
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
        /// Get all DailyStatistics within a timespan for a device. 
        /// </summary>
        /// <param name="deviceId">string</param>
        /// <param name="startDate">DateTime</param>
        /// <param name="endDate">DateTime</param>
        /// <returns>JSON-wrapped array of DailyStatistics</returns>
        [HttpGet]
        public IHttpActionResult GetDailyStatisticForDeviceByDateToDate(string deviceId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var dailyStatisticDtos = _context.DailyStatistics
                    .ToList()
                    .Where(c => c.DeviceId == deviceId)
                    .Select(Mapper.Map<DailyStatistic, DailyStatisticDto>);

            if (startDate != null && endDate == null)
            {
                dailyStatisticDtos = _context.DailyStatistics.ToList()
                .Where(c => c.DeviceId == deviceId)
                .Where(c => c.CreatedTimeStamp.Value.Date >= startDate || c.CreatedTimeStamp >= startDate)
                .Select(Mapper.Map<DailyStatistic, DailyStatisticDto>);
            }
            else if (startDate == null && endDate != null)
            {
                dailyStatisticDtos = _context.DailyStatistics.ToList()
                    .Where(c => c.DeviceId == deviceId)
                    .Where(c => c.CreatedTimeStamp.Value.Date <= endDate || c.CreatedTimeStamp <= endDate)
                    .Select(Mapper.Map<DailyStatistic, DailyStatisticDto>);
            }
            else if (startDate != null && endDate != null)
            {
                dailyStatisticDtos = _context.DailyStatistics.ToList()
               .Where(c => c.DeviceId == deviceId)
               .Where(c => (c.CreatedTimeStamp.Value.Date >= startDate || c.CreatedTimeStamp >= startDate) 
               && (c.CreatedTimeStamp.Value.Date <= endDate || c.CreatedTimeStamp <= endDate))
               .Select(Mapper.Map<DailyStatistic, DailyStatisticDto>);
            }        

            var response = new DailyStatisticsWrapper { DailyStatistics = dailyStatisticDtos };

            return Ok(response);
        }
    }
}
