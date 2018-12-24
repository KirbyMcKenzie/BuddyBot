using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BuddyBot.Dialogs.Builders;
using BuddyBot.Models;
using BuddyBot.Models.Enums;
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
        private readonly IBotDataService _botDataService;
        private readonly IDialogBuilder _dialogBuilder;
        private readonly IConversationService _conversationService;

        public GetStartedDialog(IBotDataService botDataService, IDialogBuilder dialogBuilder, IConversationService conversationService)
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
            SetField.NotNull(out _dialogBuilder, nameof(dialogBuilder), dialogBuilder);
            SetField.NotNull(out _conversationService, nameof(conversationService), conversationService);
        }

        public async Task StartAsync(IDialogContext context)
        {
            

            if (_botDataService.hasCompletedGetStarted(context))
            {
                // user has already done setup, show them what Buddy can do               
                await FinishAsync(context);
            }
            else
            {
                // Introductions and user setup
                await context.PostAsync("Hey there!");
                Sleep(Pause.MediumPause);

                await context.PostAsync("🤔");
                Sleep(Pause.ExtraLongPause);

                await context.PostAsync("I don't think, we've met before?");
                Sleep(Pause.LongPause);

                await context.PostAsync("Let me introduce myself.");
                Sleep(Pause.ExtraLongPause);

                // Sends typing indicator to user
                var typingMsg = context.MakeMessage();
                typingMsg.Type = ActivityTypes.Typing;
                await context.PostAsync(typingMsg);

                await context.PostAsync("I'm BuddyBot 🤖 I'm an intelligent personal assistant, " +
                                        "here to help wherever I can. Pleased to meet you!");
                Sleep(Pause.ExtraLongPause);

                context.Call(_dialogBuilder.BuildNameDialog(context.Activity.AsMessageActivity()), Resume_AfterNameDialog);
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

            IMessageActivity replyToConversation = context.MakeMessage();

            replyToConversation.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            replyToConversation.Attachments = new List<Attachment>();

            PersonalityChoiceHeroCard friendlyHeroCard = new PersonalityChoiceHeroCard(PersonalityChatPersona.Friendly, "Friendly", "I think we should be friends!", "https://www.popsci.com/sites/popsci.com/files/styles/1000_1x_/public/images/2014/11/robot-friend-popular-science.jpg?itok=BjNu0I7B");
            PersonalityChoiceHeroCard professionalHeroCard = new PersonalityChoiceHeroCard(PersonalityChatPersona.Professional, "Professional", "I'm concise and helpful.", "https://images.complex.com/complex/image/upload/c_limit,w_680/fl_lossy,pg_1,q_auto/robot-butler_fpiory.jpg");
            PersonalityChoiceHeroCard humorousHeroCard = new PersonalityChoiceHeroCard(PersonalityChatPersona.Humorous, "Humorous", "The authentic Buddy experience.", "https://3c1703fe8d.site.internapcdn.net/newman/gfx/news/hires/2009/achildrobotw.jpg");

            List<PersonalityChoiceHeroCard> heroCardList = new List<PersonalityChoiceHeroCard>
            {
                friendlyHeroCard,
                professionalHeroCard,
                humorousHeroCard
            };

            foreach (PersonalityChoiceHeroCard heroCard in heroCardList)
            {
                List<CardImage> cardImages = new List<CardImage>();
                cardImages.Add(new CardImage(url: heroCard.ImageUrl));

                List<CardAction> cardButtons = new List<CardAction>();

                CardAction plButton = new CardAction()
                {
                    Value = $"{heroCard.PersonalityType}",
                    Type = "imBack",
                    Title = "Select"
                };

                cardButtons.Add(plButton);

                HeroCard plCard = new HeroCard()
                {
                    Title = $"{heroCard.Title}",
                    Subtitle = $"{heroCard.Subtitle}",
                    Images = cardImages,
                    Buttons = cardButtons
                };

                Attachment plAttachment = plCard.ToAttachment();
                replyToConversation.Attachments.Add(plAttachment);
            }

            await context.PostAsync(replyToConversation);

            context.Wait(Resume_AfterBotPersonaChoice);
        }

        private async Task Resume_AfterBotPersonaChoice(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var activity = await result;

            PersonalityChatPersona personaChoice = (PersonalityChatPersona) Enum.Parse(typeof(PersonalityChatPersona), activity.Text);

            context.Call(_dialogBuilder.BuildBotPersonaDialog(context.Activity.AsMessageActivity(), null, personaChoice), Resume_AfterBotPersonaDialog);
            await Task.CompletedTask;
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
            
            await FinishAsync(context);
        }

        private async Task FinishAsync(IDialogContext context)
        {
            _botDataService.SethasCompletedGetStarted(context, true);

            IMessageActivity reply = context.MakeMessage();

            reply.Text = "Here's a few things I can do right now. I'm trying my best to learn new things 😀";

            reply.SuggestedActions = new SuggestedActions
            {
                Actions = new List<CardAction>()
                {
                    new CardAction(){ Title = "🎲 Random Number", Type=ActionTypes.ImBack, Value="🎲 Random Number" },
                    new CardAction(){ Title = "⛅ Weather", Type=ActionTypes.ImBack, Value=" Weather" },
                    new CardAction(){ Title = "🤣 Joke", Type=ActionTypes.ImBack, Value="🤣 Joke" },
                    new CardAction(){ Title = "❓ Flip Coin", Type=ActionTypes.ImBack, Value="❓ Flip Coin" },
                }
            };
            context.Done(reply);
            await Task.CompletedTask;
        }

    }
}