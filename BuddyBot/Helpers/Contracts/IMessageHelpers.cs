using BuddyBot.Models.Enums;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuddyBot.Helpers.Contracts
{
    public interface IMessageHelper
    {
        Task ConversationPauseAsync(IDialogContext context, int pauseLength);

        string ExtractEntityFromMessage(string entityToExtract, IList<EntityRecommendation> entities, TextCaseType TextCaseType = TextCaseType.TitleCase);

        IList<int> ExtractIntegersFromMessage(string message);

    }
}
