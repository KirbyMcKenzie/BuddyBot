using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Autofac;
using BuddyBot.Dialogs;
using BuddyBot.Dialogs.Builders;
using BuddyBot.Dialogs.Interfaces;
using BuddyBot.Repository.DataAccess;
using BuddyBot.Repository.DataAccess.Contracts;
using BuddyBot.Repository.DbContext;
using BuddyBot.Services;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Connector;
using Microsoft.EntityFrameworkCore;

namespace BuddyBot.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // Data Storage
            // TODO - Move to settings
            var store = new TableBotDataStore(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ConnectionString);

            builder.Register(c => store)
                .Keyed<IBotDataStore<BotData>>(AzureModule.Key_DataStore)
                .AsSelf()
                .SingleInstance();

            builder.Register(c => new CachingBotDataStore(store,
                    CachingBotDataStoreConsistencyPolicy
                        .ETagBasedConsistency))
                .As<IBotDataStore<BotData>>()
                .AsSelf()
                .InstancePerLifetimeScope();


            // Data Access

            builder.RegisterType<BuddyBotDbContext>().InstancePerLifetimeScope();

            builder.RegisterType<WeatherConditionResponseReader>()
                .As<IWeatherConditionResponseReader>()
                .AsImplementedInterfaces().SingleInstance();

            // Services 
            builder.RegisterType<ConversationService>()
                .Keyed<IConversationService>(FiberModule.Key_DoNotSerialize)
                .AsImplementedInterfaces().SingleInstance();

            builder.RegisterType<HeadTailsService>()
                .Keyed<IHeadTailsService>(FiberModule.Key_DoNotSerialize)
                .AsImplementedInterfaces().SingleInstance();

            builder.RegisterType<JokeService>()
                .Keyed<IJokeService>(FiberModule.Key_DoNotSerialize)
                .AsImplementedInterfaces().SingleInstance();

            builder.RegisterType<WeatherService>()
                .Keyed<IWeatherService>(FiberModule.Key_DoNotSerialize)
                .AsImplementedInterfaces().SingleInstance();

            // Builders 
            builder.RegisterType<DialogBuilder>()
                .Keyed<IDialogBuilder>(FiberModule.Key_DoNotSerialize)
                .AsImplementedInterfaces().SingleInstance();

            // Root Dialog
            builder.RegisterType<RootLuisDialog>().AsSelf().InstancePerDependency();

            // Child Dialogs
            builder.RegisterType<ConfirmRobotDialog>().AsSelf().InstancePerDependency();
            builder.RegisterType<RandomNumberDialog>().AsSelf().InstancePerDependency();
            builder.RegisterType<GetWeatherForecastDialog>().AsSelf().InstancePerDependency();
            builder.RegisterType<PersonalityChatDialog>().AsSelf().InstancePerDependency();
        }
    }
}