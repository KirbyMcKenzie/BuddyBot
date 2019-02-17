using BuddyBot.Helpers.Contracts;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Threading.Thread;
using Pause = BuddyBot.Models.ConversationPauseConstants;

namespace BuddyBot.Dialogs
{
    public class DeleteUserDataDialog : IDialog<string>
    {
        private readonly IBotDataService _botDataService;
        private readonly IMessageHelper _messageHelpers;
        private readonly IList<EntityRecommendation> _entities;

        public DeleteUserDataDialog(IBotDataService botDataService, IMessageHelper messageHelpers,
            IList<EntityRecommendation> entities)
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);
            SetField.NotNull(out _messageHelpers, nameof(messageHelpers), messageHelpers);
            _entities = entities;
        }


        public Task StartAsync(IDialogContext context)
        {
            string command = _messageHelpers.ExtractEntityFromMessage("Bot.Command", _entities) ?? string.Empty;

            if (command.Replace(" ", string.Empty) == "--Quick")
            {
                _botDataService.DeleteUserData(context);

                context.Done("Buddy restored to factory defaults.");
                return Task.CompletedTask;
            }

            PromptDialog.Confirm(context, ResumeAfterConfirmation, $"Would you like to delete your user data?", $"Would you like to delete your user data");
            return Task.CompletedTask;
        }


        private async Task ResumeAfterConfirmation(IDialogContext context, IAwaitable<bool> result)
        {
            bool confirmation = await result;

            switch (confirmation)
            {
                case true:
                    await EraseBuddysMemories(context);
                    break;

                default:

                    context.Done("Thank goodness!");
                    break;
            }
        }


        private async Task EraseBuddysMemories(IDialogContext context)
        {
            await context.PostAsync("Deleting buddy's memories. 🤖🔨");
            await _messageHelpers.ConversationPauseAsync(context, Pause.MediumPause);

            await context.PostAsync("I hope you're happy.");
            await _messageHelpers.ConversationPauseAsync(context, Pause.MediumLongPause);

            _botDataService.DeleteUserData(context);

            await context.PostAsync("Buddy restored to factory defaults.");
            await _messageHelpers.ConversationPauseAsync(context, Pause.MediumLongPause);

            IMessageActivity rebirthGif = context.MakeMessage();
            rebirthGif.Attachments.Add(new Attachment()
            {
                ContentUrl = "https://media.giphy.com/media/xTiTnlghyAeCrxWePe/giphy.gif",
                ContentType = "image/gif",
                Name = "rebirth.gif"
            });

            await context.PostAsync(rebirthGif);
            await _messageHelpers.ConversationPauseAsync(context, Pause.ExtraLongPause);

            context.Done("Congratulations!! It's a bot! 😊🤖");
        }
    }
}