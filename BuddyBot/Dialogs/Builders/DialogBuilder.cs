using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Builder.PersonalityChat.Core;
using Microsoft.Bot.Connector;

namespace BuddyBot.Dialogs.Builders
{
    public class DialogBuilder : IDialogBuilder
    {
        public ConfirmRobotDialog BuildConfirmRobotDialog(IMessageActivity message)
        {
            return CreateDialog(message, s => s.Resolve<ConfirmRobotDialog>());
        }

        public GetWeatherForecastDialog BuilGetWeatherForecastDialog(IMessageActivity message,IList<EntityRecommendation> result)
        {
            return CreateDialog(message, s => s.Resolve<GetWeatherForecastDialog>(TypedParameter.From(result)));
        }

        public RandomNumberDialog BuildRandomNumberDialog(IMessageActivity message, IList<EntityRecommendation> result)
        {
            return CreateDialog(message, s => s.Resolve<RandomNumberDialog>(TypedParameter.From(result)));
        }

        public PersonalityChatDialog BuildBasicPersonalityChatBotDialog(IMessageActivity message, IList<EntityRecommendation> result)
        {
            return CreateDialog(message, s => s.Resolve<PersonalityChatDialog>(TypedParameter.From(result)));
        }

        public NameDialog BuildNameDialog(IMessageActivity message, IList<EntityRecommendation> result)
        {
            return CreateDialog(message, s => s.Resolve<NameDialog>(TypedParameter.From(result)));
        }

        public BotPersonaDialog BuildBotPersonaDialog(IMessageActivity message, IList<EntityRecommendation> result)
        {
            return CreateDialog(message, s => s.Resolve<BotPersonaDialog>(TypedParameter.From(result)));
        }

        public BotPersonaDialog BuildBotPersonaDialog(IMessageActivity message, PersonalityChatPersona botPersona)
        {
            return CreateDialog(message, s => s.Resolve<BotPersonaDialog>(TypedParameter.From(botPersona)));
        }

        public PreferredWeatherLocationDialog BuildPreferredWeatherLocationDialog(IMessageActivity message, IList<EntityRecommendation> result)
        {
            return CreateDialog(message, s => s.Resolve<PreferredWeatherLocationDialog>(TypedParameter.From(result)));
        }

        public DeleteUserDataDialog BuildDeleteUserDataDialog(IMessageActivity message)
        {
            return CreateDialog(message, s => s.Resolve<DeleteUserDataDialog>());
        }

        public GetStartedDialog BuildGetStartedDialog(IMessageActivity message)
        {
            return CreateDialog(message, s => s.Resolve<GetStartedDialog>());
        }

        private T CreateDialog<T>(IMessageActivity message, Func<ILifetimeScope, T> func)
        {
            using (var scope = CreateDialogLifetimeScope(message))
            {
                return func(scope);
            }
        }

        private static ILifetimeScope CreateDialogLifetimeScope(IMessageActivity message)
        {
            return DialogModule.BeginLifetimeScope(Conversation.Container, message);
        }

        
    }
}