using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.PersonalityChat.Core;
using Microsoft.Bot.Builder.PersonalityChat;
using Microsoft.Bot.Connector;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class PersonalityChatDialog : PersonalityChatDialog<object> 
    {
        private readonly PersonalityChatDialogOptions _personalityChatDialogOptions = new PersonalityChatDialogOptions(botPersona: PersonalityChatPersona.Humorous)
        {
            RespondOnlyIfChat = false,
            ScenarioThresholdScore = 0.2f,
        };

        public PersonalityChatDialog()
        {
            this.SetPersonalityChatDialogOptions(_personalityChatDialogOptions);
        }

        public override string GetResponse(PersonalityChatResults personalityChatResults)
        {
            var matchedScenarios = personalityChatResults?.ScenarioList;

            string response = string.Empty;

            if (matchedScenarios != null)
            {
                var topScenario = matchedScenarios.FirstOrDefault();

                if (topScenario?.Responses != null && topScenario.Score > this._personalityChatDialogOptions.ScenarioThresholdScore && topScenario.Responses.Count > 0)
                {
                    Random randomGenerator = new Random();
                    int randomIndex = randomGenerator.Next(topScenario.Responses.Count);

                    response = topScenario.Responses[randomIndex];
                }
                else
                {
                    response = "Enough chit-chat! What do you want?";
                }
            }
            
            return response;
        }
    }
}