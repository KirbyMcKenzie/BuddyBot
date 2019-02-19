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
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Internals.Fibers;
using static System.Threading.Thread;
using Pause = BuddyBot.Models.ConversationPauseConstants;
using BuddyBot.Models.Enums;
using BuddyBot.Helpers.Contracts;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class RootLuisDialog : LuisDialog<object>
    {
        private readonly IBotDataService _botDataService;
        private readonly IConversationService _conversationService;
        private readonly IDialogBuilder _dialogBuilder;
        private readonly IHeadTailsService _headTailsService;
        private readonly IJokeService _jokeService;
        private readonly IMessageHelper _messageHelper;
        
        public RootLuisDialog(
            IBotDataService botDataService, IConversationService conversationService,
            IDialogBuilder dialogBuilder, IHeadTailsService headTailsService, 
            IJokeService jokeService, IMessageHelper messageHelper)
            : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["luis:ModelId"],
            ConfigurationManager.AppSettings["luis:SubscriptionId"])))
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
            SetField.NotNull(out _conversationService, nameof(conversationService), conversationService);
            SetField.NotNull(out _dialogBuilder, nameof(dialogBuilder), dialogBuilder);
            SetField.NotNull(out _headTailsService, nameof(headTailsService), headTailsService);
            SetField.NotNull(out _jokeService, nameof(jokeService), jokeService);
            SetField.NotNull(out _messageHelper, nameof(messageHelper), messageHelper);
        }


        /// <summary>
        /// Method for the 'None' LUIS intent. Called when LUIS cannot determine a specific intent.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I'm sorry, I don't know what you mean. " +
                                    "You can type 'help' at anytime to get a list of things I can do");
            context.Wait(MessageReceived);
        }


        /// <summary>
        /// Method for all of the 'Smalltalk' LUIS intents. Calls the database with the top scoring intent 
        /// and returns a random response related to the users preferred bot personality. 
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
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
        [LuisIntent("Smalltalk.Greeting.HowWasYourDay")]
        [LuisIntent("Smalltalk.Greeting.OtherBot")]
        [LuisIntent("Smalltalk.Greeting.WhatsUp")]
        [LuisIntent("Smalltalk.User.Angry")]
        [LuisIntent("Smalltalk.User.BeBack")]
        [LuisIntent("Smalltalk.User.Bored")]
        [LuisIntent("Smalltalk.User.Happy")]
        [LuisIntent("Smalltalk.User.Hungry")]
        // [LuisIntent("Smalltalk.User.KeyboardMash")] //- TODO - Add to DB & Seed
        [LuisIntent("Smalltalk.User.Kidding")]
        [LuisIntent("Smalltalk.User.Lonely")]
        [LuisIntent("Smalltalk.User.Sad")]
        [LuisIntent("Smalltalk.User.Tired")]
        public async Task SmallTalk(IDialogContext context, LuisResult result)
        {
            await context.PostAsync(await _conversationService.GetResponseByIntentName(result.TopScoringIntent.Intent,
                _botDataService.GetPreferredBotPersona(context)));

            context.Wait(MessageReceived);
        }


        /// <summary>
        /// Method for the 'Greeting' LUIS intent. Greets the user and run them through a short tutorial 
        /// if they havent done so already. If they have, return a greeting using the 
        /// <seealso cref="ConversationService"/>.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
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


        /// <summary>
        /// Method for the 'GetStarted' & 'Help' LUIS intents. Calls the <seealso cref="GetStartedDialog"/> to
        /// provide assistant to user. if they havent done so already. Forwards the conversation to the
        /// <see cref="Resume_AfterGetStartedDialog"/> method when completed.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        [LuisIntent("GetStarted")]
        [LuisIntent("Help")]
        public async Task GetStarted(IDialogContext context, LuisResult result)
        {
            context.Call(_dialogBuilder.BuildGetStartedDialog(GetMessageActivity(context)), Resume_AfterGetStartedDialog);
            await Task.Yield();
        }


        /// <summary>
        /// Method called after the <seealso cref="GetStartedDialog"/> when called from the 
        /// <seealso cref="GetStarted"/> method.       
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        private async Task Resume_AfterGetStartedDialog(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }


        /// <summary>
        /// Method for the 'Random.HeadsTails' LUIS intent. Randomly chooses heads or tails for the user.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        [LuisIntent("Random.HeadsTails")]
        public async Task HeadsTails(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Flipping a coin.. 🤞");
            await _messageHelper.ConversationPauseAsync(context, Pause.ShortPause);

            await context.PostAsync("The result is...");
            await _messageHelper.ConversationPauseAsync(context, Pause.MediumLongPause);
            
            await context.PostAsync(await _headTailsService.GetRandomHeadsTails());
            context.Wait(MessageReceived);
        }


        /// <summary>
        /// Method for the 'Random.Joke' LUIS intent. Gets random joke from JokeAPI 
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        [LuisIntent("Random.Joke")]
        public async Task Joke(IDialogContext context, LuisResult result)
        {

            await context.PostAsync(await _jokeService.GetRandomJoke());
            context.Wait(MessageReceived);
        }


        /// <summary>
        /// Method for the 'Random.Number' LUIS intent. Calls the <seealso cref="RandomNumberDialog"/> that returns 
        /// a random number to user, then forwards converstion to <see cref="Resume_AfterRandomNumberDialog"/> when completed.        
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        [LuisIntent("Random.Number")]
        public async Task RandomNumber(IDialogContext context, LuisResult result)
        {
            context.Call(_dialogBuilder.BuildRandomNumberDialog(GetMessageActivity(context), result.Entities), Resume_AfterStringDialog);
            await Task.Yield();
        }


        /// <summary>
        /// Method for the 'Miscellaneous.QueryName' LUIS intent. Returns BuddyBots name to user.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        [LuisIntent("Miscellaneous.QueryName")]
        public async Task QueryName(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("My name is BuddyBot.");
            context.Wait(MessageReceived);
        }


        /// <summary>
        /// Method for the 'Miscellaneous.ConfirmRobot' LUIS intent. Calls the <see cref="ConfirmRobotDialog"/> and 
        /// forwards converstion to <see cref="Resume_ConfirmRobotDialog"/> when completed.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        [LuisIntent("Miscellaneous.ConfirmRobot")]
        public async Task ConfirmRobot(IDialogContext context, LuisResult result)
        {
            context.Call(_dialogBuilder.BuildConfirmRobotDialog(GetMessageActivity(context)), Resume_AfterStringDialog);
            await Task.Yield();
        }


        /// <summary>
        /// Method for the 'User.UpdatePreferredName' LUIS intent. Calls the <see cref="NameDialog"/> to update 
        /// the user's preferred name and forwards converstion to <see cref="Resume_AfterNameDialog"/> when 
        /// completed.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        [LuisIntent("User.UpdatePreferredName")]
        public async Task UpdatePreferredName(IDialogContext context, LuisResult result)
        {
            context.Call(_dialogBuilder.BuildNameDialog(GetMessageActivity(context), result.Entities), Resume_AfterNameDialog);
            await Task.Yield();
        }


        /// <summary>
        /// Method called after the <seealso cref="NameDialog"/> when called from the 
        /// <seealso cref="UpdatePreferredName"/> method.       
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        private async Task Resume_AfterNameDialog(IDialogContext context, IAwaitable<string> result)
        {
            string name = await result;
            await context.PostAsync($"I've got your name saved as {name}.");
        }


        /// <summary>
        /// Method for the 'User.UpdatePreferredBotPersona' LUIS intent. Calls the <see cref="BotPersonaDialog"/> to update 
        /// the user's preferred bot personality and forwards converstion to <see cref="Resume_AfterBotPersonaDialog"/> 
        /// when completed.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        [LuisIntent("User.UpdatePreferredBotPersona")]
        public async Task UpdatePreferredBotPersona(IDialogContext context, LuisResult result)
        {
            context.Call(_dialogBuilder.BuildBotPersonaDialog(GetMessageActivity(context), result.Entities, PersonalityChatPersona.None), Resume_AfterBotPersonaDialog);
            await Task.Yield();
        }


        /// <summary>
        /// Method called after the <seealso cref="BotPersonaDialog"/> when called from the 
        /// <seealso cref="UpdatePreferredBotPersona"/> method.       
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        private async Task Resume_AfterBotPersonaDialog(IDialogContext context, IAwaitable<string> result)
        {
            string persona = await result;
            await context.PostAsync($"Okay, my personality is set to {persona}.");
            context.Wait(MessageReceived);
        }


        /// <summary>
        /// Method for the 'User.UpdatePreferredWeatherLocation' LUIS intent. Calls the 
        /// <see cref="PreferredWeatherLocationDialog"/> to update the user's preferred weather location and 
        /// forwards converstion to <see cref="Resume_AfterPreferredWeatherLocationDialog"/> 
        /// when completed.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        [LuisIntent("User.UpdatePreferredWeatherLocation")]
        public async Task UpdatePreferredWeatherLocation(IDialogContext context, LuisResult result)
        {
            context.Call(_dialogBuilder.BuildPreferredWeatherLocationDialog(GetMessageActivity(context), result.Entities), Resume_AfterPreferredWeatherLocationDialog);
            await Task.Yield();
        }


        /// <summary>
        /// Method called after the <seealso cref="PreferredWeatherLocationDialog"/> when called from the 
        /// <seealso cref="UpdatePreferredWeatherLocation"/> method.       
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        public async Task Resume_AfterPreferredWeatherLocationDialog(IDialogContext context, IAwaitable<string> result)
        {
            string preferredWeatherLocation = await result;
            await context.PostAsync($"Okay, I've got your preferred weather location set as {preferredWeatherLocation}.");
            context.Wait(MessageReceived);
        }


        /// <summary>
        /// Method for the 'User.DeleteUserData' LUIS intent. Calls the  <see cref="PreferredWeatherLocationDialog"/> to 
        /// delete all of the user's sotred data. Forwards converstion to <see cref="Resume_AfterDeleteUserDataDialog"/> 
        /// when completed.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        [LuisIntent("User.DeleteUserData")]
        public async Task DeleteUserData(IDialogContext context, LuisResult result)
        {
            context.Call(_dialogBuilder.BuildDeleteUserDataDialog(GetMessageActivity(context), result.Entities), Resume_AfterStringDialog);
            await Task.Yield();
        }


        /// <summary>
        /// Method for the 'Weather.GetForecast' LUIS intent. Calls the <see cref="GetWeatherForecastDialog"/> to retrieve 
        /// the current weather and forwards converstion to <see cref="Resume_AfterBotPersonaDialog"/> when completed.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        [LuisIntent("Weather.GetForecast")]
        public async Task GetWeatherForecast(IDialogContext context, LuisResult result)
        {
            context.Call(_dialogBuilder.BuilGetWeatherForecastDialog(GetMessageActivity(context), result.Entities), Resume_AfterStringDialog);
            await Task.Yield();
        }


        /// <summary>
        /// General method called after Dialogs that return strings.
        /// <seealso cref="DeleteUserData"/> method.       
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The scored LUIS result from the users utterance.</param>
        private async Task Resume_AfterStringDialog(IDialogContext context, IAwaitable<string> result)
        {
            string message = await result;
            await context.PostAsync($"{message}");
            context.Wait(MessageReceived);
        }


        /// <summary>
        ///  Method for returning the message activity from the context.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        private static IMessageActivity GetMessageActivity(IDialogContext context)
        {
            return context.Activity.AsMessageActivity();
        }
    }
}