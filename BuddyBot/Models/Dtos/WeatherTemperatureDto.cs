using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuddyBot.Models.Dtos
{
    // TODO - See if it's necessary to rename props 
    public class WeatherTemperatureDto
    {
        public double temp { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
    }
}