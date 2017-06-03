using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelligentMonitoringAPI.Models
{
    public class AuthorizationToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime CreatedTimeStamp { get; set; }

        public AuthorizationToken() { }

        public AuthorizationToken(string token)
        {
            this.Token = token;
            this.CreatedTimeStamp = DateTime.Now;
        }
    }
}