using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace TechieBot.Dialogs
{
    [LuisModel("{luis_app_id}","{subscription_key}")]
    [Serializable]
    public class RootLUISDialog : LuisDialog<IMessageActivity>
    {


        public RootLUISDialog(ILuisService luis) : base(luis)
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
            await context.PostAsync("We need to get that fixed. The Zuck needs his ad money!");

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
            await context.PostAsync("Looks like we need an exit condition");

            context.Wait(MessageReceived);
        }


        //TODO - Uneeded method now?
        public Task StartAsync(IDialogContext context, LuisResult result)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        //TODO - Look at moving these methods into a parent class? 
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as IMessageActivity;

            context.Wait(MessageReceivedAsync);
        }
    }
}