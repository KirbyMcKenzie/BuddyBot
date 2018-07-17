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
                BuildWeatherConditionReport(200,"thunderstorm with light rain","Thunderstorm","thunderstorm with light rain"),
                BuildWeatherConditionReport(201,"thunderstorm with rain","Thunderstorm","thunderstorm with rain"),
                BuildWeatherConditionReport(202,"thunderstorm with heavy rain","Thunderstorm","thunderstorm with heavy rain"),
                BuildWeatherConditionReport(210,"light thunderstorm","Thunderstorm","light thunderstorm"),
                BuildWeatherConditionReport(211,"thunderstorm","Thunderstorm","thunderstorm"),
                BuildWeatherConditionReport(212,"heavy thunderstorm","Thunderstorm","heavy thunderstorm"),
                BuildWeatherConditionReport(221,"ragged thunderstorm","Thunderstorm","ragged thunderstorm"),
                BuildWeatherConditionReport(230,"thunderstorm with light drizzle","Thunderstorm","thunderstorm with light drizzle"),
                BuildWeatherConditionReport(231,"thunderstorm with drizzle","Thunderstorm","thunderstorm with drizzle"),
                BuildWeatherConditionReport(232,"thunderstorm with heavy drizzle","Thunderstorm","thunderstorm with heavy drizzle"),
                
                // Group 3xx: Drizzle
                BuildWeatherConditionReport(300,"light intensity drizzle","Drizzle","light intensity drizzle"),
                BuildWeatherConditionReport(301,"drizzle","Drizzle","drizzle"),
                BuildWeatherConditionReport(302,"heavy intensity drizzle","Drizzle","heavy intensity drizzle"),
                BuildWeatherConditionReport(310,"light intensity drizzle rain","Drizzle","light intensity drizzle rain"),
                BuildWeatherConditionReport(311,"drizzle rain","Drizzle","drizzle rain"),
                BuildWeatherConditionReport(312,"heavy intensity drizzle rain","Drizzle","heavy intensity drizzle rain"),
                BuildWeatherConditionReport(313,"shower rain and drizzle","Drizzle","shower rain and drizzle"),

                // Group 5xx: Rain
                BuildWeatherConditionReport(500,"light rain","Rain","light rain"),
                BuildWeatherConditionReport(501,"moderate rain","Rain","moderate rain"),
                BuildWeatherConditionReport(502,"heavy intensity rain","Rain","heavy intensity rain"),
                BuildWeatherConditionReport(503,"very heavy rain","Rain","very heavy rain"),
                BuildWeatherConditionReport(504,"extreme rain","Rain","extreme rain"),
                BuildWeatherConditionReport(511,"freezing rain","Rain","freezing rain"),
                BuildWeatherConditionReport(520,"light intensity shower rain","Rain","light intensity shower rain"),
                BuildWeatherConditionReport(521,"shower rain","Rain","shower rain"),
                BuildWeatherConditionReport(522,"heavy intensity shower rain","Rain","heavy intensity shower rain"),
                BuildWeatherConditionReport(531,"ragged shower rain","Rain","ragged shower rain"),

                // Group 6xx: Snow
                BuildWeatherConditionReport(600,"light snow","Snow","light snow"),
                BuildWeatherConditionReport(601,"snow","Snow","snow"),
                BuildWeatherConditionReport(602,"heavy snow","Snow","heavy snow"),
                BuildWeatherConditionReport(611,"sleet","Snow","sleet"),
                BuildWeatherConditionReport(612,"shower sleet","Snow","shower sleet"),
                BuildWeatherConditionReport(615,"light rain and snow","Snow","light rain and snow"),
                BuildWeatherConditionReport(616,"rain and snow","Snow","rain and snow"),
                BuildWeatherConditionReport(620,"light shower snow","Snow","light shower snow"),
                BuildWeatherConditionReport(621,"shower snow","Snow","shower snow"),
                BuildWeatherConditionReport(622,"heavy shower snow","Snow","heavy shower snow"),

                // Group 7xx: Atmosphere
                BuildWeatherConditionReport(701,"mist","Atmosphere","mist"),
                BuildWeatherConditionReport(711,"smoke","Atmosphere","smoke"),
                BuildWeatherConditionReport(721,"haze","Atmosphere","haze"),
                BuildWeatherConditionReport(731,"sand, dust whirls","Atmosphere","sand, dust whirls"),
                BuildWeatherConditionReport(741,"fog","Atmosphere","fog"),
                BuildWeatherConditionReport(751,"sand","Atmosphere","sand"),
                BuildWeatherConditionReport(761,"dust","Atmosphere","dust"),
                BuildWeatherConditionReport(762,"volcanic ash","Atmosphere","volcanic ash"),
                BuildWeatherConditionReport(771,"squalls","Atmosphere","squalls"),
                BuildWeatherConditionReport(781,"tornado","Atmosphere","tornado"),

                // Group 800: Clear
                BuildWeatherConditionReport(800,"clear sky","Clear","clear sky"),

                // Group 80x: Clouds
                BuildWeatherConditionReport(801,"few clouds","Clouds","few clouds"),
                BuildWeatherConditionReport(802,"scattered clouds","Clouds","scattered clouds"),
                BuildWeatherConditionReport(803,"broken clouds","Clouds","broken clouds"),
                BuildWeatherConditionReport(804,"overcast clouds","Clouds","overcast clouds"),

            };

            return weatherConditionResponseList;
        }

        private WeatherConditionResponse BuildWeatherConditionReport(int id, string condition, string group, string response)
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