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

        /// <summary>
        /// Updates the database with a new conversation.
        /// </summary>
        /// <param name="conversationID"></param>
        /// <param name="channelID"></param>
        /// <param name="serviceUrl"></param>
        /// <param name="fromId"></param>
        /// <param name="fromName"></param>
        /// <param name="toId"></param>
        /// <param name="toName"></param>
        /// <returns></returns>
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

            if (_context.SaveChanges() > 0)
            {
                return StatusCode(HttpStatusCode.Created);
            }
            return StatusCode(HttpStatusCode.Conflict);
        }


        /// <summary>
        /// This endpoint get called by the backend when a new event occurs. It will send the event 
        /// and userConversations to the Microservice.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult PostConversationsEvents()
        {
            Task<string> payload = ActionContext.Request.Content.ReadAsStringAsync();
            string body = payload.Result;
            JObject jObj = JObject.Parse(body);
            var dbEvent = JsonConvert.DeserializeObject<EventDTO>(jObj["events"].ToString());

            var conversations = _context.UserConversations.ToList();

            if (conversations.Count < 1)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            dynamic jsonObject1 = new JObject();
            jsonObject1.conversations = JToken.FromObject(conversations);

            jsonObject1.events = JToken.FromObject(dbEvent);

            RestClient client = new RestClient("http://intelligentmonitoringbotservice.azurewebsites.net/api/1/");
            var request = new RestRequest($"notify/conversationsEvents", Method.POST);

            request.AddParameter("text/json", jsonObject1.ToString(), ParameterType.RequestBody);

            string result = client.Execute(request).StatusCode.ToString();
            return Ok(result);
        }
    }
}
