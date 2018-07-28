using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using BuddyBot.Dialogs.Interfaces;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace BuddyBot.Dialogs.Builders
{
    public class DialogBuilder : IDialogBuilder
    {
        public ConfirmRobotDialog BuildConfirmRobotDialog(IMessageActivity message)
        {
            return CreateDialog(message, s => s.Resolve<ConfirmRobotDialog>());
        }

        public GetWeatherForecastDialog BuilGetWeatherForecastDialog(IMessageActivity message,
            IList<EntityRecommendation> result)
        {
            return CreateDialog(message, s => s.Resolve<GetWeatherForecastDialog>(TypedParameter.From(result)));
        }

        public RandomNumberDialog BuildRandomNumberDialog(IMessageActivity message, IList<EntityRecommendation> result)
        {
            return CreateDialog(message, s => s.Resolve<RandomNumberDialog>(TypedParameter.From(result)));
        }

        public BasicPersonalityChatBotDialog BuildBasicPersonalityChatBotDialog(IMessageActivity message, IList<EntityRecommendation> result)
        {
            return CreateDialog(message, s => s.Resolve<BasicPersonalityChatBotDialog>(TypedParameter.From(result)));
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