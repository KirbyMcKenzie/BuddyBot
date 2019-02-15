﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using BuddyBot.Helpers;
using static System.Threading.Thread;
using Pause = BuddyBot.Models.ConversationPauseConstants;
using BuddyBot.Helpers.Contracts;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class RandomNumberDialog : IDialog<int>
    {
        private readonly IMessageHelper _messageHelpers;
        private readonly IList<EntityRecommendation> _entities;
        private int _min, _max;

        public RandomNumberDialog(IMessageHelper messageHelpers, IList<EntityRecommendation> entities)
        {
            _messageHelpers = messageHelpers;
            _entities = entities;
        }

        public async Task StartAsync(IDialogContext context)
        {
            await Respond(context);
        }

        public async Task Respond(IDialogContext context)
        {
            var messageNumberList = new List<int>();

            // Luis found entities, try parse them to use as random number inputs
            if (_entities.Count > 0)
            {
                foreach (var entity in _entities.Where(e => e.Type == "Number"))
                {
                    int.TryParse(entity.Entity, out var number);
                    messageNumberList.Add(number);
                }

                _min = messageNumberList.Min();
                _max = messageNumberList.Max();

                var randomNumber = new Random().Next(_min, _max);

                
                await context.PostAsync($"Picking a random number between {_min} & {_max}... 🎲");

                Sleep(Pause.ShortMediumPause);
                context.Done(randomNumber);
            }
            else
            {
                //Luis could not pick up entities, prompt user to pick numbers
                PromptDialog.Text(context, Resume_AfterPickNumbersPrompt, "Enter upper and lower number, and I'll pick a number between the two.");
            }
        }

        private async Task Resume_AfterPickNumbersPrompt(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;

            var messageNumberList = _messageHelpers.ExtractIntegersFromMessage(message);

            _min = messageNumberList.Min();
            _max = messageNumberList.Max();

            var randomNumber = new Random().Next(_min, _max);

            await context.PostAsync($"Generating a random number between {_min} & {_max}... 🎲");

            Sleep(Pause.ShortMediumPause);
            context.Done(randomNumber);
        }
    }
}