namespace IntelligentMonitoringAPI.Models
{
    public class  UserConversation
    {
        public int Id { get; set; }
        public string ChannelId { get; set; }
        public string ConversationId { get; set; }

        public string ServiceUrl { get; set; }
        public string FromId { get; set; }

        public string FromName { get; set; }
        public string ToId { get; set; }

        public string ToName { get; set; }

    }
}

