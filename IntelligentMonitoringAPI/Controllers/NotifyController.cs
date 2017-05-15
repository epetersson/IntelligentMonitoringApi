using AutoMapper;
using IntelligentMonitoringAPI.Models;
using IntelligentMonitoringAPI.Models.Wrappers;
using IntelligentMonitoringBackend.ModelsDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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

        //Update the database with new conversations. If it fails, return error statuscode
        [HttpPost]
        public IHttpActionResult PostConversations(string conversationID, string channelID, string serviceUrl, string fromId, string fromName, string toId, string toName)
        {
            UserConversation conversation = new UserConversation()
            {
                ConversationId = conversationID,
                ChannelId = channelID,
                ServiceUrl = serviceUrl,
                FromId = fromId,
                FromName = fromName,
                ToId = toId,
                ToName = toName
            };

            var existingAuthorCount = _context.UserConversations.Count(a => a.ConversationId == conversationID);
            if (existingAuthorCount == 0)
            {
            _context.UserConversations.Add(conversation);
            }

            
           if ( _context.SaveChanges() > 0)
            {
                return StatusCode(HttpStatusCode.Created);
            }
            return StatusCode(HttpStatusCode.Conflict);
        }


        //If an event has happend, post the event and all the conversations.
        [HttpPost]
        public IHttpActionResult PostConversationsEvents(EventDTO content)
        {
            var conversations = _context.UserConversations.ToList();   
            var convResponse = new UserConversationWrapper { Conversations = conversations, Event = content };
           
            RestClient client = new RestClient("http://intelligentmonitoringbotservice.azurewebsites.net/api/1/notify/");

            var request = new RestRequest($"conversationsEvents", Method.POST);
            request.AddBody(convResponse);
            
            string result = client.Execute(request).Content;
            return Ok(convResponse);
        }
    }
}
