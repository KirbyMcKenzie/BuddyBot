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
    public class GetStartedDialog : IDialog<string>
    {
        IBotDataService _botDataService;
        readonly IDialogBuilder _dialogBuilder;

        public GetStartedDialog(IBotDataService botDataService, IDialogBuilder dialogBuilder)
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
            SetField.NotNull(out _dialogBuilder, nameof(dialogBuilder), dialogBuilder);
        }

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageRecievedAsync);
            return Task.CompletedTask;
        }

        public async Task MessageRecievedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)

        {
            await context.PostAsync("Hey I'm BuddyBot! 🤖");
            Sleep(Pause.MediumPause);

            var val = _botDataService.hasCompletedGetStarted(context);

            //if (_botDataService.hasCompletedGetStarted(context))
            if(true)
            {
                // user has already done setup, show them what Buddy can do               
                await FinishAsync(context);
            }
            else
            {
                // Set up user 
                await context.PostAsync("Let's get you all set up 🛠");
                Sleep(Pause.MediumLongPause);

                await context.PostAsync("The first step is your name");
                Sleep(Pause.MediumPause);


                context.Call(_dialogBuilder.BuildNameDialog(context.Activity.AsMessageActivity()), Resume_AfterNameDialog);
                await Task.CompletedTask;
            }

            context.Done("");
            await Task.CompletedTask;
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

            PersonalityChoiceHeroCard friendlyHeroCard = new PersonalityChoiceHeroCard(PersonalityChatPersona.Friendly, "Friendly", "I think we should be friends!", "https://www.popsci.com/sites/popsci.com/files/styles/1000_1x_/public/images/2014/11/robot-friend-popular-science.jpg?itok=BjNu0I7B");
            PersonalityChoiceHeroCard professionalHeroCard = new PersonalityChoiceHeroCard(PersonalityChatPersona.Professional, "Professional", "I'm concise and helpful.", "https://images.complex.com/complex/image/upload/c_limit,w_680/fl_lossy,pg_1,q_auto/robot-butler_fpiory.jpg");
            PersonalityChoiceHeroCard HumorousHeroCard = new PersonalityChoiceHeroCard(PersonalityChatPersona.Humorous, "Humorous", "The authentic Buddy experience.", "https://3c1703fe8d.site.internapcdn.net/newman/gfx/news/hires/2009/achildrobotw.jpg");

            List<PersonalityChoiceHeroCard> heroCardList = new List<PersonalityChoiceHeroCard>
            {
                friendlyHeroCard,
                professionalHeroCard,
                HumorousHeroCard
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
                    Title = "Confirm"
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

            await context.PostAsync(reply);
            
            context.Done(true);
            await Task.CompletedTask;
        }

    }
}