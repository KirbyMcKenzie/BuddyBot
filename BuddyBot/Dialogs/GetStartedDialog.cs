using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BuddyBot.Dialogs.Builders;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.PersonalityChat.Core;
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
            if (_botDataService.IsNewUser(context))
            //if(true)
            {
                await context.PostAsync("Let's get you all set up 🛠");
                Sleep(Pause.MediumLongPause);

                await context.PostAsync("The first step is your name");
                Sleep(Pause.MediumPause);


                context.Call(_dialogBuilder.BuildNameDialog(context.Activity.AsMessageActivity()), Resume_AfterNameDialog);
                await Task.CompletedTask;

            }
            else
            {
                await FinishAsync(context);
                await Task.CompletedTask;
            }
        }

        private async Task Resume_AfterNameDialog(IDialogContext context, IAwaitable<string> result)
        {
            var activity = await result;

            Sleep(Pause.MediumLongPause);
            await context.PostAsync($"{activity}! what a great name");
            Sleep(Pause.ShortMediumPause);

            await context.PostAsync("Next we need to set my personality. My style, tone and attitute " +
                                    "are dictated by my personality settings. Pick what works best with you");
            Sleep(Pause.VeryLongPause);


            Activity message = new Activity();

            IMessageActivity replyToConversation = context.MakeMessage();

            //Activity replyToConversation = message.CreateReply("Should go to conversation, in carousel format");
            replyToConversation.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            replyToConversation.Attachments = new List<Attachment>();

            Dictionary<string, string> cardContentList = new Dictionary<string, string>();
            cardContentList.Add("PigLatin", "https://<ImageUrl1>");
            cardContentList.Add("Pork Shoulder", "https://<ImageUrl2>");
            cardContentList.Add("Bacon", "https://<ImageUrl3>");

            foreach (KeyValuePair<string, string> cardContent in cardContentList)
            {
                List<CardImage> cardImages = new List<CardImage>();
                cardImages.Add(new CardImage(url: cardContent.Value));

                List<CardAction> cardButtons = new List<CardAction>();

                CardAction plButton = new CardAction()
                {
                    Value = $"https://en.wikipedia.org/wiki/{cardContent.Key}",
                    Type = "openUrl",
                    Title = "WikiPedia Page"
                };

                cardButtons.Add(plButton);

                HeroCard plCard = new HeroCard()
                {
                    Title = $"I'm a hero card about {cardContent.Key}",
                    Subtitle = $"{cardContent.Key} Wikipedia Page",
                    Images = cardImages,
                    Buttons = cardButtons
                };

                Attachment plAttachment = plCard.ToAttachment();
                replyToConversation.Attachments.Add(plAttachment);
            }


            await context.PostAsync(replyToConversation);



            //context.Call(_dialogBuilder.BuildBotPersonaDialog(context.Activity.AsMessageActivity(), PersonalityChatPersona.Humorous), Resume_AfterBotPersonaDialog);
            //await Task.CompletedTask;
           
        }

        private async Task Resume_AfterBotPersonaDialog(IDialogContext context, IAwaitable<string> result)
        {
            var activity = await result;

            Sleep(Pause.MediumPause);
            await context.PostAsync($"Okay, my personality is set to be {activity}");
            Sleep(Pause.ShortMediumPause);

            context.Call(_dialogBuilder.BuildPreferredWeatherLocationDialog(context.Activity.AsMessageActivity()), Resume_AfterPreferredWeatherDialog);
           
            await Task.CompletedTask;

        }

        private async Task Resume_AfterPreferredWeatherDialog(IDialogContext context, IAwaitable<string> result)
        {

            Sleep(Pause.ShortMediumPause);
            await context.PostAsync("Looks like you're all set up!");
            
            _botDataService.SetIsNewUser(context, false);

            await FinishAsync(context);

        }

        private async Task FinishAsync(IDialogContext context)
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
                    new CardAction(){ Title = "Weather Forecast", Type=ActionTypes.ImBack, Value="Weather Forecast" },
                    new CardAction(){ Title = "Tell a joke", Type=ActionTypes.ImBack, Value="Tell a joke" },
                    new CardAction(){ Title = "Flip a coin", Type=ActionTypes.ImBack, Value="Flip a coin" },

                }
            };

            context.Done(reply);
            await Task.CompletedTask;
        }
    }
}