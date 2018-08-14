using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BuddyBot.Services.Contracts;
using Microsoft.Azure.Documents.SystemFunctions;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.PersonalityChat.Core;
using Microsoft.Bot.Builder.PersonalityChat;
using Microsoft.Bot.Connector;

namespace BuddyBot.Dialogs
{
    [Serializable]
    public class PersonalityChatDialog : PersonalityChatDialog<object>
    {
        private readonly IBotDataService _botDataService;

        private readonly PersonalityChatDialogOptions _personalityChatDialogOptions = new PersonalityChatDialogOptions()
        {
            RespondOnlyIfChat = false,
            ScenarioThresholdScore = 0.2f,
        };

        public PersonalityChatDialog(IBotDataService botDataService, IDialogContext context)
        {
            SetField.NotNull(out _botDataService, nameof(botDataService), botDataService);

            // TODO - null check
            var preferredBotPersona = _botDataService.GetPreferredBotPersona(context);

            var scenarioResponses = File.ReadAllLines(System.Web.Hosting.HostingEnvironment.MapPath($"/Scenario_Responses_{preferredBotPersona}.tsv")
                             ?? throw new InvalidOperationException());

            var scenarioResponsesMapping = new Dictionary<string, List<string>>();

            foreach (var scenarioResponse in scenarioResponses)
            {
                string scenario = scenarioResponse.Split('\t')[0];
                string response = scenarioResponse.Split('\t')[1];

                if (!scenarioResponsesMapping.ContainsKey(scenario))
                {
                    scenarioResponsesMapping[scenario] = new List<string>();
                }

                scenarioResponsesMapping[scenario].Add(response);
            }

            var personalityChatDialogOptions = new PersonalityChatDialogOptions(
                scenarioResponsesMapping: scenarioResponsesMapping,
                scenarioThresholdScore: _personalityChatDialogOptions.ScenarioThresholdScore,
                respondOnlyIfChat: _personalityChatDialogOptions.RespondOnlyIfChat);

            this.SetPersonalityChatDialogOptions(personalityChatDialogOptions);
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