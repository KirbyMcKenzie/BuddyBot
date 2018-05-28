using System;
using System.Collections.Generic;
using System.Text;

namespace BuddyBot.Repository.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public Coordinate Coordinates { get; set; }

        public class Coordinate
        {
            public double Longitude { get; set; }
            public double latitude { get; set; }
        }
    }
}
