using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using BuddyBot.Services;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class RootLuisDialog : LuisDialog<object>
    {
        public RootLuisDialog() : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["luis:ModelId"],
            ConfigurationManager.AppSettings["luis:SubscriptionId"])))
        {
        }

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I'm sorry I don't know what you mean");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Bot.Abuse")]
        public async Task BotAbuse(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I'm sorry, I'm still learning 😖");

            context.Wait(MessageReceived);
        }

        [LuisIntent("Bot.Praise")]
        public async Task Appreciation(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("No worries 😀");

            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hi I'm BuddyBot! 🤖");

            IMessageActivity reply = context.MakeMessage();

            reply.Text = "I'm here to help you with whatever you need. " +
                         "However, I'm still learning so be patient! " +
                         "Heres some things I can help you with now. 😀";

            // TODO - move these to dialog
            reply.SuggestedActions = new SuggestedActions
            {
                Actions = new List<CardAction>()
                {
                    new CardAction(){ Title = "Generate Random Number", Type=ActionTypes.ImBack, Value="Generate Random Number" },
                    new CardAction(){ Title = "Tell me a joke", Type=ActionTypes.ImBack, Value="Tell me a joke" },
                    new CardAction(){ Title = "What's the weather doing?", Type=ActionTypes.ImBack, Value="What's the weather doing?" },
                }
            };

            await context.PostAsync(reply);

            context.Wait(MessageReceived);
        }

        [LuisIntent("Joke")]
        public async Task Joke(IDialogContext context, LuisResult result)
        {
            //TODO - remove dependency
            IJokeService joke = new JokeService();

            await context.PostAsync(await joke.GetRandomJoke());

            context.Wait(MessageReceived);
        }

        [LuisIntent("Query.Weather")]
        public async Task QueryWeather(IDialogContext context, LuisResult result)
        {
            // TODO - Add weather api
            await context.PostAsync("It's pretty cold right now");

            context.Wait(MessageReceived);
        }

        [LuisIntent("Random.Number")]
        public async Task RandomNumber(IDialogContext context, LuisResult result)
        {
            context.Call(new RandomNumberDialog(result.Entities), Resume_AfterRandomNumberDialog);
            await Task.Yield();
        }

        public async Task Resume_AfterRandomNumberDialog(IDialogContext context, IAwaitable<int> result)
        {
            var randomNumber = await result;

            await context.PostAsync($"The result is... {randomNumber}! 🎉🎉");

            context.Wait(MessageReceived);
        }

        [LuisIntent("Miscellaneous.QueryHowDoesItWork")]
        public async Task QueryHowDoesItWork(IDialogContext context, LuisResult result)
        {
            // TODO - Improve answer
            await context.PostAsync("I'm built using the Microsoft bot framework.");
        }

        [LuisIntent("Miscellaneous.QueryName")]
        public async Task QueryName(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("My name is BuddyBot.");
        }

        [LuisIntent("Miscellaneous.ConfirmRobot")]
        public async Task ConfirmRobot(IDialogContext context, LuisResult result)
        {
            context.Call(new ConfirmRobotDialog(), Resume_ConfirmRobotDialog);

            await Task.Yield();
        }

        private async Task Resume_ConfirmRobotDialog(IDialogContext context, IAwaitable<string> result)
        {

            var message = await result;
            await context.PostAsync($"{message}");

            context.Wait(MessageReceived);
        }

        [LuisIntent("Miscellaneous.Creator")]
        public async Task Creator(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("My creator is Kirby McKenzie.");
            await context.PostAsync("You can view his github here: https://github.com/KirbyMcKenzie");
                
        }


        [LuisIntent("Miscellaneous.OriginStory")]
        public async Task OriginStory(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I was born in a Bitcoin mine deep within mainland China.");
        }

        [LuisIntent("Miscellaneous.OpinionOfNotablePerson")]
        public async Task OpinionOfNotablePerson(IDialogContext context, LuisResult result)
        {
            // Todo: Pull entities from Luis
            await context.PostAsync($"I am a bot. My opinion doesn't matter...");
        }
    }
}