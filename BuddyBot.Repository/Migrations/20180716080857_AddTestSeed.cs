using Microsoft.EntityFrameworkCore.Migrations;

namespace BuddyBot.Repository.Migrations
{
    public partial class AddTestSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WeatherConditionResponse",
                columns: new[] { "Id", "Condition", "Group", "MappedConditionResponse" },
                values: new object[] { 200, "Rain", "Thunda", "Rain " });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WeatherConditionResponse",
                keyColumn: "Id",
                keyValue: 200);
        }
    }
}
