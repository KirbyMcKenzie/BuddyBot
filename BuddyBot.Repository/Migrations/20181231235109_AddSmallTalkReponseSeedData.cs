using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuddyBot.Repository.Migrations
{
    public partial class AddSmallTalkReponseSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SmallTalkResponse",
                columns: new[] { "Id", "IntentGroup", "IntentName", "IntentResponse" },
                values: new object[] { new Guid("334416d4-b56a-47ad-bf2a-84c02f617509"), "Greeting", "Greeting.HowAreYou", "I'm good, how are you?" });

            migrationBuilder.InsertData(
                table: "SmallTalkResponse",
                columns: new[] { "Id", "IntentGroup", "IntentName", "IntentResponse" },
                values: new object[] { new Guid("6548509f-303f-4ecd-9e99-98fcd2a6d1c4"), "Greeting", "Greeting.HowAreYou", "I'm good thanks 😀" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("334416d4-b56a-47ad-bf2a-84c02f617509"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("6548509f-303f-4ecd-9e99-98fcd2a6d1c4"));
        }
    }
}
