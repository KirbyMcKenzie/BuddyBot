using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using BuddyBot.Dialogs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Connector;
using Serilog;

namespace BuddyBot.Controllers
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                try
                {
                    using (ILifetimeScope scope = DialogModule.BeginLifetimeScope(Conversation.Container, activity))
                    {
                        var internalScope = scope;
                        await Conversation.SendAsync(activity, () => internalScope.Resolve<RootLuisDialog>());
                    }
                }
                catch (Exception ex)
                {
                    // TODO - Add Logging, Telemetry
                    Log.Error(ex, "An unexpected error occured.");
                    throw;

                }
            }
            else
            {
                await HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        // TODO - Make Async
        private async Task<Activity> HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
                
                // TODO - ConversationUpdate - Come back to
                //IConversationUpdateActivity update = message;
                //using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
                //{
                //    if (update.MembersAdded.Any())
                //    {
                //        foreach (var newMember in update.MembersAdded)
                //        {
                //            if (newMember.Id != message.Recipient.Id)
                //            {
                //                var internalScope = scope;
                //                await Conversation.SendAsync(message, () => internalScope.Resolve<ConfirmRobotDialog>());
                //            }
                //        }
                //    }
                //}
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}