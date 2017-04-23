using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using IntelligentMonitoringAPI.Models;
using IntelligentMonitoringAPI.Models.DTOs;

namespace IntelligentMonitoringAPI.Controllers
{
    public class HistoriesController : ApiController
    {
        private IntelliMonDbContext _context;

        public HistoriesController()
        {
            _context = new IntelliMonDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetHistories()
        {
            var historyDtos = _context.Histories.ToList()
                .Select(Mapper.Map<History, HistoryDto>);

            return Ok(historyDtos);
        }

        [HttpGet]
        public IHttpActionResult GetHistory(int deviceId)
        {
            var deviceHistory = _context.Histories.ToList().Select(Mapper.Map<History, HistoryDto>);
            
            var deviceHistoryDto = deviceHistory.Select(c => c.Device_Id == deviceId);

            return Ok(deviceHistoryDto);

        }

        [HttpPost]
        public IHttpActionResult CreateHistory(HistoryDto historyDto)
        {
           if (!ModelState.IsValid)
                return BadRequest();

            var history = Mapper.Map<HistoryDto, History>(historyDto);
            _context.Histories.Add(history);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + history.Id), historyDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateHistory(int id, HistoryDto historyDto)
        {
            var historyInDb = _context.Histories.SingleOrDefault(c => c.Id == id);
            if (historyInDb == null)
                return NotFound();

            Mapper.Map(historyDto, historyInDb);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteHistory(int id)
        {
            var history = _context.Histories.SingleOrDefault(c => c.Id == id);
            if (history == null)
                return NotFound();

            _context.Histories.Remove(history);
            _context.SaveChanges();

            return Ok();
        }
    }
}
