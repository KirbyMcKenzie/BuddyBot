using System.Collections.Generic;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.PersonalityChat.Core;
using Microsoft.Bot.Connector;

namespace BuddyBot.Dialogs.Builders
{
    public interface IDialogBuilder
    {
        ConfirmRobotDialog BuildConfirmRobotDialog(IMessageActivity message);

        GetWeatherForecastDialog BuilGetWeatherForecastDialog(IMessageActivity message,
            IList<EntityRecommendation> result);

        RandomNumberDialog BuildRandomNumberDialog(IMessageActivity message, IList<EntityRecommendation> result);

        PersonalityChatDialog BuildBasicPersonalityChatBotDialog(IMessageActivity message, IList<EntityRecommendation> result);

        NameDialog BuildNameDialog(IMessageActivity message);

        NameDialog BuildNameDialog(IMessageActivity message, IList<EntityRecommendation> result);

        BotPersonaDialog BuildBotPersonaDialog(IMessageActivity message, PersonalityChatPersona botPersona);

        BotPersonaDialog BuildBotPersonaDialog(IMessageActivity message, IList<EntityRecommendation> result);

        PreferredWeatherLocationDialog BuildPreferredWeatherLocationDialog(IMessageActivity message);

        PreferredWeatherLocationDialog BuildPreferredWeatherLocationDialog(IMessageActivity message, IList<EntityRecommendation> result);

        DeleteUserDataDialog BuildDeleteUserDataDialog(IMessageActivity message);

        GetStartedDialog BuildGetStartedDialog(IMessageActivity message);


    }
}