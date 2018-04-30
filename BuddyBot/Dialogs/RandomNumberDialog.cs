using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BuddyBot.Helpers;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class RandomNumberDialog : IDialog<int>
    {
        private readonly IList<EntityRecommendation> _entities;
        private int? _min, _max;
        private int? _randomNumber;

        public RandomNumberDialog(IList<EntityRecommendation> entities)
        {
            this._entities = entities;
        }

        public async Task StartAsync(IDialogContext context)
        {
            await Respond(context);
        }

        public async Task Respond(IDialogContext context)
        {
            var integersList = new List<int>();

            if (_entities.Count > 0)
            {
                foreach (var entity in _entities.Where(e => e.Type == "Number"))
                {
                    int.TryParse(entity.Entity, out var number);
                    integersList.Add(number);
                }

                _min = integersList.Min();
                _max = integersList.Max();
                _randomNumber = new Random().Next((int)_min, (int)_max);

                await context.PostAsync($"Generating a random number between {_min} & {_max}... 🎲");
                context.Done(_randomNumber);
            }
            else
            {
                PromptDialog.Text(context, Resume, "Please enter upper and lower values");
            }
        }

        private async Task Resume(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;

            var integersList = MessageHelper.ExtractIntegersFromMessage(message);

            _min = integersList.Min();
            _max = integersList.Max();

            _randomNumber = new Random().Next((int)_min, (int)_max);

            await context.PostAsync($"Generating a random number between {_min} & {_max}... 🎲");
            context.Done(_randomNumber);
        }
    }
}