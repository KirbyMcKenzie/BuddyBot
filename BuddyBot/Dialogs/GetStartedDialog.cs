using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BuddyBot.Dialogs.Interfaces;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class GetStartedDialog : IDialog<string>
    {
        IBotDataService _botDataService;
        IDialogBuilder _dialogBuilder;

        public GetStartedDialog(IBotDataService botDataService, IDialogBuilder dialogBuilder)
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
            SetField.NotNull(out _dialogBuilder, nameof(dialogBuilder), dialogBuilder);
        }

        public async Task StartAsync(IDialogContext context)
        {

            await context.PostAsync("Hey I'm BuddyBot! 🤖");

            await context.PostAsync("Let's get you set up 🛠");


            // TODO - Replace with real entities or null out
             IList<EntityRecommendation> entityRecommendation = new List<EntityRecommendation>();

            context.Call(_dialogBuilder.BuildNameDialog(context.Activity.AsMessageActivity(), entityRecommendation), Resume_AfterNameDialog);
            await Task.CompletedTask;

            // TODO - check for already saved user data
            //IMessageActivity reply = context.MakeMessage();

            //reply.Text = "I'm here to help you with whatever you need. " +
            //             "However, I'm still learning so be patient! " +
            //             "Heres some things I can help you with now. 😀";

            //reply.SuggestedActions = new SuggestedActions
            //{
            //    Actions = new List<CardAction>()
            //    {
            //        new CardAction(){ Title = "Generate Random Number", Type=ActionTypes.ImBack, Value="Generate Random Number" },
            //        new CardAction(){ Title = "Tell a joke", Type=ActionTypes.ImBack, Value="Tell a joke" },
            //        new CardAction(){ Title = "Flip a coin", Type=ActionTypes.ImBack, Value="Flip a coin" },
            //    }
            //};

            //await context.PostAsync(reply);


            //context.Wait(MessageReceivedAsync);

        }

        private async Task Resume_AfterNameDialog(IDialogContext context, IAwaitable<string> result)
        {
            var activity = await result;

            await context.PostAsync($"{activity}! what a great name");

            await context.PostAsync("Next we need to set my personality. Pick one from the list below");

            // TODO - Replace with real entities or null out
            IList<EntityRecommendation> entityRecommendation = new List<EntityRecommendation>();

            context.Call(_dialogBuilder.BuildBotPersonaDialog(context.Activity.AsMessageActivity(), entityRecommendation), Resume_AfterBotPersonaDialog);
            await Task.CompletedTask;
           
        }

        private async Task Resume_AfterBotPersonaDialog(IDialogContext context, IAwaitable<string> result)
        {
            var activity = await result;

            await context.PostAsync($"Okay, my personality is set to be {activity}");

            // TODO - Replace with real entities or null out
            IList<EntityRecommendation> entityRecommendation = new List<EntityRecommendation>();

            context.Call(_dialogBuilder.BuildPreferredWeatherLocationDialog(context.Activity.AsMessageActivity(), entityRecommendation), Resume_AfterPreferredWeatherDialog);

            await Task.CompletedTask;

        }

        private Task Resume_AfterPreferredWeatherDialog(IDialogContext context, IAwaitable<string> result)
        {
            context.Done("How about no");
            return Task.CompletedTask;
        }
    }
}