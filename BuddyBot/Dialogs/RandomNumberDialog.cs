using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class RandomNumberDialog : IDialog<int>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            List<int> integersList = ExtractIntegersFromMessageActivity(message);

            int min = integersList.Min();
            int max = integersList.Max();

            int randomNumber = new Random().Next(min, max);

            await context.PostAsync($" Rolling a {max} sided dice...  🎲");

            context.Done(randomNumber);
        }

        private static List<int> ExtractIntegersFromMessageActivity(IMessageActivity message)
        {
            string[] values = Regex.Split(message.Text, @"\D+");
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