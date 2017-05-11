namespace IntelligentMonitoringAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class UserConversation
    {
        public int Id { get; set; }

        [Key]
        [StringLength(100)]
        public string FromId { get; set; }

        [Required]
        [StringLength(100)]
        public string ChannelId { get; set; }

        [Required]
        [StringLength(100)]
        public string ConversationId { get; set; }
    }
}
