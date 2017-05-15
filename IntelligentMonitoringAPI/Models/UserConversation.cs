using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace IntelligentMonitoringAPI.Models
{
    public class  UserConversation
    {
        public int Id { get; set; }
        public string ChannelId { get; set; }
        public string ConversationId { get; set; }
    }
}

