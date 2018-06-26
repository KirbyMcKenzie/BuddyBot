using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using BuddyBot.Modules;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Internals.Fibers;

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
            containerBuilder.RegisterModule(new ReflectionSurrogateModule());
            containerBuilder.RegisterModule(new DialogModule());

            containerBuilder.RegisterModule<DialogsModule>();
        }
    }
}