using Microsoft.EntityFrameworkCore.Migrations;

namespace BuddyBot.Repository.Migrations
{
    public partial class AddSmallTalkResponseSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 504);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 511);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 520);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 521);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 522);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 531);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 600);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 601);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 602);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 611);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 612);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 615);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 616);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 620);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 621);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 622);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 701);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 711);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 721);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 731);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 741);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 751);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 761);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 762);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 771);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 781);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 800);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 801);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 802);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 803);

            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 804);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WeatherConditionResponse",
                columns: new[] { "Id", "Condition", "Group", "MappedConditionResponse" },
                values: new object[,]
                {
                    { 200, "thunderstorm with light rain", "Thunderstorm", "thunderstorm with light rain" },
                    { 601, "snow", "Snow", "snow" },
                    { 602, "heavy snow", "Snow", "heavy snow" },
                    { 611, "sleet", "Snow", "sleet" },
                    { 612, "shower sleet", "Snow", "shower sleet" },
                    { 615, "light rain and snow", "Snow", "light rain and snow" },
                    { 616, "rain and snow", "Snow", "rain and snow" },
                    { 620, "light shower snow", "Snow", "light shower snow" },
                    { 621, "shower snow", "Snow", "shower snow" },
                    { 622, "heavy shower snow", "Snow", "heavy shower snow" },
                    { 701, "mist", "Atmosphere", "mist" },
                    { 600, "light snow", "Snow", "light snow" },
                    { 711, "smoke", "Atmosphere", "smoke" },
                    { 731, "sand, dust whirls", "Atmosphere", "sand, dust whirls" },
                    { 741, "fog", "Atmosphere", "fog" },
                    { 751, "sand", "Atmosphere", "sand" },
                    { 761, "dust", "Atmosphere", "dust" },
                    { 762, "volcanic ash", "Atmosphere", "volcanic ash" },
                    { 771, "squalls", "Atmosphere", "squalls" },
                    { 781, "tornado", "Atmosphere", "tornado" },
                    { 800, "clear sky", "Clear", "clear sky" },
                    { 801, "few clouds", "Clouds", "few clouds" },
                    { 802, "scattered clouds", "Clouds", "scattered clouds" },
                    { 721, "haze", "Atmosphere", "haze" },
                    { 531, "ragged shower rain", "Rain", "ragged shower rain" },
                    { 522, "heavy intensity shower rain", "Rain", "heavy intensity shower rain" },
                    { 521, "shower rain", "Rain", "shower rain" },
                    { 201, "thunderstorm with rain", "Thunderstorm", "thunderstorm with rain" },
                    { 202, "thunderstorm with heavy rain", "Thunderstorm", "thunderstorm with heavy rain" },
                    { 210, "light thunderstorm", "Thunderstorm", "light thunderstorm" },
                    { 211, "thunderstorm", "Thunderstorm", "thunderstorm" },
                    { 212, "heavy thunderstorm", "Thunderstorm", "heavy thunderstorm" },
                    { 221, "ragged thunderstorm", "Thunderstorm", "ragged thunderstorm" },
                    { 230, "thunderstorm with light drizzle", "Thunderstorm", "thunderstorm with light drizzle" },
                    { 231, "thunderstorm with drizzle", "Thunderstorm", "thunderstorm with drizzle" },
                    { 232, "thunderstorm with heavy drizzle", "Thunderstorm", "thunderstorm with heavy drizzle" },
                    { 300, "light intensity drizzle", "Drizzle", "light intensity drizzle" },
                    { 301, "drizzle", "Drizzle", "drizzle" },
                    { 302, "heavy intensity drizzle", "Drizzle", "heavy intensity drizzle" },
                    { 310, "light intensity drizzle rain", "Drizzle", "light intensity drizzle rain" },
                    { 311, "drizzle rain", "Drizzle", "drizzle rain" },
                    { 312, "heavy intensity drizzle rain", "Drizzle", "heavy intensity drizzle rain" },
                    { 313, "shower rain and drizzle", "Drizzle", "shower rain and drizzle" },
                    { 500, "light rain", "Rain", "light rain" },
                    { 501, "moderate rain", "Rain", "moderate rain" },
                    { 502, "heavy intensity rain", "Rain", "heavy intensity rain" },
                    { 503, "very heavy rain", "Rain", "very heavy rain" },
                    { 504, "extreme rain", "Rain", "extreme rain" },
                    { 511, "freezing rain", "Rain", "freezing rain" },
                    { 520, "light intensity shower rain", "Rain", "light intensity shower rain" },
                    { 803, "broken clouds", "Clouds", "broken clouds" },
                    { 804, "overcast clouds", "Clouds", "overcast clouds" }
                });
        }
    }
}
