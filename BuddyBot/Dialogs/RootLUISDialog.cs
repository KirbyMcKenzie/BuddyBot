using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using BuddyBot.Services;
using BuddyBot.Dialogs.Interfaces;
using BuddyBot.Helpers;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Internals.Fibers;
using static System.Threading.Thread;
using Pause = BuddyBot.Models.ConversationPauseConstants;


namespace BuddyBot.Dialogs
{
    [Serializable]
    public class RootLuisDialog : LuisDialog<object>
    {
        private readonly IDialogBuilder _dialogBuilder;
        private readonly IConversationService _conversationService;
        private readonly IHeadTailsService _headTailsService;
        private readonly IJokeService _jokeService;

        public RootLuisDialog(
            IDialogBuilder dialogBuilder, 
            IConversationService conversationService,
            IHeadTailsService headTailsService,
            IJokeService jokeService) 
            : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["luis:ModelId"],
            ConfigurationManager.AppSettings["luis:SubscriptionId"])))
        {
            SetField.NotNull(out _dialogBuilder, nameof(dialogBuilder), dialogBuilder);
            SetField.NotNull(out _conversationService, nameof(conversationService), conversationService);
            SetField.NotNull(out _headTailsService, nameof(headTailsService), headTailsService);
            SetField.NotNull(out _jokeService, nameof(jokeService), jokeService);
        }

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I'm sorry, I don't know what you mean. " +
                                    "You can type 'help' at anytime to get a list of things I can do");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Bot.Abuse")]
        public async Task BotAbuse(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I'm sorry, I'm still learning 😖");

            context.Wait(MessageReceived);
        }

        // TODO - refine to different types of praise sentiment
        [LuisIntent("Bot.Praise")]
        public async Task Appreciation(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(await _conversationService.GetPoliteExpression());

            context.Wait(MessageReceived);
        }

        // TODO - refine to different types of language sentiment
        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(await _conversationService.GetGreeting());

            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting.HowsItPrompt")]
        public async Task GreetingHowsItPrompt(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(await _conversationService.GetHowsItPrompt());

            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting.HowsItResult.Bad")]
        public async Task GreetingHowsItResultBad(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(await _conversationService.GetHowsItResultBad());

            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting.HowsItResult.Good")]
        public async Task GreetingHowsItResultGood(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(await _conversationService.GetHowsItResultGood());

            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting.HowsItResult.Neutral")]
        public async Task GreetingHowsItResultNeutral(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("How can I help today?");

            context.Wait(MessageReceived);
        }

        

        [LuisIntent("GetStarted")]
        public async Task GetStarted(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hey I'm BuddyBot! 🤖");

            IMessageActivity reply = context.MakeMessage();

            reply.Text = "I'm here to help you with whatever you need. " +
                         "However, I'm still learning so be patient! " +
                         "Heres some things I can help you with now. 😀";

            reply.SuggestedActions = new SuggestedActions
            {
                Actions = new List<CardAction>()
                {
                    new CardAction(){ Title = "Generate Random Number", Type=ActionTypes.ImBack, Value="Generate Random Number" },
                    new CardAction(){ Title = "Tell a joke", Type=ActionTypes.ImBack, Value="Tell a joke" },
                    new CardAction(){ Title = "Flip a coin", Type=ActionTypes.ImBack, Value="Flip a coin" },
                }
            };

            await context.PostAsync(reply);

            context.Wait(MessageReceived);
        }

        [LuisIntent("Help")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            IMessageActivity reply = context.MakeMessage();

            reply.Text = "Here's a few suggestions of things I can do right now. I'm trying my best to learn new things 😀";

            reply.SuggestedActions = new SuggestedActions
            {
                Actions = new List<CardAction>()
                {
                    new CardAction(){ Title = "Generate a random number", Type=ActionTypes.ImBack, Value="Generate a random number" },
                    new CardAction(){ Title = "Tell a joke", Type=ActionTypes.ImBack, Value="Tell a joke" },
                    new CardAction(){ Title = "Flip a coin", Type=ActionTypes.ImBack, Value="Flip a coin" },
                }
            };

            await context.PostAsync(reply);

            context.Wait(MessageReceived);

        }

        [LuisIntent("Random.HeadsTails")]
        public async Task HeadsTails(IDialogContext context, LuisResult result)
        {
            //TODO - remove dependency 
            IHeadTailsService headTails = new HeadTailsService();

            //TODO - replace with different responses each time
            //TODO - move to seperate dialog
            await context.PostAsync("Flipping a coin.. 🤞");

            Sleep(Pause.ShortPause);
            await context.PostAsync("The result is...");
            Sleep(Pause.ShortMediumPause);

            
            await context.PostAsync(await headTails.GetRandomHeadsTails());

            context.Wait(MessageReceived);
        }

        [LuisIntent("Random.Joke")]
        public async Task Joke(IDialogContext context, LuisResult result)
        {
            //TODO - remove dependency
            IJokeService joke = new JokeService();

            await context.PostAsync(await joke.GetRandomJoke());

            context.Wait(MessageReceived);
        }

        [LuisIntent("Random.Number")]
        public async Task RandomNumber(IDialogContext context, LuisResult result)
        {
           //context.Call(new RandomNumberDialog(result.Entities), Resume_AfterRandomNumberDialog);
            context.Call(_dialogBuilder.BuildRandomNumberDialog(GetMessageActivity(context), result.Entities), Resume_AfterRandomNumberDialog);
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
            await context.PostAsync("I'm built using the Microsoft Bot Framework.");
        }

        [LuisIntent("Miscellaneous.QueryName")]
        public async Task QueryName(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("My name is BuddyBot.");
        }

        [LuisIntent("Miscellaneous.ConfirmRobot")]
        public async Task ConfirmRobot(IDialogContext context, LuisResult result)
        {
            context.Call(_dialogBuilder.BuildConfirmRobotDialog(GetMessageActivity(context)), Resume_ConfirmRobotDialog);
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

        [LuisIntent("Weather.GetForecast")]
        public async Task GetWeatherForecast(IDialogContext context, LuisResult result)
        {
            //context.Call(new GetWeatherForecastDialog(result.Entities), Resume_AfterGetForecastDialog);
            context.Call(_dialogBuilder.BuilGetWeatherForecastDialog(GetMessageActivity(context), result.Entities), Resume_AfterGetForecastDialog);
            await Task.Yield();
        }

        public async Task Resume_AfterGetForecastDialog(IDialogContext context, IAwaitable<string> result)
        {
            var weatherResult = await result;

            await context.PostAsync(weatherResult);

            context.Wait(MessageReceived);
        }

        private static IMessageActivity GetMessageActivity(IDialogContext context)
        {
            return context.Activity.AsMessageActivity();
        }
    }
}