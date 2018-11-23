using System.Collections.Generic;
using BuddyBot.Models.Enums;
using Microsoft.Bot.Builder.Luis.Models;
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

        RootLuisDialog BuildRootLuisDialog(IMessageActivity message);

        NameDialog BuildNameDialog(IMessageActivity message);

        NameDialog BuildNameDialog(IMessageActivity message, IList<EntityRecommendation> result);

        BotPersonaDialog BuildBotPersonaDialog(IMessageActivity message, IList<EntityRecommendation> result, PersonalityChatPersona botPersona);

        PreferredWeatherLocationDialog BuildPreferredWeatherLocationDialog(IMessageActivity message);

        PreferredWeatherLocationDialog BuildPreferredWeatherLocationDialog(IMessageActivity message, IList<EntityRecommendation> result);

        DeleteUserDataDialog BuildDeleteUserDataDialog(IMessageActivity message, IList<EntityRecommendation> result);

        GetStartedDialog BuildGetStartedDialog(IMessageActivity message);


    }
}