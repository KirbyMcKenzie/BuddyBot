using Autofac;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Connector;
using System.Configuration;
using TechieBot.Dialogs;

namespace TechieBot.DIContainer
{
    internal sealed class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register(c => new LuisModelAttribute(ConfigurationManager.AppSettings["luis:ModelId"],
                ConfigurationManager.AppSettings["luis:SubscriptionId"])).AsSelf().AsImplementedInterfaces().SingleInstance();

            // Top Level Dialog
            builder.RegisterType<RootLUISDialog>().As<LuisDialog<IMessageActivity>>().InstancePerDependency();

            // Singlton services
            builder.RegisterType<LuisService>().Keyed<ILuisService>(FiberModule.Key_DoNotSerialize).AsImplementedInterfaces().SingleInstance();
        }
    }
}