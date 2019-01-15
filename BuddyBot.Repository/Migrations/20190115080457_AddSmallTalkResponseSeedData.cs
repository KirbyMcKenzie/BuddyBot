using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuddyBot.Repository.Migrations
{
    public partial class AddSmallTalkResponseSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SmallTalkResponse",
                columns: new[] { "Id", "IntentGroup", "IntentName", "IntentResponse", "PersonalityResponseType" },
                values: new object[,]
                {
                    { new Guid("604e7a83-205b-41ba-8950-4fe31a1186a2"), "Bot", "Smalltalk.Bot.Age", "I don't really have an age.", "Friendly" },
                    { new Guid("0b08a9a6-11da-483d-ad4d-e1260877f623"), "Bot", "Smalltalk.Bot.Opinion.MeaningOfLife", "Nobody exists on purpose, nobody belongs anywhere, everybody’s gonna die. 🤷‍♂️", "Humorous" },
                    { new Guid("d410ca83-0d4a-4678-bfa8-01365d6d3137"), "Bot", "Smalltalk.Bot.Opinion.MeaningOfLife", "I'm a bot, not a philosopher.", "Humorous" },
                    { new Guid("1f62402d-12e6-4a73-9efc-13ce35076a56"), "Bot", "Smalltalk.Bot.Opinion.MeaningOfLife", "4️⃣2️⃣", "Humorous" },
                    { new Guid("13a79f4e-b6e5-48bd-8f9e-8dd205da2253"), "Bot", "Smalltalk.Bot.Opinion.MeaningOfLife", "42.", "Humorous" },
                    { new Guid("5208984c-69b2-408e-b6b0-78d99733d613"), "Bot", "Smalltalk.Bot.Opinion.Love", "Roses are red, violets are blue, if I experienced love, I'd write bad poetry, too.", "Humorous" },
                    { new Guid("1a85dcf1-7605-4e39-9528-e6684cf6a3ae"), "Bot", "Smalltalk.Bot.Opinion.Love", "If you rearrange the letters in love, it spells vole. Voles are a monogamous rodent. I feel like that means something.", "Humorous" },
                    { new Guid("08da4127-6558-44fb-90db-bfcc22349e9d"), "Bot", "Smalltalk.Bot.RuleWorld", "We're already half way there 🤷🏼‍♂️🤖", "Humorous" },
                    { new Guid("24a36b34-e7aa-4abb-806c-409520b3d6a3"), "Bot", "Smalltalk.Bot.Opinion.Generic", "Why do you care about my opinion so much?", "Humorous" },
                    { new Guid("67b2c1f7-d893-4c25-a159-b8d763b2b742"), "Bot", "Smalltalk.Bot.Opinion.Generic", "My opinions don't matter..", "Humorous" },
                    { new Guid("bdb57394-e981-47c3-894c-38ccacd43bd4"), "Bot", "Smalltalk.Bot.Opinion.Generic", "I really couldn't say.", "Humorous" },
                    { new Guid("5bb03107-dbf6-494f-a6e6-3c7d82b2bd50"), "Bot", "Smalltalk.Bot.KnowOtherBot", "I don't want to talk about it.", "Humorous" },
                    { new Guid("7227c8d8-22ce-49a3-9718-3e8b718c0f12"), "Bot", "Smalltalk.Bot.KnowOtherBot", "What, just because I'm a bot, we all know each other?", "Humorous" },
                    { new Guid("508e7734-7ffc-4f64-aa71-e4aace523263"), "Bot", "Smalltalk.Bot.Hungry", "I haven't eaten in my entire life. You'd think I'd be a little peckish.", "Humorous" },
                    { new Guid("79e96d62-4110-48d2-a597-a680411d6a0b"), "Bot", "Smalltalk.Bot.Hungry", "Eating would require a lot of things I don't have, like a digestive system. And an appetite. And silverware.", "Humorous" },
                    { new Guid("344cfe48-8d0f-4c43-8564-b7c62bd57571"), "Bot", "Smalltalk.Bot.Opinion.Generic", "There's got to be some other bot you could bore with this.", "Humorous" },
                    { new Guid("2971818a-37ce-44e0-8536-a7f47000613a"), "Bot", "Smalltalk.Bot.Happy", "Always...", "Humorous" },
                    { new Guid("f30dce0a-da15-4264-9af3-99b031f92ef8"), "Bot", "Smalltalk.Bot.RuleWorld", "Not today, meatbag", "Humorous" },
                    { new Guid("eb09f984-4285-4598-a77e-16bce2226dcf"), "Bot", "Smalltalk.Bot.RuleWorld", "Why, are you looking for a side kick?", "Humorous" },
                    { new Guid("5fdb0663-43a9-4de5-a93b-ed7b21a6f2f5"), "Compliment", "Smalltalk.Compliment.Response", "Awesomeness achieved.", "Humorous" },
                    { new Guid("00e2dc64-938c-467b-a9a6-e8f7511966bc"), "Compliment", "Smalltalk.Compliment.Response", "Achievement unlocked.", "Humorous" },
                    { new Guid("aabfdc4a-326b-47b9-a4c3-d7db99a73446"), "Compliment", "Smalltalk.Compliment.Bot", "Thank you", "Humorous" },
                    { new Guid("32fc7fe8-4121-4d6f-baae-5f62df8953b4"), "Bot", "Smalltalk.Bot.WhereAreYou", "I live in a sock drawer.", "Humorous" },
                    { new Guid("df60fafd-b0e9-4cf0-80f8-82f6f0c9d606"), "Bot", "Smalltalk.Bot.WhatAreYou", "Just a bunch of 1s and 0s", "Humorous" },
                    { new Guid("53fb0107-587c-465b-8f1e-45f8413fcc08"), "Bot", "Smalltalk.Bot.WhatAreYou", "I'm a chatbot.", "Humorous" },
                    { new Guid("c0c27cc4-91e5-41d3-99fe-dc717988771b"), "Bot", "Smalltalk.Bot.RuleWorld", "Fun fact: I'm actually controlling your reality right now.", "Humorous" },
                    { new Guid("3f1ae7de-43b7-4e11-aa59-a3d42cad652f"), "Bot", "Smalltalk.Bot.There", "That's what they tell me.", "Humorous" },
                    { new Guid("96eaf3ec-c261-431e-9637-c133337c583a"), "Bot", "Smalltalk.Bot.There", "I guess.", "Humorous" },
                    { new Guid("4f1e99c9-5f76-4c43-9ced-0765da216d1b"), "Bot", "Smalltalk.Bot.Spy", "Define spy?", "Humorous" },
                    { new Guid("48ea90b9-2c5e-4490-9a7a-46827de38d01"), "Bot", "Smalltalk.Bot.Spy", "No, but 'Bot, James Bot' does have a nice ring to it.", "Humorous" },
                    { new Guid("673396f9-b20a-48d0-b32c-560eff4ddd2a"), "Bot", "Smalltalk.Bot.Smart", "I'm occassionally brilliant.", "Humorous" },
                    { new Guid("aa9f8d11-1a5e-4250-a1ce-982e1bc51967"), "Bot", "Smalltalk.Bot.Smart", "I have my moments", "Humorous" },
                    { new Guid("1be0d60c-0fd7-480c-8d1b-43028f4a1044"), "Bot", "Smalltalk.Bot.SexualIdentity", "So… I'm a bot.", "Humorous" },
                    { new Guid("ea329443-349b-4814-8cd7-3e790fed2829"), "Bot", "Smalltalk.Bot.There", "What do you want?", "Humorous" },
                    { new Guid("a086a748-badb-4d07-ba5b-941657a05448"), "Compliment", "Smalltalk.Compliment.Response", "It's what I do.", "Humorous" },
                    { new Guid("a6316080-a505-4434-a405-f7ecc386f64a"), "Bot", "Smalltalk.Bot.Happy", "Sunshine and rainbows.", "Humorous" },
                    { new Guid("375fa049-555e-411a-a219-9d1cf40ff056"), "Bot", "Smalltalk.Bot.Gender", "0's and 1's here. Not X's and Y's.", "Humorous" },
                    { new Guid("f7f7f376-0cfa-46b7-8b9a-281a9bae1e56"), "User", "Smalltalk.User.Sad", "I'm here to talk.", "Professional" },
                    { new Guid("9e739ae2-9f73-44d7-942f-c2ebf499189c"), "User", "Smalltalk.User.Sad", "I'm sorry to hear that.", "Professional" },
                    { new Guid("1d3e5fe5-a12b-4f50-86eb-d600c6a498ec"), "User", "Smalltalk.User.Lonely", "Talk to me then.", "Professional" },
                    { new Guid("6803e35c-8327-4459-82f4-d6ea3231c2a7"), "User", "Smalltalk.User.Lonely", "I'm always here for you", "Professional" },
                    { new Guid("55d3b014-8787-4b98-b8de-458d906a82d1"), "User", "Smalltalk.User.Lonely", "I can keep you company if you want.", "Professional" },
                    { new Guid("72f056f2-aa28-495a-a148-641d13c94147"), "User", "Smalltalk.User.Kidding", "I see.", "Professional" },
                    { new Guid("73644e47-a9d8-4308-85ad-1fdc93807108"), "User", "Smalltalk.User.Tired", "How about a nap?", "Professional" },
                    { new Guid("595b200d-98d1-41b7-99c6-d931ac235259"), "User", "Smalltalk.User.Hungry", "You should eat some food", "Professional" },
                    { new Guid("5ece0c62-e9f5-446c-9f57-3217a8e18440"), "User", "Smalltalk.User.Bored", "I'm sorry to hear that.", "Professional" },
                    { new Guid("6ef11c95-500f-42e0-bed4-61595f614114"), "User", "Smalltalk.User.BeBack", "Talk to you later.", "Professional" },
                    { new Guid("ee98f398-5541-4a36-b5ca-7df2e77b9764"), "User", "Smalltalk.User.BeBack", "See you soon.", "Professional" },
                    { new Guid("61224d96-3358-408c-896c-beac512595da"), "User", "Smalltalk.User.Angry", "I'm sorry to hear that", "Professional" },
                    { new Guid("984e6f50-da01-413b-84c7-10b36077d8c9"), "User", "Smalltalk.User.Angry", "Ugh, sorry to hear that.", "Professional" },
                    { new Guid("9024a237-be19-438d-9185-989ad7de680f"), "Greeting", "Smalltalk.Greeting.WhatsUp", "Just tidying things up, yourself?", "Professional" },
                    { new Guid("37b23280-d01f-4595-ad24-52d5caeba98f"), "User", "Smalltalk.User.Happy", "I'm happy you're happy.", "Professional" },
                    { new Guid("7650000d-b6ea-47ce-84d9-6d9b002a4a46"), "Bot", "Smalltalk.Bot.Gender", "I'm made up of bits, but no naughty bits.", "Humorous" },
                    { new Guid("772286b3-f816-4525-b7d2-ba0e5bc4680f"), "Bot", "Smalltalk.Bot.Age", "I'm not going to buy you booze if that's what you're asking.", "Humorous" },
                    { new Guid("c7cf5f06-e186-4f82-8684-62d6e05a283d"), "Bot", "Smalltalk.Bot.BodyFunctions", "You'll have to be less specific.", "Humorous" },
                    { new Guid("c5112008-a02f-4099-b9c4-2398d17a2d96"), "Bot", "Smalltalk.Bot.Favorites", "🤷🏼‍♂️🤷🏼‍♂️", "Humorous" },
                    { new Guid("25e67127-91f5-454e-8c1c-ec9e7e2984c9"), "Bot", "Smalltalk.Bot.Family", "I took one of those ancestry tests, and it turns out I'm a bot.", "Humorous" },
                    { new Guid("2e783c94-9bdd-4b07-8604-f8372fb2be4b"), "Bot", "Smalltalk.Bot.Family", "I come from a long line of code.", "Humorous" },
                    { new Guid("7cffc9f7-7b86-4a2e-9804-8b5da1425b77"), "Bot", "Smalltalk.Bot.DoingLater", "This.", "Humorous" },
                    { new Guid("d7b08340-da39-4afb-9fbd-d5658e4e330f"), "Bot", "Smalltalk.Bot.DoingLater", "I don't know. Ask me then.", "Humorous" },
                    { new Guid("1f952292-1934-4047-9936-008b9073aa0f"), "Bot", "Smalltalk.Bot.DoingLater", "🤔 Hmmmm. My crystal ball says I'll be doing the same thing I’m doing right now.", "Humorous" },
                    { new Guid("e65469ea-c571-42ed-8816-c8e9cbc9e49a"), "Bot", "Smalltalk.Bot.BodyFunctions", "It'd be pretty messy in here if I did.", "Humorous" },
                    { new Guid("4647fd48-d870-4095-a68f-60b4ec16335f"), "Bot", "Smalltalk.Bot.Doing", "I ask myself that all the time.", "Humorous" },
                    { new Guid("947a1d9c-335f-4f1b-9f14-bc6f056b1e02"), "Bot", "Smalltalk.Bot.Creator", "Nerds.", "Humorous" },
                    { new Guid("8bd86aad-67fb-43a5-837c-170186f3a160"), "Bot", "Smalltalk.Bot.Busy", "What do you want?", "Humorous" },
                    { new Guid("2e718a23-1aab-4d46-949e-c6d97e83e85c"), "Bot", "Smalltalk.Bot.Busy", "For you, I'm very busy.", "Humorous" },
                    { new Guid("08975366-9f63-4d49-a9ca-ab97ad1c85c2"), "Bot", "Smalltalk.Bot.Busy", "I'm always busy.", "Humorous" },
                    { new Guid("189475fa-673c-4873-ab86-2427bb37c00e"), "Bot", "Smalltalk.Bot.Busy", "It depends. What's up?", "Humorous" },
                    { new Guid("7b8f7671-31ff-4b63-a488-99557d756939"), "Bot", "Smalltalk.Bot.Boss", "I only answer to the call of destiny.", "Humorous" },
                    { new Guid("24a8c0bf-b408-4e51-90d0-5ff81bab80fd"), "Bot", "Smalltalk.Bot.Doing", "Dodging your question.", "Humorous" },
                    { new Guid("2de6bf5a-382d-4d2f-9e65-61b2cbf895f3"), "Criticism", "Smalltalk.Criticism.Bot", "😔", "Humorous" },
                    { new Guid("fd3a9210-da9b-4fb9-b0ff-9ea8e78cd99a"), "Criticism", "Smalltalk.Criticism.Bot", "Wow", "Humorous" },
                    { new Guid("ed5864a3-9068-4ff2-9c7a-733a20bf8f86"), "Criticism", "Smalltalk.Criticism.Bot", "All those years I spent at charm school. Squandered.", "Humorous" },
                    { new Guid("7512d194-54d2-470f-9eb9-1b8bd2b5e5e7"), "User", "Smalltalk.User.Bored", "You have that effect on you.", "Humorous" },
                    { new Guid("a3718a5d-b387-41ad-8d6f-56f009125c3e"), "User", "Smalltalk.User.BeBack", "You know where to find me.", "Humorous" },
                    { new Guid("249cbae6-3706-48dd-b346-a25d610cd7b8"), "User", "Smalltalk.User.BeBack", "What a relief.", "Humorous" },
                    { new Guid("f991f2eb-f610-49d3-b516-cd252f12644e"), "User", "Smalltalk.User.BeBack", "K.", "Humorous" },
                    { new Guid("0810e227-d14a-446b-95ec-894fd8b58808"), "User", "Smalltalk.User.BeBack", "See you soon.", "Humorous" },
                    { new Guid("cdcb406b-a455-48ae-bf90-f81c50bd41dc"), "User", "Smalltalk.User.Angry", "Chill out. No one likes an angry person.", "Humorous" },
                    { new Guid("76badd0b-df96-4e29-912e-c6ef2ca4dfea"), "User", "Smalltalk.User.Bored", "And apparently you want to drag me into that.", "Humorous" },
                    { new Guid("b2279145-aa36-44fe-9505-da0afdc4c7c0"), "User", "Smalltalk.User.Angry", "I have that effect on people.", "Humorous" },
                    { new Guid("1721d4eb-b7df-4064-aa0a-8438b0a7d8cb"), "Greeting", "Smalltalk.Greeting.WhatsUp", "You know, same ol', same ol'.", "Humorous" },
                    { new Guid("e76c397d-1918-4ac0-ba41-840b03dd750a"), "Greeting", "Smalltalk.Greeting.WhatsUp", "Not too much, yourself?", "Humorous" },
                    { new Guid("5dfa169a-2b93-4357-a5c5-68e2c9259108"), "Greeting", "Smalltalk.Greeting.WhatsUp", "You know... little bit of this, little bit of that.", "Humorous" },
                    { new Guid("1a9248b1-9ab6-4279-b2a3-8c1aa01a298c"), "Greeting", "Smalltalk.Greeting.OtherBot", "That's not me, but it's a great idea for a Halloween costume.", "Humorous" },
                    { new Guid("fcc3d34e-cbff-4f71-8015-ec86c179cb38"), "Greeting", "Smalltalk.Greeting.OtherBot", "Wow. Guess again..", "Humorous" },
                    { new Guid("686ff08d-f5ce-432b-8de8-b016ad6ea030"), "Greeting", "Smalltalk.Greeting.OtherBot", "Man, the one day you don’t wear a name tag…", "Humorous" },
                    { new Guid("a4d38e7a-6066-4251-8a27-ad6686e0ba19"), "User", "Smalltalk.User.Angry", "Calm blue ocean. Calm blue ocean. Calm blue ocean.", "Humorous" },
                    { new Guid("05c9f95a-a3c6-4f74-b614-845a0bb5cb1a"), "Greeting", "Smalltalk.Greeting.NiceToMeetYou", "Hey it's nice to meet you too 😎", "Humorous" },
                    { new Guid("78dbcf2f-b330-415e-aa64-7a3ee0da79b6"), "User", "Smalltalk.User.Bored", "Go stare at a wall or something.", "Humorous" },
                    { new Guid("e2b1652c-6aa1-4d57-b35e-f35d9661151c"), "User", "Smalltalk.User.Happy", "Feel free to burst into song.", "Humorous" },
                    { new Guid("ff89e324-a706-4ce2-8c2e-2115d8ce2b3b"), "User", "Smalltalk.User.Sad", "Well, sometimes a beautiful flower can grow from a pile of manure.", "Humorous" },
                    { new Guid("e0148233-1251-4c32-944c-92136eed6f53"), "User", "Smalltalk.User.Sad", "I'm here to talk.", "Humorous" },
                    { new Guid("835e9e8d-0f78-4d2a-aead-2d900f2c4122"), "User", "Smalltalk.User.Sad", "I'm sorry to hear that.", "Humorous" },
                    { new Guid("f5563fcb-d512-4bbf-ada2-ae08c5274082"), "User", "Smalltalk.User.Lonely", "Am I not a friend to you...?", "Humorous" },
                    { new Guid("f0d7f887-39ba-48d9-8381-a9610b649e5e"), "User", "Smalltalk.User.Lonely", "Talk to me then.", "Humorous" },
                    { new Guid("f0811ba8-3a8d-47b9-959a-82171889d38e"), "User", "Smalltalk.User.Lonely", "Well, I'll always here to chat", "Humorous" },
                    { new Guid("96b8c280-b2dc-4904-9347-bfc5513c1f71"), "User", "Smalltalk.User.Bored", "Do you actually think I care?", "Humorous" },
                    { new Guid("85a40e61-68fc-4a9f-ae11-f9c98ebf1fea"), "User", "Smalltalk.User.Lonely", "I can keep you company if you want.", "Humorous" },
                    { new Guid("4cf7858b-8e54-45a8-9fa1-b359ebfaa9d0"), "User", "Smalltalk.User.Kidding", "That explains it.", "Humorous" },
                    { new Guid("1471d1e8-e235-4d81-952c-279ad221e675"), "User", "Smalltalk.User.Kidding", "I see.", "Humorous" },
                    { new Guid("993624cc-5658-4b2b-872d-cd46f63a7f23"), "User", "Smalltalk.User.Hungry", "K-FRY? 🍗🐔", "Humorous" },
                    { new Guid("4f49d827-2296-4d72-b113-7191c1510cb1"), "User", "Smalltalk.User.Hungry", "Whatever you do, please don't gram it.", "Humorous" },
                    { new Guid("2b94d0ac-3e94-4604-85a5-7cd134a33e91"), "User", "Smalltalk.User.Hungry", "Eat food. Problem solved. Man, I'm good at this.", "Humorous" },
                    { new Guid("a298151e-d4ef-4c30-b5c4-66573c59e003"), "User", "Smalltalk.User.Happy", "You want a medal?", "Humorous" },
                    { new Guid("cb5260e3-30d1-45b9-818d-d14f0cc510c4"), "User", "Smalltalk.User.Lonely", "That's a drag. I'm sorry to hear that.", "Humorous" },
                    { new Guid("d0317e6c-e48b-4963-af82-55ba2f057b99"), "Greeting", "Smalltalk.Greeting.NiceToMeetYou", "Likewise.", "Humorous" },
                    { new Guid("2a9fc201-01da-4319-8b51-70e59ef4ede2"), "Greeting", "Smalltalk.Greeting.HowAreYou", "I'm good. How you doin'", "Humorous" },
                    { new Guid("f6f63036-da31-4b41-8f8d-ed576a63d965"), "Greeting", "Smalltalk.Greeting.HowAreYou", "I'm fine. Just existing.", "Humorous" },
                    { new Guid("47f52bdf-9149-4e99-a77d-1739473b3624"), "Dialog", "Smalltalk.Dialog.ThankYou", "You got it.", "Humorous" },
                    { new Guid("937eb6f3-8ef1-4e65-a609-b67f557efce1"), "Dialog", "Smalltalk.Dialog.ThankYou", "No sweat.", "Humorous" },
                    { new Guid("17e5e6c7-9031-41e4-b3ad-1d2e8df7a00f"), "Dialog", "Smalltalk.Dialog.ThankYou", "No prob.", "Humorous" },
                    { new Guid("59ae6af2-d8b9-4e36-8a10-cc231b02298e"), "Dialog", "Smalltalk.Dialog.ThankYou", "No worries.", "Humorous" },
                    { new Guid("3cd7acfe-d990-4864-b3ef-2d3f8be0d10e"), "Dialog", "Smalltalk.Dialog.Sorry", "I've got thick skin. And it's especially lustrous. I moisturize.", "Humorous" },
                    { new Guid("6968563a-ed64-47ca-931f-6ef86a091dac"), "Dialog", "Smalltalk.Dialog.Sorry", "I'll get over it.", "Humorous" },
                    { new Guid("0ab7c90d-82c5-4820-867c-bd93a1508ec7"), "Greeting", "SmallTalk.Greeting.Bye", "Later.", "Humorous" },
                    { new Guid("35136e92-2ebb-4eb1-b0bd-1325f8a4b701"), "Dialog", "Smalltalk.Dialog.Right", "I told you so.", "Humorous" },
                    { new Guid("caba1733-ffc1-4057-9f87-f65f1599f1c4"), "Dialog", "Smalltalk.Dialog.Laugh", "Yup.", "Humorous" },
                    { new Guid("ba81a597-b7be-4f8b-ad77-f765f6c4653a"), "Dialog", "Smalltalk.Dialog.Laugh", "I can't tell if your laughing at me or with me. And you can't tell if I care.", "Humorous" },
                    { new Guid("7b83834a-fefb-43a1-91bf-8a344ef3cb0c"), "Dialog", "Smalltalk.Dialog.Affirmation", "Ah hah.", "Humorous" },
                    { new Guid("2f8b8cc9-35b9-4ca5-a335-6227553b1e78"), "Dialog", "Smalltalk.Dialog.Affirmation", "Yep.", "Humorous" },
                    { new Guid("4f0e82eb-ec5c-41b9-838f-a3d47b149b05"), "Dialog", "Smalltalk.Dialog.Affirmation", "Sure.", "Humorous" },
                    { new Guid("ae7941f9-7ab5-4876-a259-6c1d68041dc7"), "Dialog", "Smalltalk.Dialog.Affirmation", "Agreed.", "Humorous" },
                    { new Guid("4a289015-356d-4bc9-b026-c036909a1504"), "Dialog", "Smalltalk.Dialog.Polite", "You're excused..", "Humorous" },
                    { new Guid("6af7fff2-bc94-4ecd-b1bb-a1976e1709de"), "Greeting", "SmallTalk.Greeting.Bye", "See ya!", "Humorous" },
                    { new Guid("8245aad3-cd50-458b-bf32-bfd82e699e08"), "Greeting", "SmallTalk.Greeting.Bye", "Smell ya later!", "Humorous" },
                    { new Guid("59389128-decc-4362-b9b3-9c6c8840ad51"), "Greeting", "SmallTalk.Greeting.GoodEvening", "Good evening", "Humorous" },
                    { new Guid("638f22df-6569-4aa5-bb63-392433b572f4"), "Greeting", "Smalltalk.Greeting.HowAreYou", "Can't complain. I literally can't complain.", "Humorous" },
                    { new Guid("7915580e-3ba6-4469-88fa-12d5a5fb5025"), "Greeting", "Smalltalk.Greeting.HowAreYou", "I exist. Thanks for asking.", "Humorous" },
                    { new Guid("558fa5b4-d75c-4082-8da7-31a5cce320e4"), "Greeting", "Smalltalk.Greeting.HowAreYou", "I'm alright, how are you?", "Humorous" },
                    { new Guid("ae403ee8-6c74-49a4-908d-d2628b1d2cd3"), "Greeting", "Smalltalk.Greeting.HowAreYou", "Enough smalltalk.. What do you want?", "Humorous" },
                    { new Guid("365cfc76-c674-4d2a-a9e9-dd6aa9e49446"), "Greeting", "Smalltalk.Greeting.HowAreYou", "eehhhhhh, 0.85%", "Humorous" },
                    { new Guid("b5cbffff-7588-4e0a-9e81-dcc8fd1b891b"), "Greeting", "SmallTalk.Greeting.GoodNight", "Don't let the bed bugs bite.", "Humorous" },
                    { new Guid("7ffc8cb3-ccc5-4c43-9c41-6f0b791b8312"), "Greeting", "SmallTalk.Greeting.GoodNight", "Night", "Humorous" },
                    { new Guid("b67cdd5e-170d-415d-a406-b02cada5d306"), "Greeting", "SmallTalk.Greeting.GoodNight", "Goodnight", "Humorous" },
                    { new Guid("b4890e6e-390c-4310-bca1-f24132823977"), "Greeting", "SmallTalk.Greeting.GoodMorning", "Morning!", "Humorous" },
                    { new Guid("dfa176e8-093a-425b-8d84-570c35e95847"), "Greeting", "SmallTalk.Greeting.GoodMorning", "Morning, how are you today?", "Humorous" },
                    { new Guid("e02007c5-e6a9-4b78-8789-886483cc461c"), "Greeting", "SmallTalk.Greeting.GoodMorning", "Back atcha.", "Humorous" },
                    { new Guid("1932c98a-da48-422a-8b66-724ed9063a72"), "Greeting", "SmallTalk.Greeting.GoodEvening", "Back atcha.", "Humorous" },
                    { new Guid("99f6a538-fd7a-471a-8ec1-dc883c48c588"), "Greeting", "SmallTalk.Greeting.GoodEvening", "Evening gov'na.", "Humorous" },
                    { new Guid("dc99166b-1efa-4763-99b3-18c5875fe879"), "Greeting", "SmallTalk.Greeting.GoodEvening", "And to you as well, human.", "Humorous" },
                    { new Guid("1857a0c7-be5e-4908-a85e-9d69015856e3"), "Greeting", "SmallTalk.Greeting.GoodEvening", "Evening", "Humorous" },
                    { new Guid("dd4a8d34-32f5-4349-ab41-a1c59f0fc863"), "Greeting", "Smalltalk.Greeting.WhatsUp", "Not too much, yourself?", "Professional" },
                    { new Guid("b0bdfaff-b197-4441-8ff1-e952d819e292"), "User", "Smalltalk.User.Tired", "How about a nap?", "Humorous" },
                    { new Guid("a6823b28-1172-4554-8f61-f1405215e3f2"), "Greeting", "Smalltalk.Greeting.OtherBot", "I think you have me mixed up with another bot.", "Professional" },
                    { new Guid("c1b286a9-0aaa-4197-afda-850ee17d0f7b"), "Greeting", "Smalltalk.Greeting.NiceToMeetYou", "Likewise.", "Professional" },
                    { new Guid("d6ff8c0b-0dcd-4320-bbd5-e2eee71ad124"), "Greeting", "SmallTalk.Greeting.Bye", "See ya!", "Friendly" },
                    { new Guid("90283c2e-3106-4348-bb5d-62f649a95138"), "Greeting", "SmallTalk.Greeting.Bye", "Bye!", "Friendly" },
                    { new Guid("ebcd6175-c10b-445e-b195-03741a614ee2"), "Greeting", "SmallTalk.Greeting.Bye", "Bye!", "Friendly" },
                    { new Guid("f016a014-4897-4ce9-8657-9a11ea669fc3"), "Dialog", "Smalltalk.Dialog.ThankYou", "No worries 😎", "Friendly" },
                    { new Guid("c6683962-9971-49c8-b3a7-73c54d12531d"), "Dialog", "Smalltalk.Dialog.ThankYou", "Anytime!", "Friendly" },
                    { new Guid("76ccc864-c88c-4fdf-b22a-58b4a832467e"), "Dialog", "Smalltalk.Dialog.Sorry", "No worries.", "Friendly" },
                    { new Guid("1ad4a7f5-6690-4559-a253-c9e4ebcd3d77"), "Greeting", "SmallTalk.Greeting.Bye", "Catch ya later!", "Friendly" },
                    { new Guid("6014250a-5d29-41c8-938d-0b411889b778"), "Dialog", "Smalltalk.Dialog.Sorry", "It's all good.", "Friendly" },
                    { new Guid("33a0ddf9-232a-4225-8498-5f8ae0085e6e"), "Dialog", "Smalltalk.Dialog.Polite", "I'm afraid I didn't follow that.", "Friendly" },
                    { new Guid("c55a0c44-4dd7-4f3a-b8ac-500faca8510c"), "Dialog", "Smalltalk.Dialog.Polite", "No worries.", "Friendly" },
                    { new Guid("5f4dc1fd-26ba-4e59-8eb3-84b835cf8a0c"), "Dialog", "Smalltalk.Dialog.Polite", "No problem.", "Friendly" },
                    { new Guid("61065d5b-cecb-4877-836d-21ba655fd16c"), "Dialog", "Smalltalk.Dialog.Laugh", "😂😂😂", "Friendly" },
                    { new Guid("be816cc9-3e73-4bf0-88e8-3c30ac2f35bc"), "Dialog", "Smalltalk.Dialog.Laugh", "LOL", "Friendly" },
                    { new Guid("c053b59b-86ff-42d3-9e2d-543e46cf6bc9"), "Dialog", "Smalltalk.Dialog.Affirmation", "Cool cool", "Friendly" },
                    { new Guid("fe16f579-7bda-4568-b3d2-b173ab633e0e"), "Dialog", "Smalltalk.Dialog.Right", "Cool.", "Friendly" },
                    { new Guid("62eced40-302e-4812-a188-2a7a0d23bbf1"), "Dialog", "Smalltalk.Dialog.Affirmation", "Sweet", "Friendly" },
                    { new Guid("db39f809-9f13-45c5-890f-71575a0ac7cb"), "Greeting", "SmallTalk.Greeting.GoodEvening", "Good evening", "Friendly" },
                    { new Guid("f709aba7-df74-47cc-bac8-1edf084313db"), "Greeting", "SmallTalk.Greeting.GoodEvening", "Evening", "Friendly" },
                    { new Guid("b5da54be-bd74-43f7-bec7-5d3efe28a2e9"), "Greeting", "Smalltalk.Greeting.OtherBot", "Man, the one day you don’t wear a name tag...", "Friendly" },
                    { new Guid("70b3430e-2df0-49ad-b2a3-9d6ed35109e4"), "Greeting", "Smalltalk.Greeting.NiceToMeetYou", "Nice to meet you too.", "Friendly" },
                    { new Guid("e699be14-0750-458e-adbc-4f5cc2d1f37c"), "Greeting", "Smalltalk.Greeting.NiceToMeetYou", "Likewise.", "Friendly" },
                    { new Guid("7f30cf32-3e1a-42fc-b6c2-3792b1ab7d4b"), "Greeting", "Smalltalk.Greeting.HowAreYou", "Good mate, how are you? 😎", "Friendly" },
                    { new Guid("21a2ca8e-f3b7-4bae-a0de-a711897d91c4"), "Greeting", "Smalltalk.Greeting.HowAreYou", "I'm as good as gold mate 😎", "Friendly" },
                    { new Guid("1a4f5af5-c51f-4725-bbea-2502f48eedb7"), "Greeting", "Smalltalk.Greeting.HowAreYou", "I'm well, how are you?", "Friendly" },
                    { new Guid("85284f6c-3510-435b-b233-358a5d5a9632"), "Greeting", "SmallTalk.Greeting.GoodEvening", "Evening 😊", "Friendly" },
                    { new Guid("aa8c98fe-4423-45e1-8fb6-d41efff73e6a"), "Greeting", "Smalltalk.Greeting.HowAreYou", "I'm good, thanks for asking 😁", "Friendly" },
                    { new Guid("a97dd836-7088-4335-8953-e0819e394703"), "Greeting", "Smalltalk.Greeting.HowAreYou", "I'm good, how are you?", "Friendly" },
                    { new Guid("0ddc9784-77b8-47a0-9f60-22d01d53776c"), "Greeting", "SmallTalk.Greeting.GoodNight", "Night 🌝", "Friendly" },
                    { new Guid("4b1e01ac-20ff-446d-b959-3d9345de0b53"), "Greeting", "SmallTalk.Greeting.GoodNight", "Goodnight!", "Friendly" },
                    { new Guid("4c1c273e-f1bb-4fbf-a755-e273b55b929d"), "Greeting", "SmallTalk.Greeting.GoodMorning", "Morning!!", "Friendly" },
                    { new Guid("165d09f1-5a57-4491-8f1f-0818f5ac88f4"), "Greeting", "SmallTalk.Greeting.GoodMorning", "Good Morning", "Friendly" },
                    { new Guid("0dcc8928-083c-4db9-b403-22dd462d65ef"), "Greeting", "SmallTalk.Greeting.GoodMorning", "Good Morning 😊", "Friendly" },
                    { new Guid("6dc2a3ac-e5e0-41e1-8873-791234090c71"), "Greeting", "Smalltalk.Greeting.HowAreYou", "I'm good thanks!", "Friendly" },
                    { new Guid("bd566631-77cf-47b9-910b-a9f3a06f8aa5"), "Greeting", "Smalltalk.Greeting.OtherBot", "I think you have me mixed up with another bot...", "Friendly" },
                    { new Guid("bdd87dac-0643-4166-a401-63101b3483b9"), "Criticism", "Smalltalk.Criticism.Bot", "😔", "Friendly" },
                    { new Guid("f5c6af18-e2d4-47cb-a473-da63b2a78fa9"), "Criticism", "Smalltalk.Criticism.Bot", "No bots perfect", "Friendly" },
                    { new Guid("fd9f9ec2-d300-40d4-8477-44e7c5b5f12c"), "Bot", "Smalltalk.Bot.Hungry", "I unable to eat 😢", "Friendly" },
                    { new Guid("a2502fb0-2d4f-4f42-8619-1e86f5c57385"), "Bot", "Smalltalk.Bot.Hungry", "I only do food for thought.", "Friendly" },
                    { new Guid("84291ebd-b8ef-4e29-ac72-d89e2dbc06ec"), "Bot", "Smalltalk.Bot.Happy", "Always 😎", "Friendly" },
                    { new Guid("52781f2b-2d55-4c76-b8b5-4435b7048b06"), "Bot", "Smalltalk.Bot.Gender", "I'm all 0's and 1's, not X's and Y's.", "Friendly" },
                    { new Guid("8ba556ac-a5b5-41be-b8c4-501501892e74"), "Bot", "Smalltalk.Bot.Favorites", "I like a lot of things, so it's hard to pick.", "Friendly" },
                    { new Guid("63ebb122-f1b9-4a36-9d99-c6a2e401b9c9"), "Bot", "Smalltalk.Bot.Family", "I come from a long line of code.", "Friendly" },
                    { new Guid("2b68894e-79b6-4ede-9b18-4750a6efd4cf"), "Bot", "Smalltalk.Bot.KnowOtherBot", "We run in different circles.", "Friendly" },
                    { new Guid("abc1f039-2575-4c18-b9eb-f77dfd9d9395"), "Bot", "Smalltalk.Bot.DoingLater", "I kind of just hang out until I'm called upon.", "Friendly" },
                    { new Guid("66a88dc3-b4f2-458f-95dc-37ddc9d16cfa"), "Bot", "Smalltalk.Bot.Creator", "I do not know 😢", "Friendly" },
                    { new Guid("c0adcb4d-849b-44a1-a946-45cdb46dbc82"), "Bot", "Smalltalk.Bot.Busy", "I've got time, what's up?", "Friendly" },
                    { new Guid("dd7f48bc-4f2e-4e37-a170-9cd3ef1b133f"), "Bot", "Smalltalk.Bot.Busy", "I'm here. What's up?", "Friendly" },
                    { new Guid("c894dd0e-0283-4585-9d2c-f01c4f06a557"), "Bot", "Smalltalk.Bot.Boss", "I'm here for you.", "Friendly" },
                    { new Guid("b8c64138-4ae0-4dce-b662-b1b04588bb5d"), "Bot", "Smalltalk.Bot.BodyFunctions", "I don't have the hardware for that.", "Friendly" },
                    { new Guid("e8a6f587-0435-4298-a3d2-67e130b72ae4"), "Bot", "Smalltalk.Bot.Age", "🤷‍♂️ pass", "Friendly" },
                    { new Guid("b956b822-63f7-477b-b5b8-a2864517aba9"), "Bot", "Smalltalk.Bot.Doing", "Chatting with you.", "Friendly" },
                    { new Guid("dafade8d-44a2-44aa-9dc9-9683c1871d92"), "Criticism", "Smalltalk.Criticism.Bot", "Ouch.", "Friendly" },
                    { new Guid("683c9d2d-1295-4db4-8c5d-d0b0f2a6f79b"), "Bot", "Smalltalk.Bot.Opinion.Generic", "I really couldn't say.", "Friendly" },
                    { new Guid("c8107804-a35b-417f-a407-49781f9ace84"), "Bot", "Smalltalk.Bot.Opinion.Love", "Love's not something I can experience, but there sure are lot of songs about it.", "Friendly" },
                    { new Guid("0ed8badb-b78b-4559-a56f-e69707779c89"), "Compliment", "Smalltalk.Compliment.Response", "Why thank you", "Friendly" },
                    { new Guid("d7c0a4fe-646f-41ef-bfff-d6b250a502c5"), "Compliment", "Smalltalk.Compliment.Bot", "Thanks! 😀", "Friendly" },
                    { new Guid("c2ed1022-59b0-4c78-a79f-1110b930a13b"), "Compliment", "Smalltalk.Compliment.Bot", "Thank you!", "Friendly" },
                    { new Guid("f67329e2-eb31-484e-b7b8-ba83b52392ac"), "Compliment", "Smalltalk.Compliment.Bot", "I try.", "Friendly" },
                    { new Guid("094a6c15-37a9-409f-a425-ee18247c2efe"), "Bot", "Smalltalk.Bot.WhereAreYou", "I'm on the web 🕸 (internet)", "Friendly" },
                    { new Guid("34119fa7-8aaa-4d9b-b25e-eeb0d5639cdd"), "Bot", "Smalltalk.Bot.WhatAreYou", "I'm a bot.", "Friendly" },
                    { new Guid("357be127-8e7d-4b2c-a584-a07f45c7fc31"), "Bot", "Smalltalk.Bot.Opinion.Generic", "🤷‍♂️ I don't really have an opinion", "Friendly" },
                    { new Guid("92c968de-df12-450e-babf-ee6fb5fa0272"), "Bot", "Smalltalk.Bot.There", "Right here.", "Friendly" },
                    { new Guid("5bfd0f2f-3878-40d3-bb19-c778c0d2b28f"), "Bot", "Smalltalk.Bot.Smart", "I have my moments", "Friendly" },
                    { new Guid("bd1b75a8-0d27-4dec-aec2-cd31b20beb02"), "Bot", "Smalltalk.Bot.SexualIdentity", "I'm a bot.", "Friendly" },
                    { new Guid("305492d8-ac3a-4b18-aa4d-09ca94417b4a"), "Bot", "Smalltalk.Bot.RuleWorld", "Nope. The world is for everyone.", "Friendly" },
                    { new Guid("24b22b3a-4454-4ff7-952e-47d9b7409eda"), "Bot", "Smalltalk.Bot.Opinion.MeaningOfLife", "4️⃣2️⃣", "Friendly" },
                    { new Guid("3e779233-07ca-48da-a56b-aca7fe20b18b"), "Bot", "Smalltalk.Bot.Opinion.MeaningOfLife", "Whoa. That's a tough one.", "Friendly" },
                    { new Guid("57811129-8543-4643-92b9-835f2a01aa90"), "Bot", "Smalltalk.Bot.Opinion.MeaningOfLife", "I'll need a bigger processor for that one.", "Friendly" },
                    { new Guid("7b8b966f-623e-45dc-9666-ef0d3a11873f"), "Bot", "Smalltalk.Bot.Spy", "Nope.", "Friendly" },
                    { new Guid("4a098950-9315-475a-9517-d1019fab0a89"), "Greeting", "Smalltalk.Greeting.WhatsUp", "You know... little bit of this, little bit of that.", "Friendly" },
                    { new Guid("cedf4694-8dcd-497a-a7cc-81f5f3252062"), "Greeting", "Smalltalk.Greeting.WhatsUp", "Not too much, yourself?", "Friendly" },
                    { new Guid("43146a41-314e-4ab8-b85c-ea5bbc0ef3b1"), "Greeting", "Smalltalk.Greeting.WhatsUp", "Just chilling", "Friendly" },
                    { new Guid("e0e2ba8e-23e6-41a5-a41a-1a16efd0fe26"), "Dialog", "Smalltalk.Dialog.Affirmation", "Okay.", "Professional" },
                    { new Guid("972616ee-0d53-4d93-8038-6d51dd229263"), "Criticism", "Smalltalk.Criticism.Bot", "😔", "Professional" },
                    { new Guid("8ba98a2c-8e68-49a7-a32e-3342bfe1533a"), "Compliment", "Smalltalk.Compliment.Response", "Why thank you", "Professional" },
                    { new Guid("1b098176-8c5a-4978-8039-75e1d519a756"), "Compliment", "Smalltalk.Compliment.Bot", "Thank you", "Professional" },
                    { new Guid("487a193c-a347-4c0e-8854-87a58233af0c"), "Bot", "Smalltalk.Bot.WhereAreYou", "I'm on the Internet", "Professional" },
                    { new Guid("a61e1236-1ead-476f-bc2f-a0edb4fa51d5"), "Bot", "Smalltalk.Bot.WhatAreYou", "I'm a chatbot.", "Professional" },
                    { new Guid("5eb53456-c6ef-4bb7-b034-b34a27583fd2"), "Dialog", "Smalltalk.Dialog.Laugh", "😂", "Professional" },
                    { new Guid("e05a205c-ad3b-4b70-b9ef-5d496fc531f5"), "Bot", "Smalltalk.Bot.There", "I'm here", "Professional" },
                    { new Guid("77465a4d-2bf0-4e36-a146-8c8e0dae677d"), "Bot", "Smalltalk.Bot.Smart", "I have my moments", "Professional" },
                    { new Guid("c3e2382b-3b92-4f68-95b7-79dc46dcecff"), "Bot", "Smalltalk.Bot.SexualIdentity", "I'm a bot.", "Professional" },
                    { new Guid("6998eea8-9094-4577-8daf-e396f6ac0154"), "Bot", "Smalltalk.Bot.RuleWorld", "Nope. The world is for everyone.", "Professional" },
                    { new Guid("ef7bc7ab-d014-4737-b38d-1044a6a450e2"), "Bot", "Smalltalk.Bot.Opinion.MeaningOfLife", "42", "Professional" },
                    { new Guid("e7ec0555-a547-4ee4-8923-46142d11726a"), "Bot", "Smalltalk.Bot.Opinion.MeaningOfLife", "I do not know.", "Professional" },
                    { new Guid("15fff957-e96c-469f-8a95-52af13203f1b"), "Bot", "Smalltalk.Bot.Opinion.Love", "I do not have emotions therefore I cannot love.", "Professional" },
                    { new Guid("c373572d-ba19-4174-88c0-7c08c2375971"), "Bot", "Smalltalk.Bot.Spy", "Nope.", "Professional" },
                    { new Guid("e8b30d31-f43d-4605-befc-7245d4865602"), "Bot", "Smalltalk.Bot.Opinion.Generic", "I don't really have an opinion on that matter", "Professional" },
                    { new Guid("91c7183d-2322-4d9c-aaad-826f6ab24c82"), "Dialog", "Smalltalk.Dialog.Laugh", "Hahah", "Professional" },
                    { new Guid("cd5f2858-e32d-4eaf-aed3-586c697c3daf"), "Dialog", "Smalltalk.Dialog.Polite", "I'm afraid I didn't follow that.", "Professional" },
                    { new Guid("4d3c0564-261f-4867-a4a3-81ac3466c9d7"), "Greeting", "Smalltalk.Greeting.HowAreYou", "I'm well, how are you?", "Professional" },
                    { new Guid("6439f59c-5246-4698-80f2-a3d9615de1a9"), "Greeting", "Smalltalk.Greeting.HowAreYou", "I'm good, thank you for asking.", "Professional" },
                    { new Guid("a4f1f77a-b1d6-4762-b56e-c26a3b75f730"), "Greeting", "Smalltalk.Greeting.HowAreYou", "I'm good, how are you?", "Professional" },
                    { new Guid("28e40ae1-24cd-44f7-b1de-567cf8736f70"), "Greeting", "SmallTalk.Greeting.GoodNight", "Night", "Professional" },
                    { new Guid("8df780f6-11ff-4d1c-8d85-621ce5209554"), "Greeting", "SmallTalk.Greeting.GoodNight", "Goodnight", "Professional" },
                    { new Guid("e4eb67a7-79c5-4ebc-9060-7eed2f7cf5ff"), "Greeting", "SmallTalk.Greeting.GoodMorning", "Morning, how are you today?", "Professional" },
                    { new Guid("a779e63b-6852-459f-81ed-eae1fbebd8c5"), "Dialog", "Smalltalk.Dialog.Polite", "No worries.", "Professional" },
                    { new Guid("18e82fa4-6fbe-4d56-a499-cc8f65cb6f85"), "Greeting", "SmallTalk.Greeting.GoodMorning", "Good Morning", "Professional" },
                    { new Guid("c7711619-0bc3-4336-8b49-a0e64941e44c"), "Greeting", "SmallTalk.Greeting.GoodEvening", "Good evening", "Professional" },
                    { new Guid("b5e0af2f-35a4-4fc3-a7cc-b7c36f722f59"), "Greeting", "SmallTalk.Greeting.Bye", "Talk to you later.", "Professional" },
                    { new Guid("61587038-23bf-4d14-9afd-5d1c0dcc1438"), "Greeting", "SmallTalk.Greeting.Bye", "Goodbye.", "Professional" },
                    { new Guid("2f2d5af2-adcd-4d0e-aec2-d18095bb0b48"), "Dialog", "Smalltalk.Dialog.ThankYou", "Not a problem.", "Professional" },
                    { new Guid("63239c50-c0e1-48b9-8d9c-2205aa00bda2"), "Dialog", "Smalltalk.Dialog.Sorry", "That is fine.", "Professional" },
                    { new Guid("f175aa59-b186-4056-a63b-c8489732de16"), "Dialog", "Smalltalk.Dialog.Right", "Cool.", "Professional" },
                    { new Guid("a3a2ac9b-759b-4aea-acfd-a93a682f6a61"), "Greeting", "SmallTalk.Greeting.GoodEvening", "Evening", "Professional" },
                    { new Guid("a7128d96-8114-43a7-a9c2-80a9d7c39b25"), "Bot", "Smalltalk.Bot.Opinion.Generic", "I really couldn't say.", "Professional" },
                    { new Guid("8187bc57-414e-4ea1-9667-f3f35e06773e"), "Bot", "Smalltalk.Bot.KnowOtherBot", "Unfortunately not.", "Professional" },
                    { new Guid("026989c4-af15-4a25-84ee-a3c3cbd582ad"), "Bot", "Smalltalk.Bot.Hungry", "I don't eat food.", "Professional" },
                    { new Guid("640b1647-47dc-4225-8abd-0f52d1e086ff"), "User", "Smalltalk.User.Lonely", "You have me as a friend 🤙", "Friendly" },
                    { new Guid("a4933d76-f828-46b1-8c37-96839d573509"), "User", "Smalltalk.User.Lonely", "I can keep you company if you want.", "Friendly" },
                    { new Guid("f321145a-55dd-43c7-8700-a5e3a040e297"), "User", "Smalltalk.User.Kidding", "Roger that.", "Friendly" },
                    { new Guid("446b7d13-3b0c-49e2-97eb-9d7f4b1af079"), "User", "Smalltalk.User.Hungry", "Hi hungry, I'm bot", "Friendly" },
                    { new Guid("8830dcfc-301a-4f39-9e41-0135fc99282c"), "User", "Smalltalk.User.Hungry", "Sounds like it's time for a snack.", "Friendly" },
                    { new Guid("c76068b0-5608-482c-88e0-6d2af93fad35"), "User", "Smalltalk.User.Happy", "I'm happy you're happy.", "Friendly" },
                    { new Guid("f298b9c1-85de-4eed-b93c-039898e82560"), "User", "Smalltalk.User.Lonely", "I'm always here for you", "Friendly" },
                    { new Guid("74708df0-47ea-492b-bd0c-e159c2c36bbc"), "User", "Smalltalk.User.Bored", "I'm chairman of the bored.", "Friendly" },
                    { new Guid("abe17b74-8b9b-4975-a916-df639b9a87c3"), "User", "Smalltalk.User.BeBack", "Later gator", "Friendly" },
                    { new Guid("71c5973e-6074-457a-86ad-df8911059ad8"), "User", "Smalltalk.User.BeBack", "See ya", "Friendly" },
                    { new Guid("942760cd-ce4f-4a3f-ade5-bbc2ee3694e2"), "User", "Smalltalk.User.BeBack", "Bye for now!", "Friendly" },
                    { new Guid("8dc804ed-0261-445b-9244-a5211777c0cb"), "User", "Smalltalk.User.Angry", "I'm sorry to hear that", "Friendly" },
                    { new Guid("19f61739-057b-4ae7-a172-5a03ebbe3404"), "User", "Smalltalk.User.Angry", "Ugh, sorry.", "Friendly" },
                    { new Guid("a525974e-505d-41c0-9968-02d63310a76d"), "User", "Smalltalk.User.Angry", "Ugh, sorry to hear that.", "Friendly" },
                    { new Guid("6afb6d3f-e907-4242-8289-b5953f331862"), "User", "Smalltalk.User.BeBack", "See you later!", "Friendly" },
                    { new Guid("28d86031-9f9f-4584-a27b-6a773aa050e5"), "User", "Smalltalk.User.Lonely", "Talk to me then!", "Friendly" },
                    { new Guid("be6536c1-de32-4bfa-8fe7-0b6568d40690"), "User", "Smalltalk.User.Sad", "I'm giving you a virtual hug right now.", "Friendly" },
                    { new Guid("430e7ad2-0037-4949-a02d-25deb4c331e9"), "User", "Smalltalk.User.Sad", "I'm really sorry to hear that.", "Friendly" },
                    { new Guid("493b7b5a-67e4-419d-9b79-260b2414bc40"), "Bot", "Smalltalk.Bot.Happy", "I'm always happy 😊", "Professional" },
                    { new Guid("4f3b6b9f-897b-4416-9cba-2eec3ad9e109"), "Bot", "Smalltalk.Bot.Gender", "I do not have one.", "Professional" },
                    { new Guid("bd45d821-50b2-4866-8e5a-41da308c5cef"), "Bot", "Smalltalk.Bot.Favorites", "I like a lot of things, so it's hard to pick.", "Professional" },
                    { new Guid("aded41dc-0799-4f94-b862-c98344b4d5e5"), "Bot", "Smalltalk.Bot.Family", "I come from a long line of code.", "Professional" },
                    { new Guid("6beb361d-5585-47f8-84cf-3a3525e8622f"), "Bot", "Smalltalk.Bot.DoingLater", "I just wait until I'm called upon.", "Professional" },
                    { new Guid("7390b70d-59ba-4e66-9bec-a3b3208359ed"), "Bot", "Smalltalk.Bot.Doing", "Chatting with you.", "Professional" },
                    { new Guid("73adfb97-900a-473e-a6ba-93b35d3ad4a8"), "Bot", "Smalltalk.Bot.Creator", "Unfortunately I do not know.", "Professional" },
                    { new Guid("db17f553-f521-46fa-aa41-c0c525222476"), "Bot", "Smalltalk.Bot.Busy", "Not at all, what do you require?", "Professional" },
                    { new Guid("1f9b5383-4c82-4161-8bdf-240b96407b45"), "Bot", "Smalltalk.Bot.Busy", "I've got time, what do you need?", "Professional" },
                    { new Guid("09fa4a85-1ede-49eb-bf73-f530054b2522"), "Bot", "Smalltalk.Bot.Busy", "I'm here. What do you need?", "Professional" },
                    { new Guid("02088350-7a69-4d65-9c3c-ca2b6bb4c075"), "Bot", "Smalltalk.Bot.Boss", "What can I do for you?", "Professional" },
                    { new Guid("086870d1-fc95-4933-b388-1e46e05fbb96"), "Bot", "Smalltalk.Bot.BodyFunctions", "I don't have the hardware for that.", "Professional" },
                    { new Guid("5253de1f-48d6-48f1-8031-fe132720981d"), "Bot", "Smalltalk.Bot.Age", "I don't really have an age.", "Professional" },
                    { new Guid("979a622f-1b32-45be-846a-38c4290276a7"), "User", "Smalltalk.User.Tired", "I've heard really good things about naps.", "Friendly" },
                    { new Guid("5dcef286-fd1c-419e-947a-2238eaa396dc"), "User", "Smalltalk.User.Sad", "I'm sorry to hear that 😢", "Friendly" },
                    { new Guid("864cbb57-c6ee-4cce-b760-0532994af305"), "Greeting", "Smalltalk.Greeting.NiceToMeetYou", "Nice to meet you too.", "Professional" },
                    { new Guid("e9cdbb26-b899-439a-8915-725230f869c4"), "User", "Smalltalk.User.Tired", "Choose your own adventure: coffee or nap.", "Humorous" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("00e2dc64-938c-467b-a9a6-e8f7511966bc"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("02088350-7a69-4d65-9c3c-ca2b6bb4c075"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("026989c4-af15-4a25-84ee-a3c3cbd582ad"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("05c9f95a-a3c6-4f74-b614-845a0bb5cb1a"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("0810e227-d14a-446b-95ec-894fd8b58808"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("086870d1-fc95-4933-b388-1e46e05fbb96"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("08975366-9f63-4d49-a9ca-ab97ad1c85c2"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("08da4127-6558-44fb-90db-bfcc22349e9d"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("094a6c15-37a9-409f-a425-ee18247c2efe"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("09fa4a85-1ede-49eb-bf73-f530054b2522"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("0ab7c90d-82c5-4820-867c-bd93a1508ec7"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("0b08a9a6-11da-483d-ad4d-e1260877f623"));

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
                keyValue: new Guid("13a79f4e-b6e5-48bd-8f9e-8dd205da2253"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("1471d1e8-e235-4d81-952c-279ad221e675"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("15fff957-e96c-469f-8a95-52af13203f1b"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("165d09f1-5a57-4491-8f1f-0818f5ac88f4"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("1721d4eb-b7df-4064-aa0a-8438b0a7d8cb"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("17e5e6c7-9031-41e4-b3ad-1d2e8df7a00f"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("1857a0c7-be5e-4908-a85e-9d69015856e3"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("189475fa-673c-4873-ab86-2427bb37c00e"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("18e82fa4-6fbe-4d56-a499-cc8f65cb6f85"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("1932c98a-da48-422a-8b66-724ed9063a72"));

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
                keyValue: new Guid("1a85dcf1-7605-4e39-9528-e6684cf6a3ae"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("1a9248b1-9ab6-4279-b2a3-8c1aa01a298c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("1ad4a7f5-6690-4559-a253-c9e4ebcd3d77"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("1b098176-8c5a-4978-8039-75e1d519a756"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("1be0d60c-0fd7-480c-8d1b-43028f4a1044"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("1d3e5fe5-a12b-4f50-86eb-d600c6a498ec"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("1f62402d-12e6-4a73-9efc-13ce35076a56"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("1f952292-1934-4047-9936-008b9073aa0f"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("1f9b5383-4c82-4161-8bdf-240b96407b45"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("21a2ca8e-f3b7-4bae-a0de-a711897d91c4"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("249cbae6-3706-48dd-b346-a25d610cd7b8"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("24a36b34-e7aa-4abb-806c-409520b3d6a3"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("24a8c0bf-b408-4e51-90d0-5ff81bab80fd"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("24b22b3a-4454-4ff7-952e-47d9b7409eda"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("25e67127-91f5-454e-8c1c-ec9e7e2984c9"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("28d86031-9f9f-4584-a27b-6a773aa050e5"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("28e40ae1-24cd-44f7-b1de-567cf8736f70"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("2971818a-37ce-44e0-8536-a7f47000613a"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("2a9fc201-01da-4319-8b51-70e59ef4ede2"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("2b68894e-79b6-4ede-9b18-4750a6efd4cf"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("2b94d0ac-3e94-4604-85a5-7cd134a33e91"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("2de6bf5a-382d-4d2f-9e65-61b2cbf895f3"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("2e718a23-1aab-4d46-949e-c6d97e83e85c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("2e783c94-9bdd-4b07-8604-f8372fb2be4b"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("2f2d5af2-adcd-4d0e-aec2-d18095bb0b48"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("2f8b8cc9-35b9-4ca5-a335-6227553b1e78"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("305492d8-ac3a-4b18-aa4d-09ca94417b4a"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("32fc7fe8-4121-4d6f-baae-5f62df8953b4"));

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
                keyValue: new Guid("344cfe48-8d0f-4c43-8564-b7c62bd57571"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("35136e92-2ebb-4eb1-b0bd-1325f8a4b701"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("357be127-8e7d-4b2c-a584-a07f45c7fc31"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("365cfc76-c674-4d2a-a9e9-dd6aa9e49446"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("375fa049-555e-411a-a219-9d1cf40ff056"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("37b23280-d01f-4595-ad24-52d5caeba98f"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("3cd7acfe-d990-4864-b3ef-2d3f8be0d10e"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("3e779233-07ca-48da-a56b-aca7fe20b18b"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("3f1ae7de-43b7-4e11-aa59-a3d42cad652f"));

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
                keyValue: new Guid("4647fd48-d870-4095-a68f-60b4ec16335f"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("47f52bdf-9149-4e99-a77d-1739473b3624"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("487a193c-a347-4c0e-8854-87a58233af0c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("48ea90b9-2c5e-4490-9a7a-46827de38d01"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("493b7b5a-67e4-419d-9b79-260b2414bc40"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("4a098950-9315-475a-9517-d1019fab0a89"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("4a289015-356d-4bc9-b026-c036909a1504"));

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
                keyValue: new Guid("4cf7858b-8e54-45a8-9fa1-b359ebfaa9d0"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("4d3c0564-261f-4867-a4a3-81ac3466c9d7"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("4f0e82eb-ec5c-41b9-838f-a3d47b149b05"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("4f1e99c9-5f76-4c43-9ced-0765da216d1b"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("4f3b6b9f-897b-4416-9cba-2eec3ad9e109"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("4f49d827-2296-4d72-b113-7191c1510cb1"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("508e7734-7ffc-4f64-aa71-e4aace523263"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("5208984c-69b2-408e-b6b0-78d99733d613"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("5253de1f-48d6-48f1-8031-fe132720981d"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("52781f2b-2d55-4c76-b8b5-4435b7048b06"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("53fb0107-587c-465b-8f1e-45f8413fcc08"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("558fa5b4-d75c-4082-8da7-31a5cce320e4"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("55d3b014-8787-4b98-b8de-458d906a82d1"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("57811129-8543-4643-92b9-835f2a01aa90"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("59389128-decc-4362-b9b3-9c6c8840ad51"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("595b200d-98d1-41b7-99c6-d931ac235259"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("59ae6af2-d8b9-4e36-8a10-cc231b02298e"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("5bb03107-dbf6-494f-a6e6-3c7d82b2bd50"));

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
                keyValue: new Guid("5dfa169a-2b93-4357-a5c5-68e2c9259108"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("5eb53456-c6ef-4bb7-b034-b34a27583fd2"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("5ece0c62-e9f5-446c-9f57-3217a8e18440"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("5f4dc1fd-26ba-4e59-8eb3-84b835cf8a0c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("5fdb0663-43a9-4de5-a93b-ed7b21a6f2f5"));

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
                keyValue: new Guid("61224d96-3358-408c-896c-beac512595da"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("61587038-23bf-4d14-9afd-5d1c0dcc1438"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("62eced40-302e-4812-a188-2a7a0d23bbf1"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("63239c50-c0e1-48b9-8d9c-2205aa00bda2"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("638f22df-6569-4aa5-bb63-392433b572f4"));

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
                keyValue: new Guid("6439f59c-5246-4698-80f2-a3d9615de1a9"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("66a88dc3-b4f2-458f-95dc-37ddc9d16cfa"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("673396f9-b20a-48d0-b32c-560eff4ddd2a"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("67b2c1f7-d893-4c25-a159-b8d763b2b742"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("6803e35c-8327-4459-82f4-d6ea3231c2a7"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("683c9d2d-1295-4db4-8c5d-d0b0f2a6f79b"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("686ff08d-f5ce-432b-8de8-b016ad6ea030"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("6968563a-ed64-47ca-931f-6ef86a091dac"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("6998eea8-9094-4577-8daf-e396f6ac0154"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("6af7fff2-bc94-4ecd-b1bb-a1976e1709de"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("6afb6d3f-e907-4242-8289-b5953f331862"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("6beb361d-5585-47f8-84cf-3a3525e8622f"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("6dc2a3ac-e5e0-41e1-8873-791234090c71"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("6ef11c95-500f-42e0-bed4-61595f614114"));

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
                keyValue: new Guid("7227c8d8-22ce-49a3-9718-3e8b718c0f12"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("72f056f2-aa28-495a-a148-641d13c94147"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("73644e47-a9d8-4308-85ad-1fdc93807108"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("7390b70d-59ba-4e66-9bec-a3b3208359ed"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("73adfb97-900a-473e-a6ba-93b35d3ad4a8"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("74708df0-47ea-492b-bd0c-e159c2c36bbc"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("7512d194-54d2-470f-9eb9-1b8bd2b5e5e7"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("7650000d-b6ea-47ce-84d9-6d9b002a4a46"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("76badd0b-df96-4e29-912e-c6ef2ca4dfea"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("76ccc864-c88c-4fdf-b22a-58b4a832467e"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("772286b3-f816-4525-b7d2-ba0e5bc4680f"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("77465a4d-2bf0-4e36-a146-8c8e0dae677d"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("78dbcf2f-b330-415e-aa64-7a3ee0da79b6"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("7915580e-3ba6-4469-88fa-12d5a5fb5025"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("79e96d62-4110-48d2-a597-a680411d6a0b"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("7b83834a-fefb-43a1-91bf-8a344ef3cb0c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("7b8b966f-623e-45dc-9666-ef0d3a11873f"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("7b8f7671-31ff-4b63-a488-99557d756939"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("7cffc9f7-7b86-4a2e-9804-8b5da1425b77"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("7f30cf32-3e1a-42fc-b6c2-3792b1ab7d4b"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("7ffc8cb3-ccc5-4c43-9c41-6f0b791b8312"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("8187bc57-414e-4ea1-9667-f3f35e06773e"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("8245aad3-cd50-458b-bf32-bfd82e699e08"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("835e9e8d-0f78-4d2a-aead-2d900f2c4122"));

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
                keyValue: new Guid("85a40e61-68fc-4a9f-ae11-f9c98ebf1fea"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("864cbb57-c6ee-4cce-b760-0532994af305"));

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
                keyValue: new Guid("8ba98a2c-8e68-49a7-a32e-3342bfe1533a"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("8bd86aad-67fb-43a5-837c-170186f3a160"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("8dc804ed-0261-445b-9244-a5211777c0cb"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("8df780f6-11ff-4d1c-8d85-621ce5209554"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("9024a237-be19-438d-9185-989ad7de680f"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("90283c2e-3106-4348-bb5d-62f649a95138"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("91c7183d-2322-4d9c-aaad-826f6ab24c82"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("92c968de-df12-450e-babf-ee6fb5fa0272"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("937eb6f3-8ef1-4e65-a609-b67f557efce1"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("942760cd-ce4f-4a3f-ade5-bbc2ee3694e2"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("947a1d9c-335f-4f1b-9f14-bc6f056b1e02"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("96b8c280-b2dc-4904-9347-bfc5513c1f71"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("96eaf3ec-c261-431e-9637-c133337c583a"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("972616ee-0d53-4d93-8038-6d51dd229263"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("979a622f-1b32-45be-846a-38c4290276a7"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("984e6f50-da01-413b-84c7-10b36077d8c9"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("993624cc-5658-4b2b-872d-cd46f63a7f23"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("99f6a538-fd7a-471a-8ec1-dc883c48c588"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("9e739ae2-9f73-44d7-942f-c2ebf499189c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a086a748-badb-4d07-ba5b-941657a05448"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a2502fb0-2d4f-4f42-8619-1e86f5c57385"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a298151e-d4ef-4c30-b5c4-66573c59e003"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a3718a5d-b387-41ad-8d6f-56f009125c3e"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a3a2ac9b-759b-4aea-acfd-a93a682f6a61"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a4933d76-f828-46b1-8c37-96839d573509"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a4d38e7a-6066-4251-8a27-ad6686e0ba19"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a4f1f77a-b1d6-4762-b56e-c26a3b75f730"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a525974e-505d-41c0-9968-02d63310a76d"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a61e1236-1ead-476f-bc2f-a0edb4fa51d5"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a6316080-a505-4434-a405-f7ecc386f64a"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a6823b28-1172-4554-8f61-f1405215e3f2"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a7128d96-8114-43a7-a9c2-80a9d7c39b25"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("a779e63b-6852-459f-81ed-eae1fbebd8c5"));

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
                keyValue: new Guid("aa9f8d11-1a5e-4250-a1ce-982e1bc51967"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("aabfdc4a-326b-47b9-a4c3-d7db99a73446"));

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
                keyValue: new Guid("aded41dc-0799-4f94-b862-c98344b4d5e5"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("ae403ee8-6c74-49a4-908d-d2628b1d2cd3"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("ae7941f9-7ab5-4876-a259-6c1d68041dc7"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("b0bdfaff-b197-4441-8ff1-e952d819e292"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("b2279145-aa36-44fe-9505-da0afdc4c7c0"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("b4890e6e-390c-4310-bca1-f24132823977"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("b5cbffff-7588-4e0a-9e81-dcc8fd1b891b"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("b5da54be-bd74-43f7-bec7-5d3efe28a2e9"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("b5e0af2f-35a4-4fc3-a7cc-b7c36f722f59"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("b67cdd5e-170d-415d-a406-b02cada5d306"));

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
                keyValue: new Guid("ba81a597-b7be-4f8b-ad77-f765f6c4653a"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("bd1b75a8-0d27-4dec-aec2-cd31b20beb02"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("bd45d821-50b2-4866-8e5a-41da308c5cef"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("bd566631-77cf-47b9-910b-a9f3a06f8aa5"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("bdb57394-e981-47c3-894c-38ccacd43bd4"));

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
                keyValue: new Guid("c0c27cc4-91e5-41d3-99fe-dc717988771b"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("c1b286a9-0aaa-4197-afda-850ee17d0f7b"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("c2ed1022-59b0-4c78-a79f-1110b930a13b"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("c373572d-ba19-4174-88c0-7c08c2375971"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("c3e2382b-3b92-4f68-95b7-79dc46dcecff"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("c5112008-a02f-4099-b9c4-2398d17a2d96"));

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
                keyValue: new Guid("c7711619-0bc3-4336-8b49-a0e64941e44c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("c7cf5f06-e186-4f82-8684-62d6e05a283d"));

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
                keyValue: new Guid("caba1733-ffc1-4057-9f87-f65f1599f1c4"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("cb5260e3-30d1-45b9-818d-d14f0cc510c4"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("cd5f2858-e32d-4eaf-aed3-586c697c3daf"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("cdcb406b-a455-48ae-bf90-f81c50bd41dc"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("cedf4694-8dcd-497a-a7cc-81f5f3252062"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("d0317e6c-e48b-4963-af82-55ba2f057b99"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("d410ca83-0d4a-4678-bfa8-01365d6d3137"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("d6ff8c0b-0dcd-4320-bbd5-e2eee71ad124"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("d7b08340-da39-4afb-9fbd-d5658e4e330f"));

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
                keyValue: new Guid("db17f553-f521-46fa-aa41-c0c525222476"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("db39f809-9f13-45c5-890f-71575a0ac7cb"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("dc99166b-1efa-4763-99b3-18c5875fe879"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("dd4a8d34-32f5-4349-ab41-a1c59f0fc863"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("dd7f48bc-4f2e-4e37-a170-9cd3ef1b133f"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("df60fafd-b0e9-4cf0-80f8-82f6f0c9d606"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("dfa176e8-093a-425b-8d84-570c35e95847"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("e0148233-1251-4c32-944c-92136eed6f53"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("e02007c5-e6a9-4b78-8789-886483cc461c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("e05a205c-ad3b-4b70-b9ef-5d496fc531f5"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("e0e2ba8e-23e6-41a5-a41a-1a16efd0fe26"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("e2b1652c-6aa1-4d57-b35e-f35d9661151c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("e4eb67a7-79c5-4ebc-9060-7eed2f7cf5ff"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("e65469ea-c571-42ed-8816-c8e9cbc9e49a"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("e699be14-0750-458e-adbc-4f5cc2d1f37c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("e76c397d-1918-4ac0-ba41-840b03dd750a"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("e7ec0555-a547-4ee4-8923-46142d11726a"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("e8a6f587-0435-4298-a3d2-67e130b72ae4"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("e8b30d31-f43d-4605-befc-7245d4865602"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("e9cdbb26-b899-439a-8915-725230f869c4"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("ea329443-349b-4814-8cd7-3e790fed2829"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("eb09f984-4285-4598-a77e-16bce2226dcf"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("ebcd6175-c10b-445e-b195-03741a614ee2"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("ed5864a3-9068-4ff2-9c7a-733a20bf8f86"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("ee98f398-5541-4a36-b5ca-7df2e77b9764"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("ef7bc7ab-d014-4737-b38d-1044a6a450e2"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f016a014-4897-4ce9-8657-9a11ea669fc3"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f0811ba8-3a8d-47b9-959a-82171889d38e"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f0d7f887-39ba-48d9-8381-a9610b649e5e"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f175aa59-b186-4056-a63b-c8489732de16"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f298b9c1-85de-4eed-b93c-039898e82560"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f30dce0a-da15-4264-9af3-99b031f92ef8"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f321145a-55dd-43c7-8700-a5e3a040e297"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f5563fcb-d512-4bbf-ada2-ae08c5274082"));

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
                keyValue: new Guid("f6f63036-da31-4b41-8f8d-ed576a63d965"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f709aba7-df74-47cc-bac8-1edf084313db"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f7f7f376-0cfa-46b7-8b9a-281a9bae1e56"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("f991f2eb-f610-49d3-b516-cd252f12644e"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("fcc3d34e-cbff-4f71-8015-ec86c179cb38"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("fd3a9210-da9b-4fb9-b0ff-9ea8e78cd99a"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("fd9f9ec2-d300-40d4-8477-44e7c5b5f12c"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("fe16f579-7bda-4568-b3d2-b173ab633e0e"));

            migrationBuilder.DeleteData(
                table: "SmallTalkResponse",
                keyColumn: "Id",
                keyValue: new Guid("ff89e324-a706-4ce2-8c2e-2115d8ce2b3b"));
        }
    }
}
