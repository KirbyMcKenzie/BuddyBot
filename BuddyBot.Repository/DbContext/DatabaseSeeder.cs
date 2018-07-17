using BuddyBot.Repository.Models;
using System;

namespace BuddyBot.Repository.DbContext
{
    public class DatabaseSeeder
    {
        public WeatherConditionResponse[] BuildWeatherConditionResponses()
        {
            WeatherConditionResponse[] weatherConditionResponseList =
            {
                // Group 2xx: Thunderstorm
                BuildWeatherConditionResponse(200,"thunderstorm with light rain","Thunderstorm","thunderstorm with light rain"),
                BuildWeatherConditionResponse(201,"thunderstorm with rain","Thunderstorm","thunderstorm with rain"),
                BuildWeatherConditionResponse(202,"thunderstorm with heavy rain","Thunderstorm","thunderstorm with heavy rain"),
                BuildWeatherConditionResponse(210,"light thunderstorm","Thunderstorm","light thunderstorm"),
                BuildWeatherConditionResponse(211,"thunderstorm","Thunderstorm","thunderstorm"),
                BuildWeatherConditionResponse(212,"heavy thunderstorm","Thunderstorm","heavy thunderstorm"),
                BuildWeatherConditionResponse(221,"ragged thunderstorm","Thunderstorm","ragged thunderstorm"),
                BuildWeatherConditionResponse(230,"thunderstorm with light drizzle","Thunderstorm","thunderstorm with light drizzle"),
                BuildWeatherConditionResponse(231,"thunderstorm with drizzle","Thunderstorm","thunderstorm with drizzle"),
                BuildWeatherConditionResponse(232,"thunderstorm with heavy drizzle","Thunderstorm","thunderstorm with heavy drizzle"),
                
                // Group 3xx: Drizzle
                BuildWeatherConditionResponse(300,"light intensity drizzle","Drizzle","light intensity drizzle"),
                BuildWeatherConditionResponse(301,"drizzle","Drizzle","drizzle"),
                BuildWeatherConditionResponse(302,"heavy intensity drizzle","Drizzle","heavy intensity drizzle"),
                BuildWeatherConditionResponse(310,"light intensity drizzle rain","Drizzle","light intensity drizzle rain"),
                BuildWeatherConditionResponse(311,"drizzle rain","Drizzle","drizzle rain"),
                BuildWeatherConditionResponse(312,"heavy intensity drizzle rain","Drizzle","heavy intensity drizzle rain"),
                BuildWeatherConditionResponse(313,"shower rain and drizzle","Drizzle","shower rain and drizzle"),

                // Group 5xx: Rain
                BuildWeatherConditionResponse(500,"light rain","Rain","light rain"),
                BuildWeatherConditionResponse(501,"moderate rain","Rain","moderate rain"),
                BuildWeatherConditionResponse(502,"heavy intensity rain","Rain","heavy intensity rain"),
                BuildWeatherConditionResponse(503,"very heavy rain","Rain","very heavy rain"),
                BuildWeatherConditionResponse(504,"extreme rain","Rain","extreme rain"),
                BuildWeatherConditionResponse(511,"freezing rain","Rain","freezing rain"),
                BuildWeatherConditionResponse(520,"light intensity shower rain","Rain","light intensity shower rain"),
                BuildWeatherConditionResponse(521,"shower rain","Rain","shower rain"),
                BuildWeatherConditionResponse(522,"heavy intensity shower rain","Rain","heavy intensity shower rain"),
                BuildWeatherConditionResponse(531,"ragged shower rain","Rain","ragged shower rain"),

                // Group 6xx: Snow
                BuildWeatherConditionResponse(600,"light snow","Snow","light snow"),
                BuildWeatherConditionResponse(601,"snow","Snow","snow"),
                BuildWeatherConditionResponse(602,"heavy snow","Snow","heavy snow"),
                BuildWeatherConditionResponse(611,"sleet","Snow","sleet"),
                BuildWeatherConditionResponse(612,"shower sleet","Snow","shower sleet"),
                BuildWeatherConditionResponse(615,"light rain and snow","Snow","light rain and snow"),
                BuildWeatherConditionResponse(616,"rain and snow","Snow","rain and snow"),
                BuildWeatherConditionResponse(620,"light shower snow","Snow","light shower snow"),
                BuildWeatherConditionResponse(621,"shower snow","Snow","shower snow"),
                BuildWeatherConditionResponse(622,"heavy shower snow","Snow","heavy shower snow"),

                // Group 7xx: Atmosphere
                BuildWeatherConditionResponse(701,"mist","Atmosphere","mist"),
                BuildWeatherConditionResponse(711,"smoke","Atmosphere","smoke"),
                BuildWeatherConditionResponse(721,"haze","Atmosphere","haze"),
                BuildWeatherConditionResponse(731,"sand, dust whirls","Atmosphere","sand, dust whirls"),
                BuildWeatherConditionResponse(741,"fog","Atmosphere","fog"),
                BuildWeatherConditionResponse(751,"sand","Atmosphere","sand"),
                BuildWeatherConditionResponse(761,"dust","Atmosphere","dust"),
                BuildWeatherConditionResponse(762,"volcanic ash","Atmosphere","volcanic ash"),
                BuildWeatherConditionResponse(771,"squalls","Atmosphere","squalls"),
                BuildWeatherConditionResponse(781,"tornado","Atmosphere","tornado"),

                // Group 800: Clear
                BuildWeatherConditionResponse(800,"clear sky","Clear","clear sky"),

                // Group 80x: Clouds
                BuildWeatherConditionResponse(801,"few clouds","Clouds","few clouds"),
                BuildWeatherConditionResponse(802,"scattered clouds","Clouds","scattered clouds"),
                BuildWeatherConditionResponse(803,"broken clouds","Clouds","broken clouds"),
                BuildWeatherConditionResponse(804,"overcast clouds","Clouds","overcast clouds"),

            };

            return weatherConditionResponseList;
        }

        private WeatherConditionResponse BuildWeatherConditionResponse(int id, string condition, string group, string response)
        {
            return new WeatherConditionResponse()
            {
                Id = id,
                Condition = condition,
                Group = group,
                 MappedConditionResponse = response
            };
        }
    }
}