using IntelligentMonitoringAPI.Models;
using IntelligentMonitoringBackend.ModelsDTO;
using System;
using System.Collections.Generic;

namespace IntelligentMonitoringAPI.Controllers
{
    internal class UserConversationWrapper
    {
        public IEnumerable<UserConversation> Conversations { get; set; }
        public EventDto Events { get; set; }

    }
}