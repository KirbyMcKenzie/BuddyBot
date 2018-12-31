using System;
using System.Collections.Generic;
using System.Text;

namespace BuddyBot.Repository.Models
{
    public class SmallTalkResponse
    {
        public Guid Id { get; set; }
        public string IntentName { get; set; }
        public string IntentGroup { get; set; }
        public string IntentResponse { get; set; }
    }
}
