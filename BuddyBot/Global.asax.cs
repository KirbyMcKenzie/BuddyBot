using System;
using System.Configuration;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using BuddyBot.Modules;
using BuddyBot.Repository.DbContext;
using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;

namespace BuddyBot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Conversation.UpdateContainer(Update);

            GlobalConfiguration.Configuration.DependencyResolver = 
                new AutofacWebApiDependencyResolver(Conversation.Container);

            GlobalConfiguration.Configure(WebApiConfig.Register);

        }

        private void Update(ContainerBuilder containerBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Default"];

            var optionsBuilder = new DbContextOptionsBuilder<BuddyBotDbContext>();
            optionsBuilder.UseSqlServer(connectionString.ConnectionString);

            containerBuilder.RegisterInstance(optionsBuilder.Options).AsSelf();

            containerBuilder.RegisterModule(new ReflectionSurrogateModule());
            containerBuilder.RegisterModule(new DialogModule());

            containerBuilder.RegisterModule<ApplicationModule>();
        }
    }
}