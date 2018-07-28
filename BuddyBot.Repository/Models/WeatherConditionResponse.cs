using System;
using System.Collections.Generic;
using System.Text;

namespace BuddyBot.Repository.Models
{
    public class WeatherConditionResponse
    {
        public int Id { get; set; }
        public string Condition { get; set; }
        public string MappedConditionResponse{ get; set; }
        public string Group { get; set; }
    }
}
