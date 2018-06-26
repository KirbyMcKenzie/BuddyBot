using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using BuddyBot.Dialogs;
using BuddyBot.Dialogs.Builders;
using BuddyBot.Dialogs.Interfaces;
using Microsoft.Bot.Builder.Internals.Fibers;

namespace BuddyBot.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<DialogBuilder>()
                .Keyed<IDialogBuilder>(FiberModule.Key_DoNotSerialize)
                .AsImplementedInterfaces().SingleInstance();

            builder.RegisterType<RootLuisDialog>().AsSelf().InstancePerDependency();

            builder.RegisterType<ConfirmRobotDialog>().AsSelf().InstancePerDependency();
            builder.RegisterType<RandomNumberDialog>().AsSelf().InstancePerDependency();
        }
    }
}