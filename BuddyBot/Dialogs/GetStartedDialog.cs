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
using static System.Threading.Thread;
using Pause = BuddyBot.Models.ConversationPauseConstants;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class GetStartedDialog : IDialog<IMessageActivity>
    {
        IBotDataService _botDataService;
        readonly IDialogBuilder _dialogBuilder;

        public GetStartedDialog(IBotDataService botDataService, IDialogBuilder dialogBuilder)
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
            SetField.NotNull(out _dialogBuilder, nameof(dialogBuilder), dialogBuilder);
        }

        public async Task StartAsync(IDialogContext context)
        {

            await context.PostAsync("Hey I'm BuddyBot! 🤖");
            Sleep(Pause.MediumPause);

            // TODO - Rename to something like CompletedGetStarted
            //if (_botDataService.IsNewUser(context))
            if(true)
            {
                await context.PostAsync("Let's get you all set up 🛠");
                Sleep(Pause.MediumLongPause);

                await context.PostAsync("The first step is your name");
                Sleep(Pause.MediumPause);


                // TODO - Replace with real entities or null out
                IList<EntityRecommendation> entityRecommendation = new List<EntityRecommendation>();

                context.Call(_dialogBuilder.BuildNameDialog(context.Activity.AsMessageActivity(), entityRecommendation), Resume_AfterNameDialog);
                await Task.CompletedTask;

            }
            else
            {
                await Resume_AfterPreferredWeatherDialog(context, null);
                await Task.CompletedTask;
            }

            


        }

        private async Task Resume_AfterNameDialog(IDialogContext context, IAwaitable<string> result)
        {
            var activity = await result;

            Sleep(Pause.MediumLongPause);
            await context.PostAsync($"{activity}! what a great name");
            Sleep(Pause.ShortMediumPause);

            // TODO - Wrap this with Pauses 
            var typingMsg = context.MakeMessage();
            typingMsg.Type = ActivityTypes.Typing;
            typingMsg.Text = null;
            await context.PostAsync(typingMsg);
            Sleep(Pause.LongerPause);


            await context.PostAsync("Next we need to set my personality. My style, tone and attitute " +
                                    "are dictated by my personality settings. Pick what works best with you");
            Sleep(Pause.VeryLongPause);

            

            // TODO - Replace with real entities or null out
            IList<EntityRecommendation> entityRecommendation = new List<EntityRecommendation>();

            context.Call(_dialogBuilder.BuildBotPersonaDialog(context.Activity.AsMessageActivity(), entityRecommendation), Resume_AfterBotPersonaDialog);
            await Task.CompletedTask;
           
        }

        private async Task Resume_AfterBotPersonaDialog(IDialogContext context, IAwaitable<string> result)
        {
            var activity = await result;

            Sleep(Pause.MediumPause);
            await context.PostAsync($"Okay, my personality is set to be {activity}");
            Sleep(Pause.ShortMediumPause);

            // TODO - Replace with real entities or null out
            IList<EntityRecommendation> entityRecommendation = new List<EntityRecommendation>();

            context.Call(_dialogBuilder.BuildPreferredWeatherLocationDialog(context.Activity.AsMessageActivity(), entityRecommendation), Resume_AfterPreferredWeatherDialog);
           
            await Task.CompletedTask;

        }

        private async Task Resume_AfterPreferredWeatherDialog(IDialogContext context, IAwaitable<string> result)
        {

            Sleep(Pause.ShortMediumPause);
            await context.PostAsync("Looks like you're all set up!");
            
            _botDataService.SetIsNewUser(context, false);

            await FinishAsync(context, null);


        }

        private async Task FinishAsync(IDialogContext context, object o)
        {

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


            context.Done(reply);
            await Task.CompletedTask;
        }
    }
}