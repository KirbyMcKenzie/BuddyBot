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
                values: new object[] { new Guid("5ae55d79-c691-49b9-b738-d03c6ec4126c"), "Greeting", "Smalltalk.Greetings.HowAreYou", "I'm good, how are you?" });

            migrationBuilder.InsertData(
                table: "SmallTalkResponse",
                columns: new[] { "Id", "IntentGroup", "IntentName", "IntentResponse" },
                values: new object[] { new Guid("f76781ad-15bb-45ec-81de-e5febd49f46e"), "Greeting", "Smalltalk.Greetings.HowAreYou", "I'm good thanks 😀" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("5ae55d79-c691-49b9-b738-d03c6ec4126c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f76781ad-15bb-45ec-81de-e5febd49f46e"));
        }
    }
}
