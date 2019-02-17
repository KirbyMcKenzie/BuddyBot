using System;
using BuddyBot.Models.Enums;
using Microsoft.Bot.Builder.Luis.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;
using BuddyBot.Helpers.Contracts;

namespace BuddyBot.Helpers
{
    public class MessageHelper: IMessageHelper
    {
        /// <summary>
        ///  Creates a typing indicator with a pause to replicate the bot typing a message.
        /// </summary>
        /// <param name="context">Mandatory. The content for the execution of a dialog's conversational process.</param>
        /// <param name="pauseLength">Mandatory. The length that the typing indicator should show.</param>
        /// <returns></returns>
        public async Task ConversationPauseAsync(IDialogContext context, int pauseLength)
        {
            var typingMsg = context.MakeMessage();
            typingMsg.Type = ActivityTypes.Typing;
            await context.PostAsync(typingMsg);

            System.Threading.Thread.Sleep(pauseLength);
        }

        /// <summary>
        /// Extracts Luis Entities from user input and converts them to string.
        /// </summary>
        /// <param name="entityToExtract">Mandatory. The name of the Entity to extract.</param>
        /// <param name="entities">Mandatory. List of Luis Entities from user input</param>
        /// <param name="TextCaseType">Optional. String output casing. E.g. "TitleCase", "Uppercase"</param>
        public string ExtractEntityFromMessage(string entityToExtract, IList<EntityRecommendation> entities, TextCaseType TextCaseType = TextCaseType.TitleCase)
        {

            foreach (var entity in entities.Where(e => e.Type == entityToExtract))
            {
                string entityResult = entity.Entity;
                string entityString;

                TextInfo cultureInfo = new CultureInfo("en-US", false).TextInfo;

                switch (TextCaseType)
                {

                    case TextCaseType.UpperCase:
                        entityString = cultureInfo.ToUpper(entityResult);
                        break;
                    case TextCaseType.LowerCase:
                        entityString = cultureInfo.ToTitleCase(entityResult);
                        break;
                    default:
                        entityString = cultureInfo.ToTitleCase(entityResult);
                        break;
                }

                return entityString;
            }

            return null;
        }

        /// <summary>
        /// Extracts any integers found in user message.
        /// </summary>
        /// <param name="entityToExtract">Mandatory. The message to try find integers in./</param>
        public IList<int> ExtractIntegersFromMessage(string message)
        {
            string[] values = Regex.Split(message, @"\D+");
            IList<int> integersList = new List<int>();

            foreach (var value in values)
            {
                int.TryParse(value, out var number);
                integersList.Add(number);
            }

            return integersList;
        }
    }
}
