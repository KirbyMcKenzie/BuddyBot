using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using BuddyBot.Dialogs.Forms;
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

            // Todo - move these to method
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
            await context.PostAsync("It's pretty cold right now");

            context.Wait(MessageReceived);
        }

        //TODO - Add async to method
        [LuisIntent("Random.Number")]
        public async Task RandomNumber(IDialogContext context, LuisResult result)
        {
            context.Call(new RandomNumberDialog(result.Entities), Resume_AfterRandomNumberDialog);
        }

        public async Task Resume_AfterRandomNumberDialog(IDialogContext context, IAwaitable<int> result)
        {
            var randomNumber = await result;

            await context.PostAsync($"The result is... {randomNumber}! 🎉🎉");

            context.Wait(MessageReceived);
        }

        [LuisIntent("Showcase")]
        public async Task Showcase(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("You ready?");

            // TODO - Remove dependency
            context.Call(new ShowcaseDialog(), Resume_AfterShowcaseDialog);
        }

        // TODO - Find out why this isnt being called
        public async Task Resume_AfterShowcaseDialog(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;

            await context.PostAsync($" Got you! ::{message}");

            context.Wait(MessageReceived);
        }

        [LuisIntent("Diagnose.Internet.Connection")]
        public async Task DiagnoseInternetConnection(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Not good! Let's get you connected again. \n\nPlease answer the following with 'Yes' or 'No' answers");

            // TODO - remove dependency
            var form = new FormDialog<DiagnoseInternetConnectionForm>(new DiagnoseInternetConnectionForm(), DiagnoseInternetConnectionForm.BuildForm, FormOptions.PromptInStart);
            context.Call(form, ResumeAfterDiagnoseInternetForm);
        }

        [LuisIntent("Diagnose.Device.RestartLoop")]
        public async Task DiagnoseDeviceRestartLoop(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Diagnose.Device.RestartLoop called");

            context.Wait(MessageReceived);
        }

        // TODO - See if possible to move this into form or seperate dialog
        private async Task ResumeAfterDiagnoseInternetForm(IDialogContext context, IAwaitable<DiagnoseInternetConnectionForm> result)
        {
            try
            {
                var searchQuery = await result;
                await context.PostAsync($"Answers \n\n " +
                    $"Current Device: {searchQuery.CurrentDevice} \n\n" +
                    $"Operating System: {searchQuery.OperatingSystem} \n\n" +
                    $"Restarted Device: {searchQuery.RestartedDevice} \n\n" +
                    $"Restarted Router: {searchQuery.RestartedRouter} \n\n" +
                    $"Problem Resolved: {searchQuery.ProblemResolved}");
            }
            catch (FormCanceledException ex)
            {
                string reply;

                if (ex.InnerException == null)
                {
                    reply = "You have canceled the operation.";
                }
                else
                {
                    reply = $"Oops! Something went wrong :( Technical Details: {ex.InnerException.Message}";
                }

                await context.PostAsync(reply);
            }
            finally
            {
                context.Done<object>(null);
            }
        }
    }
}