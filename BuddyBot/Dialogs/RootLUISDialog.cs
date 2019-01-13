using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using BuddyBot.Dialogs.Builders;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using BuddyBot.Services;
using BuddyBot.Helpers;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Internals.Fibers;
using static System.Threading.Thread;
using Pause = BuddyBot.Models.ConversationPauseConstants;
using Serilog;
using BuddyBot.Models.Enums;
using BuddyBot.Repository.DataAccess.Contracts;
using System.Linq;

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


        [LuisIntent("Smalltalk.Bot.Age")]
        [LuisIntent("Smalltalk.Bot.BodyFunctions")]
        [LuisIntent("Smalltalk.Bot.Boss")]
        [LuisIntent("Smalltalk.Bot.Busy")]
        [LuisIntent("Smalltalk.Bot.Creator")]
        [LuisIntent("Smalltalk.Bot.Doing")]
        [LuisIntent("Smalltalk.Bot.DoingLater")]
        [LuisIntent("Smalltalk.Bot.Family")]
        [LuisIntent("Smalltalk.Bot.Favorites")]
        [LuisIntent("Smalltalk.Bot.Gender")]
        [LuisIntent("Smalltalk.Bot.Happy")]
        [LuisIntent("Smalltalk.Bot.Hungry")]
        [LuisIntent("Smalltalk.Bot.KnowOtherBot")]
        [LuisIntent("Smalltalk.Bot.Opinion.Generic")]
        [LuisIntent("Smalltalk.Bot.Opinion.Love")]
        [LuisIntent("Smalltalk.Bot.Opinion.MeaningOfLife")]
        [LuisIntent("Smalltalk.Bot.RuleWorld")]
        [LuisIntent("Smalltalk.Bot.SexualIdentity")]
        [LuisIntent("Smalltalk.Bot.Smart")]
        [LuisIntent("Smalltalk.Bot.Spy")]
        [LuisIntent("Smalltalk.Bot.There")]
        [LuisIntent("Smalltalk.Bot.WhatAreYou")]
        [LuisIntent("Smalltalk.Bot.WhereAreyou")]
        [LuisIntent("Smalltalk.Compliment.Bot")]
        [LuisIntent("Smalltalk.Compliment.Response")]
        [LuisIntent("Smalltalk.Criticism.Bot")]
        [LuisIntent("Smalltalk.Dialog.Affirmation")]
        [LuisIntent("Smalltalk.Dialog.Laugh")]
        [LuisIntent("Smalltalk.Dialog.Polite")]
        [LuisIntent("Smalltalk.Dialog.Right")]
        [LuisIntent("Smalltalk.Dialog.Sorry")]
        [LuisIntent("Smalltalk.Dialog.ThankYou")]
        [LuisIntent("Smalltalk.Greeting.Bye")]
        [LuisIntent("Smalltalk.Greeting.HowAreYou")]
        public async Task SmallTalk(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(await _conversationService.GetResponseByIntentName(result.TopScoringIntent.Intent, _botDataService.GetPreferredBotPersona(context)));
            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            string name =  _botDataService.GetPreferredName(context);
            bool hasCompletedGetStarted = _botDataService.hasCompletedGetStarted(context);

            if (hasCompletedGetStarted)
            {
                // Just say hey
                await context.PostAsync(await _conversationService.GetGreeting(name));
            }
            else
            {
                // Run the setup/tutorial
                context.Call(_dialogBuilder.BuildGetStartedDialog(GetMessageActivity(context)), Resume_AfterGetStartedDialog);
            }
        }


        [LuisIntent("GetStarted")]
        [LuisIntent("Help")]
        public async Task GetStarted(IDialogContext context, LuisResult result)
        {

            context.Call(_dialogBuilder.BuildGetStartedDialog(GetMessageActivity(context)), Resume_AfterGetStartedDialog);
            await Task.Yield();
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

        private async Task Resume_AfterGetStartedDialog(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            await context.PostAsync(message);

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
            context.Call(_dialogBuilder.BuildBotPersonaDialog(GetMessageActivity(context), result.Entities, PersonalityChatPersona.None), Resume_AfterBotPersonaDialog);
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
            context.Call(_dialogBuilder.BuildDeleteUserDataDialog(GetMessageActivity(context), result.Entities), Resume_AfterDeleteUserDataDialog);
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