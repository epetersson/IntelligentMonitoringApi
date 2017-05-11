using AutoMapper;
using IntelligentMonitoringAPI.Models;
using IntelligentMonitoringAPI.Models.Wrappers;
using IntelligentMonitoringBackend.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntelligentMonitoringAPI.Controllers
{
    public class NotifyController : ApiController
    {

        private IntelliMonDbContext _context;

        public NotifyController()
        {
            _context = new IntelliMonDbContext();
        }

        //Update the database with new conversations. If it fails, just ignore the error.
        [HttpPost]
        public IHttpActionResult PostConversations(string conversationId, string channelId, string fromId)
        {
            UserConversation conversation = new UserConversation()
            {
                ConversationId = conversationId,
                ChannelId = channelId,
                Id = fromId
            };

            _context.UserConversations.Add(conversation);
            _context.SaveChanges();

            return Ok("OK");
        }


        //If an event has happend, post the event and all the conversations.
        [HttpPost]
        public IHttpActionResult PostConversationsEvents()
        {
            var eventsDtos = _context.Events.ToList()
                .Select(Mapper.Map<Event, EventDTO>);
            var eventsResponse = new EventsWrapper { Events = eventsDtos };

            var conversationsDtos = _context.UserConversations.ToList();
            var userConversationsResponse = conversationsDtos.ToString();

            return Ok("OK");
        }
    }
}
