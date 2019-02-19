using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis.Models;
using Pause = BuddyBot.Models.ConversationPauseConstants;
using BuddyBot.Helpers.Contracts;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class RandomNumberDialog : IDialog<string>
    {
        private readonly IMessageHelper _messageHelpers;
        private readonly IList<EntityRecommendation> _entities;
        private int _min, _max;

        public RandomNumberDialog(IMessageHelper messageHelpers, IList<EntityRecommendation> entities)
        {
            _messageHelpers = messageHelpers;
            _entities = entities;
        }


        /// <summary>
        /// Execution for the <see cref="RandomNumberDialog"/> starts here. 
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        public async Task StartAsync(IDialogContext context)
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

                ValidateInputs(context, _min, _max);
                await PickRandomNumber(context, _min, _max);

            }
            else
            {
                //Luis could not pick up entities, prompt user to pick numbers
                PromptDialog.Text(context, Resume_AfterPickNumbersPrompt, 
                    "Enter an upper and a lower number, and I'll pick a number between the two.");
            }
        }


        /// <summary>
        /// Called after prompting the user to specify what range they'd like random numbers generated for.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="result">Mandatory. The message form the user specifying the range they'd like random numbers generated for.</param>
        private async Task Resume_AfterPickNumbersPrompt(IDialogContext context, IAwaitable<string> result)
        {
            var message = await result;
            var messageNumberList = _messageHelpers.ExtractIntegersFromMessage(message);

            if(messageNumberList != null)
            {
                _min = messageNumberList.Min();
                _max = messageNumberList.Max();

                ValidateInputs(context, _min, _max);
                await PickRandomNumber(context, _min, _max);

            } else
            {
                PromptDialog.Text(context, Resume_AfterPickNumbersPrompt,
                    "That doesn't look right.. Please enter an upper and a lower number, and I'll pick a number between the two.");
            }
        }


        /// <summary>
        /// Checks that the user entered in at least one number to generate random numbers for.
        /// If the user only chose one number, that will be used as the upper range. If none, it will
        /// prompt again for new numbers.
        /// </summary>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="min">Mandatory. The lower number range.</param>
        /// <param name="max">Mandatory. The higher number range.</param>
        private void ValidateInputs(IDialogContext context, int min, int max)
        {
            if (_min == 0 && _max == 0)
            {
                PromptDialog.Text(context, Resume_AfterPickNumbersPrompt, 
                    "That doesn't look right.. Please enter an upper and a lower number, and I'll pick a number between the two.");
            } else if (_min == _max)
            {
                _min = 0;
            }
        }


        /// <summary>
        /// Generates random number and posts that number to the user, ending the dialog.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="context">Mandatory. The context for the execution of a dialog's conversational process.</param>
        /// <param name="min">Mandatory. The lower number range.</param>
        /// <param name="max">Mandatory. The higher number range.</param>
        /// <returns></returns>
        private async Task PickRandomNumber(IDialogContext context, int min, int max)
        {
            var randomNumber = new Random().Next(_min, _max);

            await context.PostAsync($"Generating a random number between {_min} & {_max}... 🎲");
            await _messageHelpers.ConversationPauseAsync(context, Pause.ShortMediumPause);

            context.Done($"The result is... {randomNumber}! 🎉🎉");
        }
    }
}