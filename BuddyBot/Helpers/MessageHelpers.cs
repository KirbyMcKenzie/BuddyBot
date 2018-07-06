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

        public static string ExtractEntityFromMessage(string entityToExtract, IList<EntityRecommendation> entities)
        {

            if (entities.Count > 0 && entities.Count <= 1)
            {
                foreach (var entity in entities.Where(e => e.Type == entityToExtract))
                {
                    var entityResult = entity.Entity;

                    TextInfo cultureInfo = new CultureInfo("en-US", false).TextInfo;
                    var entityUpperResult = cultureInfo.ToTitleCase(entityResult);

                    return entityUpperResult;

                }
            }

            return null;
        }
    }
}
