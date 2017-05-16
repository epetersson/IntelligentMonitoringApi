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
    public class DeviceHistoriesController : ApiController
    {
        private IntelliMonDbContext _context;

        public DeviceHistoriesController()
        {
            _context = new IntelliMonDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetDeviceHistory()
        {
            var deviceHistoryDtos = _context.DeviceHistories.ToList()
                .Select(Mapper.Map<DeviceHistory, DeviceHistoryDto>);

            var response = new DeviceHistoriesWrapper { DeviceHistories = deviceHistoryDtos };

            return Ok(response);
        }
        [HttpGet]
        public IHttpActionResult GetDeviceHistoryFromDateToDate(string id, DateTime startDate, DateTime endDate)
        {
            var deviceHistoryDtos = _context.DeviceHistories.ToList()
                .Where(c => c.DeviceId == id)
                .Where(c => c.CreatedTimeStamp >= startDate && c.CreatedTimeStamp <= endDate)
                .Select(Mapper.Map<DeviceHistory, DeviceHistoryDto>);

            var response = new DeviceHistoriesWrapper {DeviceHistories = deviceHistoryDtos};

            return Ok(response);
        }

        [HttpGet]
        public IHttpActionResult GetDeviceHistoryById(string id)
        {
            var deviceHistoryDtos =
                _context.DeviceHistories.ToList()
                    .Where(c => c.DeviceId == id)
                    .Select(Mapper.Map<DeviceHistory, DeviceHistoryDto>);
            var response = new DeviceHistoriesWrapper {DeviceHistories = deviceHistoryDtos};

            return Ok(response);

        }
    }
}
