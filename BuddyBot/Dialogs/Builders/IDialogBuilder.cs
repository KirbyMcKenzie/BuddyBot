using System.Collections.Generic;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.PersonalityChat.Core;
using Microsoft.Bot.Connector;

namespace BuddyBot.Dialogs.Builders
{
    public interface IDialogBuilder
    {
        ConfirmRobotDialog BuildConfirmRobotDialog(IMessageActivity message);

        // Weather
        GetWeatherForecastDialog BuilGetWeatherForecastDialog(IMessageActivity message,
            IList<EntityRecommendation> result);

        // Random Number
        RandomNumberDialog BuildRandomNumberDialog(IMessageActivity message, IList<EntityRecommendation> result);

        // Personality Chat
        PersonalityChatDialog BuildBasicPersonalityChatBotDialog(IMessageActivity message, IList<EntityRecommendation> result);

        // Preferred Name 
        NameDialog BuildNameDialog(IMessageActivity message, IList<EntityRecommendation> result);

        // Preferred Bot Personality
        BotPersonaDialog BuildBotPersonaDialog(IMessageActivity message, IList<EntityRecommendation> result);

        BotPersonaDialog BuildBotPersonaDialog(IMessageActivity message, PersonalityChatPersona botPersona);

        // Preferred Weather Location 
        PreferredWeatherLocationDialog BuildPreferredWeatherLocationDialog(IMessageActivity message, IList<EntityRecommendation> result);

        // Delete User Data
        DeleteUserDataDialog BuildDeleteUserDataDialog(IMessageActivity message);

        // Get Started
        GetStartedDialog BuildGetStartedDialog(IMessageActivity message);


    }
}