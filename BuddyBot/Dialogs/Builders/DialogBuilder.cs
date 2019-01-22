using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using BuddyBot.Models.Enums;
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

        public GetWeatherForecastDialog BuilGetWeatherForecastDialog(IMessageActivity message,IList<EntityRecommendation> result)
        {
            return CreateDialog(message, s => s.Resolve<GetWeatherForecastDialog>(TypedParameter.From(result)));
        }

        public RandomNumberDialog BuildRandomNumberDialog(IMessageActivity message, IList<EntityRecommendation> result)
        {
            return CreateDialog(message, s => s.Resolve<RandomNumberDialog>(TypedParameter.From(result)));
        }

        public RootLuisDialog BuildRootLuisDialog(IMessageActivity message)
        {
            return CreateDialog(message, s => s.Resolve<RootLuisDialog>());
        }

        public NameDialog BuildNameDialog(IMessageActivity message)
        {
            return CreateDialog(message, s => s.Resolve<NameDialog>());
        }

        public NameDialog BuildNameDialog(IMessageActivity message, IList<EntityRecommendation> result)
        {
            return CreateDialog(message, s => s.Resolve<NameDialog>(TypedParameter.From(result)));
        }

        public BotPersonaDialog BuildBotPersonaDialog(IMessageActivity message, IList<EntityRecommendation> result, PersonalityChatPersona persona)
        {
            return CreateDialog(message, s => s.Resolve<BotPersonaDialog>(TypedParameter.From(result), TypedParameter.From(persona)));
        }

        public BotPersonaDialog BuildBotPersonaDialog(IMessageActivity message, PersonalityChatPersona result)
        {
            return CreateDialog(message, s => s.Resolve<BotPersonaDialog>(TypedParameter.From(result)));
        }

        public PreferredWeatherLocationDialog BuildPreferredWeatherLocationDialog(IMessageActivity message)
        {
            return CreateDialog(message, s => s.Resolve<PreferredWeatherLocationDialog>());
        }

        public PreferredWeatherLocationDialog BuildPreferredWeatherLocationDialog(IMessageActivity message, IList<EntityRecommendation> result)
        {
            return CreateDialog(message, s => s.Resolve<PreferredWeatherLocationDialog>(TypedParameter.From(result)));
        }


        public DeleteUserDataDialog BuildDeleteUserDataDialog(IMessageActivity message, IList<EntityRecommendation> result)
        {
            return CreateDialog(message, s => s.Resolve<DeleteUserDataDialog>(TypedParameter.From(result)));
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