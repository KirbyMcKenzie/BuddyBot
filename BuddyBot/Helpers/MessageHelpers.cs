using BuddyBot.Models.Enums;
using Microsoft.Bot.Builder.Luis.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace BuddyBot.Helpers
{
    public static class MessageHelpers
    {
        public static IList<int> ExtractIntegersFromMessage(string message)
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

        /// <summary>
        /// Extracts Luis Entities from user imput and converts them to string
        /// </summary>
        /// <param name="entityToExtract">Mandatory. The name of the Entity to extract.</param>
        /// <param name="entities">Mandatory. List of Luis Entities from user input</param>
        /// <param name="TextCaseType">Optional. String output casing. E.g. "TitleCase", "Uppercase"</param>
        /// <returns></returns>
        public static string ExtractEntityFromMessage(string entityToExtract, IList<EntityRecommendation> entities, TextCaseType TextCaseType)
        {

                foreach (var entity in entities.Where(e => e.Type == entityToExtract))
                {
                    var entityResult = entity.Entity;

                    TextInfo cultureInfo = new CultureInfo("en-US", false).TextInfo;

                if(TextCaseType == TextCaseType.TitleCase)
                {
                    var entityUpperResult = cultureInfo.ToTitleCase(entityResult);
                } else if ()
                   


                    return entityUpperResult;

                }

            return null;
        }
    }
}
