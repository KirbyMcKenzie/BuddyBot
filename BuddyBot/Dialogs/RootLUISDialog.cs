﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
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
using Serilog;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class RootLuisDialog : LuisDialog<object>
    {
        private readonly IDialogBuilder _dialogBuilder;
        private readonly IConversationService _conversationService;
        private readonly IHeadTailsService _headTailsService;
        private readonly IJokeService _jokeService;
        private readonly IBotDataService _botDataService;

        public RootLuisDialog(
            IDialogBuilder dialogBuilder, IConversationService conversationService,
            IHeadTailsService headTailsService, IJokeService jokeService,
            IBotDataService botDataService) : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["luis:ModelId"],
            ConfigurationManager.AppSettings["luis:SubscriptionId"])))
        {
            SetField.NotNull(out _dialogBuilder, nameof(dialogBuilder), dialogBuilder);
            SetField.NotNull(out _conversationService, nameof(conversationService), conversationService);
            SetField.NotNull(out _headTailsService, nameof(headTailsService), headTailsService);
            SetField.NotNull(out _jokeService, nameof(jokeService), jokeService);
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
        }


        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I'm sorry, I don't know what you mean. " +
                                    "You can type 'help' at anytime to get a list of things I can do");
            context.Wait(MessageReceived);
        }


        [LuisIntent("Chit-Chat")]
        public async Task Chitchat(IDialogContext context, LuisResult result)
        {
            await context.Forward(new PersonalityChatDialog(_botDataService, _conversationService, context), Resume_AfterChitchat, new Activity {Text = result.Query},
                CancellationToken.None);

            
        }

        private async Task Resume_AfterChitchat(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            await Task.Yield();
        }


        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            string name =  _botDataService.GetPreferredName(context);

            Log.Information("Greeting method called.");

            await context.PostAsync(await _conversationService.GetGreeting(name));

            Log.Information("Greeting method finished");

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

            context.Call(_dialogBuilder.BuildNameDialog(GetMessageActivity(context), result.Entities), Resume_AfterNameDialog);
            await Task.Yield();
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

            //TODO - replace with different responses each time
            //TODO - move to seperate dialog
            await context.PostAsync("Flipping a coin.. 🤞");

            Sleep(Pause.ShortPause);
            await context.PostAsync("The result is...");
            Sleep(Pause.ShortMediumPause);

            
            await context.PostAsync(await _headTailsService.GetRandomHeadsTails());

            context.Wait(MessageReceived);
        }


        [LuisIntent("Random.Joke")]
        public async Task Joke(IDialogContext context, LuisResult result)
        {

            await context.PostAsync(await _jokeService.GetRandomJoke());

            context.Wait(MessageReceived);
        }


        [LuisIntent("Random.Number")]
        public async Task RandomNumber(IDialogContext context, LuisResult result)
        {
            context.Call(_dialogBuilder.BuildRandomNumberDialog(GetMessageActivity(context), result.Entities), Resume_AfterRandomNumberDialog);
            await Task.Yield();
        }


        public async Task Resume_AfterRandomNumberDialog(IDialogContext context, IAwaitable<int> result)
        {
            var randomNumber = await result;

            await context.PostAsync($"The result is... {randomNumber}! 🎉🎉");

            context.Wait(MessageReceived);
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


        [LuisIntent("User.UpdatePreferredName")]
        public async Task UpdatePreferredName(IDialogContext context, LuisResult result)
        {
            context.Call(_dialogBuilder.BuildNameDialog(GetMessageActivity(context), result.Entities), Resume_AfterNameDialog);
            await Task.Yield();
        }

        private async Task Resume_AfterNameDialog(IDialogContext context, IAwaitable<string> result)
        {

            string name = await result;

            await context.PostAsync($"I've got your name saved as {name}.");

        }

        [LuisIntent("User.UpdatePreferredBotPersona")]
        public async Task UpdatePreferredBotPersona(IDialogContext context, LuisResult result)
        {
            context.Call(_dialogBuilder.BuildBotPersonaDialog(GetMessageActivity(context), result.Entities), Resume_AfterBotPersonaDialog);
            await Task.Yield();
        }

        private async Task Resume_AfterBotPersonaDialog(IDialogContext context, IAwaitable<string> result)
        {

            string persona = await result;

            await context.PostAsync($"Okay, my personality is set to {persona}.");

            context.Wait(MessageReceived);
        }


        [LuisIntent("Weather.GetForecast")]
        public async Task GetWeatherForecast(IDialogContext context, LuisResult result)
        {
            context.Call(_dialogBuilder.BuilGetWeatherForecastDialog(GetMessageActivity(context), result.Entities), Resume_AfterGetForecastDialog);
            await Task.Yield();
        }

        public async Task Resume_AfterGetForecastDialog(IDialogContext context, IAwaitable<string> result)
        {
            var weatherResult = await result;

            await context.PostAsync(weatherResult);

            context.Wait(MessageReceived);
        }


        [LuisIntent("User.UpdatePreferredWeatherLocation")]
        public async Task UpdatePreferredWeatherLocation(IDialogContext context, LuisResult result)
        {
            context.Call(_dialogBuilder.BuildPreferredWeatherLocationDialog(GetMessageActivity(context), result.Entities), Resume_AfterPreferredWeatherLocationDialog);
            await Task.Yield();
        }

        public async Task Resume_AfterPreferredWeatherLocationDialog(IDialogContext context, IAwaitable<string> result)
        {
            string preferredWeatherLocation = await result;

            await context.PostAsync($"Okay, I've got your preferred weather location set as {preferredWeatherLocation}.");

            context.Wait(MessageReceived);
        }

        [LuisIntent("User.DeleteUserData")]
        public async Task DeleteUserData(IDialogContext context, LuisResult result)
        {
            context.Call(_dialogBuilder.BuildDeleteUserDataDialog(GetMessageActivity(context)), Resume_AfterDeleteUserDataDialog);
            await Task.Yield();
        }

        private async Task Resume_AfterDeleteUserDataDialog(IDialogContext context, IAwaitable<string> result)
        {
            string deleteDataResult = await result;

            await context.PostAsync($"{deleteDataResult}");

            context.Wait(MessageReceived);
        }

        private static IMessageActivity GetMessageActivity(IDialogContext context)
        {
            return context.Activity.AsMessageActivity();
        }

    }
}