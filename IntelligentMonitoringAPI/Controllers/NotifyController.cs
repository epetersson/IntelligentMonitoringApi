using IntelligentMonitoringAPI.Models;
using IntelligentMonitoringBackend.ModelsDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
        /// This endpoint get called by the microservice to update the conversations in the db.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/notify/conversations")]
        public IHttpActionResult PostConversations()
        {
            Task<string> payload = ActionContext.Request.Content.ReadAsStringAsync();
            string body = payload.Result;
            JObject jObj = JObject.Parse(body);
            var convers = JsonConvert.DeserializeObject<UserConversation>(jObj["conversations"].ToString());

            UserConversation conversation = new UserConversation()
            {
                ConversationId = convers.ConversationId,
                ChannelId = convers.ChannelId,
                ServiceUrl = convers.ServiceUrl,
                FromId = convers.FromId,
                FromName = convers.FromName,
                ToId = convers.ToId,
                ToName = convers.ToName
            };

            var existingAuthorCount = _context.UserConversations.Count(a => a.ConversationId == convers.ConversationId);
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
        [Route("api/notify/conversationsEvents")]
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
