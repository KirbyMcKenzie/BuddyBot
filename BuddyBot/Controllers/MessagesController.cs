using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using BuddyBot.Dialogs;
using BuddyBot.Services;
using BuddyBot.Services.Contracts;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Connector;
using Microsoft.Rest;
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
                    // TODO - Make length of typing random
                    // Sends typing indicator to user
                    var connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                    Activity isTypingReply = activity.CreateReply();
                    isTypingReply.Type = ActivityTypes.Typing;
                    await connector.Conversations.ReplyToActivityAsync(isTypingReply);


                    using (ILifetimeScope scope = DialogModule.BeginLifetimeScope(Conversation.Container, activity))
                    {
                        IBotData botData = scope.Resolve<IBotData>();
                        await botData.LoadAsync(new System.Threading.CancellationToken());

                        var result = dataService.hasCompletedGetStarted(botData);

                        if (result)
                        {
                            var internalScope = scope;
                            await Conversation.SendAsync(activity, () => internalScope.Resolve<RootLuisDialog>());
                        }
                        else
                        {
                            var internalScope = scope;
                            await Conversation.SendAsync(activity, () => internalScope.Resolve<RootLuisDialog>());
                        }
                    }
                }
               
                catch (Exception ex)
                {
                   Log.Error(ex, $"An unexpected error occurred, error details: {ex.Message}");
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
        private Task<Activity> HandleSystemMessage(Activity message)
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

            return null;
        }
    }
}