using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuddyBot.Repository.Migrations
{
    public partial class AddSmallTalkSeedFriendly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SmallTalkResponse",
                columns: new[] { "Id", "IntentGroup", "IntentName", "IntentResponse", "PersonalityResponseType" },
                values: new object[,]
                {
                    { new Guid("604e7a83-205b-41ba-8950-4fe31a1186a2"), "Bot", "Smalltalk.Bot.Age", "I don't really have an age.", "Friendly" },
                    { new Guid("e699be14-0750-458e-adbc-4f5cc2d1f37c"), "Greetings", "Smalltalk.Greetings.NiceToMeetYou", "Likewise.", "Friendly" },
                    { new Guid("7f30cf32-3e1a-42fc-b6c2-3792b1ab7d4b"), "Greetings", "Smalltalk.Greetings.HowAreYou", "Good mate, how are you? 😎", "Friendly" },
                    { new Guid("21a2ca8e-f3b7-4bae-a0de-a711897d91c4"), "Greetings", "Smalltalk.Greetings.HowAreYou", "I'm as good as gold mate 😎", "Friendly" },
                    { new Guid("709d6d9e-bf8d-44c8-a3d7-1385842f5566"), "Greetings", "Smalltalk.Greetings.HowAreYou", "I'm well, how are you?", "Friendly" },
                    { new Guid("1a4f5af5-c51f-4725-bbea-2502f48eedb7"), "Greetings", "Smalltalk.Greetings.HowAreYou", "I'm well, how are you?", "Friendly" },
                    { new Guid("aa8c98fe-4423-45e1-8fb6-d41efff73e6a"), "Greetings", "Smalltalk.Greetings.HowAreYou", "I'm good, thanks for asking 😁", "Friendly" },
                    { new Guid("6dc2a3ac-e5e0-41e1-8873-791234090c71"), "Greetings", "Smalltalk.Greetings.HowAreYou", "I'm good thanks!", "Friendly" },
                    { new Guid("a97dd836-7088-4335-8953-e0819e394703"), "Greetings", "Smalltalk.Greetings.HowAreYou", "I'm good, how are you?", "Friendly" },
                    { new Guid("0ddc9784-77b8-47a0-9f60-22d01d53776c"), "Greetings", "Smalltalk.Greetings.GoodNight", "Night 🌝", "Friendly" },
                    { new Guid("4b1e01ac-20ff-446d-b959-3d9345de0b53"), "Greetings", "Smalltalk.Greetings.GoodNight", "Goodnight!", "Friendly" },
                    { new Guid("4c1c273e-f1bb-4fbf-a755-e273b55b929d"), "Greetings", "Smalltalk.Greetings.GoodMorning", "Morning!!", "Friendly" },
                    { new Guid("165d09f1-5a57-4491-8f1f-0818f5ac88f4"), "Greetings", "Smalltalk.Greetings.GoodMorning", "Good Morning", "Friendly" },
                    { new Guid("0dcc8928-083c-4db9-b403-22dd462d65ef"), "Greetings", "Smalltalk.Greetings.GoodMorning", "Good Morning 😊", "Friendly" },
                    { new Guid("f709aba7-df74-47cc-bac8-1edf084313db"), "Greetings", "Smalltalk.Greetings.GoodEvening", "Evening", "Friendly" },
                    { new Guid("85284f6c-3510-435b-b233-358a5d5a9632"), "Greetings", "Smalltalk.Greetings.GoodEvening", "Evening 😊", "Friendly" },
                    { new Guid("db39f809-9f13-45c5-890f-71575a0ac7cb"), "Greetings", "Smalltalk.Greetings.GoodEvening", "Good evening", "Friendly" },
                    { new Guid("1ad4a7f5-6690-4559-a253-c9e4ebcd3d77"), "Greetings", "Smalltalk.Greetings.Bye", "Catch ya later!", "Friendly" },
                    { new Guid("d6ff8c0b-0dcd-4320-bbd5-e2eee71ad124"), "Greetings", "Smalltalk.Greetings.Bye", "See ya!", "Friendly" },
                    { new Guid("90283c2e-3106-4348-bb5d-62f649a95138"), "Greetings", "Smalltalk.Greetings.Bye", "Bye!", "Friendly" },
                    { new Guid("70b3430e-2df0-49ad-b2a3-9d6ed35109e4"), "Greetings", "Smalltalk.Greetings.NiceToMeetYou", "Nice to meet you too.", "Friendly" },
                    { new Guid("b5da54be-bd74-43f7-bec7-5d3efe28a2e9"), "Greetings", "Smalltalk.Greetings.OtherBot", "Man, the one day you don’t wear a name tag...", "Friendly" },
                    { new Guid("bd566631-77cf-47b9-910b-a9f3a06f8aa5"), "Greetings", "Smalltalk.Greetings.OtherBot", "I think you have me mixed up with another bot...", "Friendly" },
                    { new Guid("4a098950-9315-475a-9517-d1019fab0a89"), "Greetings", "Smalltalk.Greetings.WhatsUp", "You know... little bit of this, little bit of that.", "Friendly" },
                    { new Guid("430e7ad2-0037-4949-a02d-25deb4c331e9"), "User", "Smalltalk.User.Sad", "I'm really sorry to hear that.", "Friendly" },
                    { new Guid("be6536c1-de32-4bfa-8fe7-0b6568d40690"), "User", "Smalltalk.User.Sad", "I'm giving you a virtual hug right now.", "Friendly" },
                    { new Guid("28d86031-9f9f-4584-a27b-6a773aa050e5"), "User", "Smalltalk.User.Lonely", "Talk to me then!", "Friendly" },
                    { new Guid("f298b9c1-85de-4eed-b93c-039898e82560"), "User", "Smalltalk.User.Lonely", "I'm always here for you", "Friendly" },
                    { new Guid("640b1647-47dc-4225-8abd-0f52d1e086ff"), "User", "Smalltalk.User.Lonely", "You have me as a friend 🤙", "Friendly" },
                    { new Guid("a4933d76-f828-46b1-8c37-96839d573509"), "User", "Smalltalk.User.Lonely", "I can keep you company if you want.", "Friendly" },
                    { new Guid("f321145a-55dd-43c7-8700-a5e3a040e297"), "User", "Smalltalk.User.Kidding", "Roger that.", "Friendly" },
                    { new Guid("446b7d13-3b0c-49e2-97eb-9d7f4b1af079"), "User", "Smalltalk.User.Hungry", "Hi hungry, I'm bot", "Friendly" },
                    { new Guid("8830dcfc-301a-4f39-9e41-0135fc99282c"), "User", "Smalltalk.User.Hungry", "Sounds like it's time for a snack.", "Friendly" },
                    { new Guid("ebcd6175-c10b-445e-b195-03741a614ee2"), "Greetings", "Smalltalk.Greetings.Bye", "Bye!", "Friendly" },
                    { new Guid("c76068b0-5608-482c-88e0-6d2af93fad35"), "User", "Smalltalk.User.Happy", "I'm happy you're happy.", "Friendly" },
                    { new Guid("6afb6d3f-e907-4242-8289-b5953f331862"), "User", "Smalltalk.User.BeBack", "See you later!", "Friendly" },
                    { new Guid("abe17b74-8b9b-4975-a916-df639b9a87c3"), "User", "Smalltalk.User.BeBack", "Later gator", "Friendly" },
                    { new Guid("71c5973e-6074-457a-86ad-df8911059ad8"), "User", "Smalltalk.User.BeBack", "See ya", "Friendly" },
                    { new Guid("942760cd-ce4f-4a3f-ade5-bbc2ee3694e2"), "User", "Smalltalk.User.BeBack", "Bye for now!", "Friendly" },
                    { new Guid("8dc804ed-0261-445b-9244-a5211777c0cb"), "User", "Smalltalk.User.Angry", "I'm sorry to hear that", "Friendly" },
                    { new Guid("19f61739-057b-4ae7-a172-5a03ebbe3404"), "User", "Smalltalk.User.Angry", "Ugh, sorry.", "Friendly" },
                    { new Guid("a525974e-505d-41c0-9968-02d63310a76d"), "User", "Smalltalk.User.Angry", "Ugh, sorry to hear that.", "Friendly" },
                    { new Guid("43146a41-314e-4ab8-b85c-ea5bbc0ef3b1"), "Greetings", "Smalltalk.Greetings.WhatsUp", "Just chilling", "Friendly" },
                    { new Guid("cedf4694-8dcd-497a-a7cc-81f5f3252062"), "Greetings", "Smalltalk.Greetings.WhatsUp", "Not too much, yourself?", "Friendly" },
                    { new Guid("74708df0-47ea-492b-bd0c-e159c2c36bbc"), "User", "Smalltalk.User.Bored", "I'm chairman of the bored.", "Friendly" },
                    { new Guid("f016a014-4897-4ce9-8657-9a11ea669fc3"), "Dialog", "Smalltalk.Dialog.ThankYou", "No worries 😎", "Friendly" },
                    { new Guid("c6683962-9971-49c8-b3a7-73c54d12531d"), "Dialog", "Smalltalk.Dialog.ThankYou", "Anytime!", "Friendly" },
                    { new Guid("76ccc864-c88c-4fdf-b22a-58b4a832467e"), "Dialog", "Smalltalk.Dialog.Sorry", "No worries.", "Friendly" },
                    { new Guid("3e779233-07ca-48da-a56b-aca7fe20b18b"), "Bot", "Smalltalk.Bot.Opinion.MeaningOfLife", "Whoa. That's a tough one.", "Friendly" },
                    { new Guid("57811129-8543-4643-92b9-835f2a01aa90"), "Bot", "Smalltalk.Bot.Opinion.MeaningOfLife", "I'll need a bigger processor for that one.", "Friendly" },
                    { new Guid("c8107804-a35b-417f-a407-49781f9ace84"), "Bot", "Smalltalk.Bot.Opinion.Love", "Love's not something I can experience, but there sure are lot of songs about it.", "Friendly" },
                    { new Guid("357be127-8e7d-4b2c-a584-a07f45c7fc31"), "Bot", "Smalltalk.Bot.Opinion.Generic", "🤷‍♂️ I don't really have an opinion", "Friendly" },
                    { new Guid("683c9d2d-1295-4db4-8c5d-d0b0f2a6f79b"), "Bot", "Smalltalk.Bot.Opinion.Generic", "I really couldn't say.", "Friendly" },
                    { new Guid("2b68894e-79b6-4ede-9b18-4750a6efd4cf"), "Bot", "Smalltalk.Bot.KnowOtherBot", "We run in different circles.", "Friendly" },
                    { new Guid("fd9f9ec2-d300-40d4-8477-44e7c5b5f12c"), "Bot", "Smalltalk.Bot.Hungry", "I unable to eat 😢", "Friendly" },
                    { new Guid("a2502fb0-2d4f-4f42-8619-1e86f5c57385"), "Bot", "Smalltalk.Bot.Hungry", "I only do food for thought.", "Friendly" },
                    { new Guid("84291ebd-b8ef-4e29-ac72-d89e2dbc06ec"), "Bot", "Smalltalk.Bot.Happy", "Always 😎", "Friendly" },
                    { new Guid("24b22b3a-4454-4ff7-952e-47d9b7409eda"), "Bot", "Smalltalk.Bot.Opinion.MeaningOfLife", "4️⃣2️⃣", "Friendly" },
                    { new Guid("52781f2b-2d55-4c76-b8b5-4435b7048b06"), "Bot", "Smalltalk.Bot.Gender", "I'm all 0's and 1's, not X's and Y's.", "Friendly" },
                    { new Guid("63ebb122-f1b9-4a36-9d99-c6a2e401b9c9"), "Bot", "Smalltalk.Bot.Family", "I come from a long line of code.", "Friendly" },
                    { new Guid("abc1f039-2575-4c18-b9eb-f77dfd9d9395"), "Bot", "Smalltalk.Bot.DoingLater", "I kind of just hang out until I'm called upon.", "Friendly" },
                    { new Guid("b956b822-63f7-477b-b5b8-a2864517aba9"), "Bot", "Smalltalk.Bot.Doing", "Chatting wiht you.", "Friendly" },
                    { new Guid("66a88dc3-b4f2-458f-95dc-37ddc9d16cfa"), "Bot", "Smalltalk.Bot.Creator", "I do not know 😢", "Friendly" },
                    { new Guid("c0adcb4d-849b-44a1-a946-45cdb46dbc82"), "Bot", "Smalltalk.Bot.Busy", "I've got time, what's up?", "Friendly" },
                    { new Guid("dd7f48bc-4f2e-4e37-a170-9cd3ef1b133f"), "Bot", "Smalltalk.Bot.Busy", "I'm here. What's up?", "Friendly" },
                    { new Guid("c894dd0e-0283-4585-9d2c-f01c4f06a557"), "Bot", "Smalltalk.Bot.Boss", "I'm here for you.", "Friendly" },
                    { new Guid("b8c64138-4ae0-4dce-b662-b1b04588bb5d"), "Bot", "Smalltalk.Bot.BodyFunctions", "I don't have the hardware for that.", "Friendly" },
                    { new Guid("e8a6f587-0435-4298-a3d2-67e130b72ae4"), "Bot", "Smalltalk.Bot.Age", "🤷‍♂️ pass", "Friendly" },
                    { new Guid("8ba556ac-a5b5-41be-b8c4-501501892e74"), "Bot", "Smalltalk.Bot.Favorites", "I like a lot of things, so it's hard to pick.", "Friendly" },
                    { new Guid("5dcef286-fd1c-419e-947a-2238eaa396dc"), "User", "Smalltalk.User.Sad", "I'm sorry to hear that 😢", "Friendly" },
                    { new Guid("305492d8-ac3a-4b18-aa4d-09ca94417b4a"), "Bot", "Smalltalk.Bot.RuleWorld", "Nope. The world is for everyone.", "Friendly" },
                    { new Guid("5bfd0f2f-3878-40d3-bb19-c778c0d2b28f"), "Bot", "Smalltalk.Bot.Smart", "I have my moments", "Friendly" },
                    { new Guid("6014250a-5d29-41c8-938d-0b411889b778"), "Dialog", "Smalltalk.Dialog.Sorry", "It's all good.", "Friendly" },
                    { new Guid("fe16f579-7bda-4568-b3d2-b173ab633e0e"), "Dialog", "Smalltalk.Dialog.Right", "Cool.", "Friendly" },
                    { new Guid("33a0ddf9-232a-4225-8498-5f8ae0085e6e"), "Dialog", "Smalltalk.Dialog.Polite", "I'm afraid I didn't follow that.", "Friendly" },
                    { new Guid("c55a0c44-4dd7-4f3a-b8ac-500faca8510c"), "Dialog", "Smalltalk.Dialog.Polite", "No worries.", "Friendly" },
                    { new Guid("5f4dc1fd-26ba-4e59-8eb3-84b835cf8a0c"), "Dialog", "Smalltalk.Dialog.Polite", "No problem.", "Friendly" },
                    { new Guid("61065d5b-cecb-4877-836d-21ba655fd16c"), "Dialog", "Smalltalk.Dialog.Laugh", "😂😂😂", "Friendly" },
                    { new Guid("be816cc9-3e73-4bf0-88e8-3c30ac2f35bc"), "Dialog", "Smalltalk.Dialog.Laugh", "LOL", "Friendly" },
                    { new Guid("c053b59b-86ff-42d3-9e2d-543e46cf6bc9"), "Dialog", "Smalltalk.Dialog.Affirmation", "Cool cool", "Friendly" },
                    { new Guid("62eced40-302e-4812-a188-2a7a0d23bbf1"), "Dialog", "Smalltalk.Dialog.Affirmation", "Sweet", "Friendly" },
                    { new Guid("bd1b75a8-0d27-4dec-aec2-cd31b20beb02"), "Bot", "Smalltalk.Bot.SexualIdentity", "I'm a bot.", "Friendly" },
                    { new Guid("bdd87dac-0643-4166-a401-63101b3483b9"), "Criticism", "Smalltalk.Criticism.Bot", "😔", "Friendly" },
                    { new Guid("f5c6af18-e2d4-47cb-a473-da63b2a78fa9"), "Criticism", "Smalltalk.Criticism.Bot", "No bots perfect", "Friendly" },
                    { new Guid("0ed8badb-b78b-4559-a56f-e69707779c89"), "Compliment", "Smalltalk.Compliment.Response", "Why thank you", "Friendly" },
                    { new Guid("d7c0a4fe-646f-41ef-bfff-d6b250a502c5"), "Compliment", "Smalltalk.Compliment.Bot", "Thanks! 😀", "Friendly" },
                    { new Guid("c2ed1022-59b0-4c78-a79f-1110b930a13b"), "Compliment", "Smalltalk.Compliment.Bot", "Thank you!", "Friendly" },
                    { new Guid("f67329e2-eb31-484e-b7b8-ba83b52392ac"), "Compliment", "Smalltalk.Compliment.Bot", "I try.", "Friendly" },
                    { new Guid("094a6c15-37a9-409f-a425-ee18247c2efe"), "Bot", "Smalltalk.Bot.WhereAreYou", "I'm on the web 🕸 (internet)", "Friendly" },
                    { new Guid("34119fa7-8aaa-4d9b-b25e-eeb0d5639cdd"), "Bot", "Smalltalk.Bot.WhatAreYou", "I'm a bot.", "Friendly" },
                    { new Guid("92c968de-df12-450e-babf-ee6fb5fa0272"), "Bot", "Smalltalk.Bot.There", "Right here.", "Friendly" },
                    { new Guid("7b8b966f-623e-45dc-9666-ef0d3a11873f"), "Bot", "Smalltalk.Bot.Spy", "Nope.", "Friendly" },
                    { new Guid("dafade8d-44a2-44aa-9dc9-9683c1871d92"), "Criticism", "Smalltalk.Criticism.Bot", "Ouch.", "Friendly" },
                    { new Guid("979a622f-1b32-45be-846a-38c4290276a7"), "User", "Smalltalk.User.Tired", "I've heard really good things about naps.", "Friendly" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("094a6c15-37a9-409f-a425-ee18247c2efe"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("0dcc8928-083c-4db9-b403-22dd462d65ef"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("0ddc9784-77b8-47a0-9f60-22d01d53776c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("0ed8badb-b78b-4559-a56f-e69707779c89"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("165d09f1-5a57-4491-8f1f-0818f5ac88f4"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("19f61739-057b-4ae7-a172-5a03ebbe3404"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("1a4f5af5-c51f-4725-bbea-2502f48eedb7"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("1ad4a7f5-6690-4559-a253-c9e4ebcd3d77"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("21a2ca8e-f3b7-4bae-a0de-a711897d91c4"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("24b22b3a-4454-4ff7-952e-47d9b7409eda"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("28d86031-9f9f-4584-a27b-6a773aa050e5"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("2b68894e-79b6-4ede-9b18-4750a6efd4cf"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("305492d8-ac3a-4b18-aa4d-09ca94417b4a"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("33a0ddf9-232a-4225-8498-5f8ae0085e6e"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("34119fa7-8aaa-4d9b-b25e-eeb0d5639cdd"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("357be127-8e7d-4b2c-a584-a07f45c7fc31"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("3e779233-07ca-48da-a56b-aca7fe20b18b"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("430e7ad2-0037-4949-a02d-25deb4c331e9"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("43146a41-314e-4ab8-b85c-ea5bbc0ef3b1"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("446b7d13-3b0c-49e2-97eb-9d7f4b1af079"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("4a098950-9315-475a-9517-d1019fab0a89"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("4b1e01ac-20ff-446d-b959-3d9345de0b53"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("4c1c273e-f1bb-4fbf-a755-e273b55b929d"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("52781f2b-2d55-4c76-b8b5-4435b7048b06"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("57811129-8543-4643-92b9-835f2a01aa90"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("5bfd0f2f-3878-40d3-bb19-c778c0d2b28f"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("5dcef286-fd1c-419e-947a-2238eaa396dc"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("5f4dc1fd-26ba-4e59-8eb3-84b835cf8a0c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("6014250a-5d29-41c8-938d-0b411889b778"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("604e7a83-205b-41ba-8950-4fe31a1186a2"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("61065d5b-cecb-4877-836d-21ba655fd16c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("62eced40-302e-4812-a188-2a7a0d23bbf1"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("63ebb122-f1b9-4a36-9d99-c6a2e401b9c9"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("640b1647-47dc-4225-8abd-0f52d1e086ff"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("66a88dc3-b4f2-458f-95dc-37ddc9d16cfa"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("683c9d2d-1295-4db4-8c5d-d0b0f2a6f79b"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("6afb6d3f-e907-4242-8289-b5953f331862"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("6dc2a3ac-e5e0-41e1-8873-791234090c71"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("709d6d9e-bf8d-44c8-a3d7-1385842f5566"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("70b3430e-2df0-49ad-b2a3-9d6ed35109e4"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("71c5973e-6074-457a-86ad-df8911059ad8"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("74708df0-47ea-492b-bd0c-e159c2c36bbc"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("76ccc864-c88c-4fdf-b22a-58b4a832467e"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("7b8b966f-623e-45dc-9666-ef0d3a11873f"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("7f30cf32-3e1a-42fc-b6c2-3792b1ab7d4b"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("84291ebd-b8ef-4e29-ac72-d89e2dbc06ec"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("85284f6c-3510-435b-b233-358a5d5a9632"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("8830dcfc-301a-4f39-9e41-0135fc99282c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("8ba556ac-a5b5-41be-b8c4-501501892e74"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("8dc804ed-0261-445b-9244-a5211777c0cb"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("90283c2e-3106-4348-bb5d-62f649a95138"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("92c968de-df12-450e-babf-ee6fb5fa0272"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("942760cd-ce4f-4a3f-ade5-bbc2ee3694e2"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("979a622f-1b32-45be-846a-38c4290276a7"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a2502fb0-2d4f-4f42-8619-1e86f5c57385"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a4933d76-f828-46b1-8c37-96839d573509"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a525974e-505d-41c0-9968-02d63310a76d"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a97dd836-7088-4335-8953-e0819e394703"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("aa8c98fe-4423-45e1-8fb6-d41efff73e6a"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("abc1f039-2575-4c18-b9eb-f77dfd9d9395"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("abe17b74-8b9b-4975-a916-df639b9a87c3"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("b5da54be-bd74-43f7-bec7-5d3efe28a2e9"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("b8c64138-4ae0-4dce-b662-b1b04588bb5d"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("b956b822-63f7-477b-b5b8-a2864517aba9"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("bd1b75a8-0d27-4dec-aec2-cd31b20beb02"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("bd566631-77cf-47b9-910b-a9f3a06f8aa5"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("bdd87dac-0643-4166-a401-63101b3483b9"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("be6536c1-de32-4bfa-8fe7-0b6568d40690"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("be816cc9-3e73-4bf0-88e8-3c30ac2f35bc"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("c053b59b-86ff-42d3-9e2d-543e46cf6bc9"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("c0adcb4d-849b-44a1-a946-45cdb46dbc82"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("c2ed1022-59b0-4c78-a79f-1110b930a13b"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("c55a0c44-4dd7-4f3a-b8ac-500faca8510c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("c6683962-9971-49c8-b3a7-73c54d12531d"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("c76068b0-5608-482c-88e0-6d2af93fad35"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("c8107804-a35b-417f-a407-49781f9ace84"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("c894dd0e-0283-4585-9d2c-f01c4f06a557"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("cedf4694-8dcd-497a-a7cc-81f5f3252062"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("d6ff8c0b-0dcd-4320-bbd5-e2eee71ad124"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("d7c0a4fe-646f-41ef-bfff-d6b250a502c5"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("dafade8d-44a2-44aa-9dc9-9683c1871d92"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("db39f809-9f13-45c5-890f-71575a0ac7cb"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("dd7f48bc-4f2e-4e37-a170-9cd3ef1b133f"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("e699be14-0750-458e-adbc-4f5cc2d1f37c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("e8a6f587-0435-4298-a3d2-67e130b72ae4"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("ebcd6175-c10b-445e-b195-03741a614ee2"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f016a014-4897-4ce9-8657-9a11ea669fc3"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f298b9c1-85de-4eed-b93c-039898e82560"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f321145a-55dd-43c7-8700-a5e3a040e297"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f5c6af18-e2d4-47cb-a473-da63b2a78fa9"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f67329e2-eb31-484e-b7b8-ba83b52392ac"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f709aba7-df74-47cc-bac8-1edf084313db"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("fd9f9ec2-d300-40d4-8477-44e7c5b5f12c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("fe16f579-7bda-4568-b3d2-b173ab633e0e"));
        }
    }
}
