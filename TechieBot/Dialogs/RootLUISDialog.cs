using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using TechieBot.Models;

namespace TechieBot.Dialogs
{
    [Serializable]
    public class RootLUISDialog : LuisDialog<object>
    {
        public RootLUISDialog() : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["luis:ModelId"],
            ConfigurationManager.AppSettings["luis:SubscriptionId"])))
        {
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I'm sorry I don't know what you mean");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hi I'm TechieBot!");

            IMessageActivity reply = context.MakeMessage();

            reply.Text = "I'm here to help you with all your " +
                "tech support needs. \n\n Here's some examples of things I can help with. If you're stuck just type 'Help' :)";

            reply.SuggestedActions = new SuggestedActions
            {
                Actions = new List<CardAction>()
                {
                    new CardAction(){ Title = "I can't connect to the Internet", Type=ActionTypes.ImBack, Value="No Internet Connection" },
                    new CardAction(){ Title = "My device won't turn on", Type=ActionTypes.ImBack, Value="Device No Bootup" },
                    new CardAction(){ Title = "My device keeps restarting", Type=ActionTypes.ImBack, Value="Device Restart Loop" },
                }
            };

            await context.PostAsync(reply);

            context.Wait(MessageReceived);
        }

        [LuisIntent("Diagnose.Internet.Connection")]
        public async Task DiagnoseInternetConnection(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Not good! Let's get you connected again. \n\nPlease answer the following with 'Yes' or 'No' answers");

            var form = new FormDialog<DiagnoseInternetConnectionForm>(new DiagnoseInternetConnectionForm(), DiagnoseInternetConnectionForm.BuildForm, FormOptions.PromptInStart);
            context.Call(form, ResumeAfterDiagnoseInternetForm);
        }

        private async Task PromptFurtherHelp(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("Is there anything else I can help with today?");

            context.Wait(MessageReceived);
        }

        [LuisIntent("Diagnose.Device.Bootup")]
        public async Task DiagnoseDeviceBootup(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Bootup problems called");

            context.Wait(MessageReceived);
        }

        [LuisIntent("Diagnose.Device.RestartLoop")]
        public async Task DiagnoseDeviceRestartLoop(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Diagnose.Device.RestartLoop called");

            context.Wait(MessageReceived);
        }

        private async Task ResumeAfterDiagnoseInternetForm(IDialogContext context, IAwaitable<DiagnoseInternetConnectionForm> result)
        {
            try
            {
                var searchQuery = await result;
                await context.PostAsync($"Is this your selection? \n\n " +
                    $"Current Device: {searchQuery.CurrentDevice.ToString()} \n\n" +
                    $"Restarted Device: {searchQuery.RestartedDevice.ToString()} \n\n" +
                    $"Restarted Router: {searchQuery.RestartedRouter.ToString()}");
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