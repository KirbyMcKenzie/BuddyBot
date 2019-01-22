using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BuddyBot.Models.Dtos
{
    public class WeatherSearchResultDto
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("cod")]
        public long Cod { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("list")]
        public SearchResultList[] SearchResultList { get; set; }
    }

    public class SearchResultList
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coord")]
        public Coord Coord { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("dt")]
        public long Dt { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("rain")]
        public object Rain { get; set; }

        [JsonProperty("snow")]
        public object Snow { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("weather")]
        public IList<Weather> Weather { get; set; }
    }

    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }

    public class Coord
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }

        [JsonProperty("sea_level", NullValueHandling = NullValueHandling.Ignore)]
        public double? SeaLevel { get; set; }

        [JsonProperty("grnd_level", NullValueHandling = NullValueHandling.Ignore)]
        public double? GrndLevel { get; set; }
    }

    public class Sys
    {
        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public class Weather
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public double Deg { get; set; }

        [JsonProperty("gust", NullValueHandling = NullValueHandling.Ignore)]
        public double? Gust { get; set; }
    }
}