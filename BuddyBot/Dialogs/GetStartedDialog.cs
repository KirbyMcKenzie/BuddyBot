using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BuddyBot.Dialogs.Builders;
using BuddyBot.Helpers;
using BuddyBot.Helpers.Contracts;
using BuddyBot.Models;
using BuddyBot.Models.Enums;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Connector;
using Pause = BuddyBot.Models.ConversationPauseConstants;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class GetStartedDialog : IDialog<IMessageActivity>
    {
        private readonly IBotDataService _botDataService;
        private readonly IDialogBuilder _dialogBuilder;
        private readonly IConversationService _conversationService;
        private readonly IMessageHelper _messageHelper;

        public GetStartedDialog(IBotDataService botDataService, IDialogBuilder dialogBuilder, 
            IConversationService conversationService, IMessageHelper messageHelper)
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
            SetField.NotNull(out _dialogBuilder, nameof(dialogBuilder), dialogBuilder);
            SetField.NotNull(out _conversationService, nameof(conversationService), conversationService);
            SetField.NotNull(out _messageHelper, nameof(messageHelper), messageHelper);
        }


        /// <summary>
        /// Execution for the <see cref="GetStartedDialog"/> starts here. 
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
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
                await context.PostAsync("Hi there... 🤔");
                await _messageHelper.ConversationPauseAsync(context, Pause.MediumPause);

                await context.PostAsync("I don't think, we've met before? Let me introduce myself..");
                await _messageHelper.ConversationPauseAsync(context, Pause.LongerPause);


                await context.PostAsync("I'm BuddyBot! I'm an intelligent personal assistant, here to help wherever I can! 😀");
                await _messageHelper.ConversationPauseAsync(context, Pause.LongPause);
                

                await context.PostAsync("Let's get you setup. Remember, I'm still learning, so be patient, and follow my prompts carefully!");
                await _messageHelper.ConversationPauseAsync(context, Pause.LongPause);

                context.Call(_dialogBuilder.BuildNameDialog(context.Activity.AsMessageActivity()), Resume_AfterNameDialog);
                await Task.CompletedTask;
            }
        }


        /// <summary>
        /// Method called after the <seealso cref="NameDialog"/> when called from the 
        /// <seealso cref="StartAsync"/> method.       
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The user's preferred name specified from the <see cref="NameDialog"/>.</param>
        private async Task Resume_AfterNameDialog(IDialogContext context, IAwaitable<string> result)
        {
            var activity = await result;
            await _messageHelper.ConversationPauseAsync(context, Pause.MediumPause);

            await context.PostAsync($"{activity}! what a great name");
            await _messageHelper.ConversationPauseAsync(context, Pause.ShortMediumPause);

            await context.PostAsync("Next we need to set my personality. My style, tone and attitute " +
                                    "are dictated by my personality settings. Pick what works best with you. You can always change this setting later!");
            await _messageHelper.ConversationPauseAsync(context, Pause.VeryLongPause);

            IMessageActivity replyToConversation = context.MakeMessage();

            replyToConversation.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            replyToConversation.Attachments = new List<Attachment>();

            PersonalityChoiceHeroCard friendlyHeroCard = new PersonalityChoiceHeroCard(
                PersonalityChatPersona.Friendly, "Friendly", "I'm always happy to help!",
                "https://buddybottablestorage.blob.core.windows.net/buddybotimages/avatars/BuddyBotFriendly.svg");

            PersonalityChoiceHeroCard professionalHeroCard = new PersonalityChoiceHeroCard(
                PersonalityChatPersona.Professional, "Professional", "I'm concise and helpful.",
                "https://buddybottablestorage.blob.core.windows.net/buddybotimages/avatars/BuddyBotProfessional.svg");

            PersonalityChoiceHeroCard humorousHeroCard = new PersonalityChoiceHeroCard(
                PersonalityChatPersona.Humorous, "Humorous", "Hurry up and get on with it.",
                "https://buddybottablestorage.blob.core.windows.net/buddybotimages/avatars/BuddyBotSassy.svg");

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


        /// <summary>
        /// Method called after the user has chosen which persona they'd like buddy to use.    
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The user's preferred bot persona specified from the <see cref="PersonalityChoiceHeroCard"/>.</param>
        private async Task Resume_AfterBotPersonaChoice(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var activity = await result;

            PersonalityChatPersona personaChoice = (PersonalityChatPersona) Enum.Parse(typeof(PersonalityChatPersona), activity.Text);

            context.Call(_dialogBuilder.BuildBotPersonaDialog(context.Activity.AsMessageActivity(), null, personaChoice), Resume_AfterBotPersonaDialog);
            await Task.CompletedTask;
        }


        /// <summary>
        /// Method called after the <seealso cref="BotPersonaDialog"/> when called from the 
        /// <seealso cref="Resume_AfterBotPersonaChoice"/> method.       
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The user's preferred bot persona specified from the <see cref="BotPersonaDialog"/>.</param>
        private async Task Resume_AfterBotPersonaDialog(IDialogContext context, IAwaitable<string> result)
        {
            var activity = await result;
            await _messageHelper.ConversationPauseAsync(context, Pause.MediumPause);

            await context.PostAsync($"Good choice, my personality is set to be {activity}");
            await _messageHelper.ConversationPauseAsync(context, Pause.ShortMediumPause);

            await context.PostAsync($"Okay the last step.");

            context.Call(_dialogBuilder.BuildPreferredWeatherLocationDialog(context.Activity.AsMessageActivity()), Resume_AfterPreferredWeatherDialog);
            await Task.CompletedTask;
        }


        /// <summary>
        /// Method called after the <seealso cref="PreferredWeatherLocationDialog"/> when called from the 
        /// <seealso cref="Resume_AfterBotPersonaDialog"/> method.       
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The user's preferred weather location specified from the <see cref="PreferredWeatherLocationDialog"/>.</param>
        private async Task Resume_AfterPreferredWeatherDialog(IDialogContext context, IAwaitable<string> result)
        {
            var activity = await result;
            await _messageHelper.ConversationPauseAsync(context, Pause.MediumPause);

            await context.PostAsync($"I love {activity}! It's such a nice city!");
            await _messageHelper.ConversationPauseAsync(context, Pause.MediumPause);

            await context.PostAsync("Looks like you're all set up!");
            await _messageHelper.ConversationPauseAsync(context, Pause.ShortMediumPause);

            await FinishAsync(context);
        }


        /// <summary>
        /// Execution for the <see cref="GetStartedDialog"/> finishes here. Displays <see cref="SuggestedActions"/> 
        /// to help guide user on what they can do next.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
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