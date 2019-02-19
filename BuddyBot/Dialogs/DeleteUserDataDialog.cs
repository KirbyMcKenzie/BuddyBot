using BuddyBot.Helpers.Contracts;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using System.Threading.Tasks;
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


        /// <summary>
        /// Execution for the <see cref="DeleteUserDataDialog"/> starts here. 
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
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


        /// <summary>
        /// Method called after the user has chosen their preferred bot persona.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The result if the user would like to delete their data.</param>
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


        /// <summary>
        /// Plays out the 'rebirthing' of BuddyBot while deleteing all of the users private data.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
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