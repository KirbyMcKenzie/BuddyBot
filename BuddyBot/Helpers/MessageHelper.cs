using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BuddyBot.Helpers
{
    public static class MessageHelper
    {
        public static List<int> ExtractIntegersFromMessage(string message)
        {
            string[] values = Regex.Split(message, @"\D+");
            List<int> integersList = new List<int>();

            foreach (var value in values)
            {
                int.TryParse(value, out var number);
                integersList.Add(number);
            }

            return integersList;
        }
    }
}