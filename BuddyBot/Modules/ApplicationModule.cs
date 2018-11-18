using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Autofac;
using BuddyBot.Dialogs;
using BuddyBot.Dialogs.Builders;
using BuddyBot.Logging;
using BuddyBot.Repository.DataAccess;
using BuddyBot.Repository.DataAccess.Contracts;
using BuddyBot.Repository.DbContext;
using BuddyBot.Services;
using BuddyBot.Services.Contracts;
using BuddyBot.Settings;
using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Connector;

namespace BuddyBot.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            AzureStorageSettings azureStorageSettings = new AzureStorageSettings();
            builder.Register(c => azureStorageSettings).As<IAzureStorageSettings>().SingleInstance();

            // Data Storage
            string serviceName = "noncached";
            builder.Register(c =>
                {
                    IAzureStorageSettings settings = c.Resolve<IAzureStorageSettings>();
                    IBotDataStore<BotData> store;
                    if (string.IsNullOrWhiteSpace(settings.ConnectionString))
                    {

                        store = new InMemoryDataStore();
                    }
                    else
                    {
                        store = new TableBotDataStore(settings.ConnectionString);
                    }
                    return store;
                })
                .Named(serviceName, typeof(IBotDataStore<BotData>))
                .Keyed<IBotDataStore<BotData>>(AzureModule.Key_DataStore)
                .AsSelf()
                .SingleInstance();

            builder.Register(c =>
                    new CachingBotDataStore(c.ResolveNamed<IBotDataStore<BotData>>(serviceName),
                        CachingBotDataStoreConsistencyPolicy.ETagBasedConsistency))
                .As<IBotDataStore<BotData>>()
                .AsSelf()
                .InstancePerLifetimeScope();

            // Message Interceptor
            builder.RegisterType<ActivityLogger>().AsImplementedInterfaces().InstancePerDependency();

            // Data Access

            builder.RegisterType<BuddyBotDbContext>().InstancePerLifetimeScope();

            builder.RegisterType<WeatherConditionResponseReader>()
                .As<IWeatherConditionResponseReader>()
                .AsImplementedInterfaces().SingleInstance();

            builder.RegisterType<ChatHistoryWriter>()
                .As<IChatHistoryWriter>()
                .AsImplementedInterfaces().SingleInstance();

            // Services
            builder.RegisterType<BotDataService>()
                .Keyed<IBotDataService>(FiberModule.Key_DoNotSerialize)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

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
            builder.RegisterType<NameDialog>().AsSelf().InstancePerDependency();
            builder.RegisterType<BotPersonaDialog>().AsSelf().InstancePerDependency();
            builder.RegisterType<PreferredWeatherLocationDialog>().AsSelf().InstancePerDependency();
            builder.RegisterType<DeleteUserDataDialog>().AsSelf().InstancePerDependency();
            builder.RegisterType<GetStartedDialog>().AsSelf().InstancePerDependency();

        }
    }
}