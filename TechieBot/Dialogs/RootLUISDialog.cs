using System;
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

            await context.PostAsync("Hello there! :)");
            context.Wait(MessageReceived);
        }

        public Task StartAsync(IDialogContext context, LuisResult result)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as IMessageActivity;

            // TODO: Put logic for handling user message here

            context.Wait(MessageReceivedAsync);
        }
    }
}