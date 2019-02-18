using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BuddyBot.Repository.DataAccess.Contracts;
using BuddyBot.Repository.Models;
using BuddyBot.Services.Contracts;
using PersonalityChatPersona = BuddyBot.Models.Enums.PersonalityChatPersona;
namespace BuddyBot.Services
{
    public class ConversationService : IConversationService
    {
        private readonly ISmallTalkResponseReader _smallTalkResponseReader;

        public ConversationService(ISmallTalkResponseReader smallTalkResponseReader)
        {
            _smallTalkResponseReader = smallTalkResponseReader;
        }

        public async Task<string> GetGreeting(string name = null)
        {
            IList<string> greetingList = getGreetingList(name);

            Random r = new Random();
            int index = r.Next(greetingList.Count);
            string randomString = greetingList[index];

            await Task.Yield();

            return randomString;
        }

        private List<string> getGreetingList(string name = null)
        {
            
         List<string> greetingList = new List<string>();

            if (!string.IsNullOrEmpty(name))
            {
                greetingList.AddRange(new List<string>
                {
                    $"Hows it going, {name}",
                    $"Hiya {name}",
                    $"Hey {name}",
                    $"Howdy {name}",
                    $"What can I do for you {name}? 🤖",
                    $"Hey {name}! 😁",
                    $"Hey {name}, how are you today?",
                    $"Whats up, {name}?",
                });
            }

            greetingList.AddRange(new List<string>
            {
                "Hi there!",
                "Hiya",
                "Hello",
                "Heya 😁",
                "Hey mate",
                "Howdy!",
                "Yo 😎",
                "Yoooo",
                "G'day mate",
                "Hey, what can I do for you today?",
                "Hows it going?",
                "Hey, how are you today?",
            });

            return greetingList;
        }

        /// <summary>
        /// Queries database with smalltalk responses by given LUIS intentName and persona.
        /// </summary>
        /// <param name="intentName">The name of the LUIS intent.</param>
        /// <param name="persona">The users preferred bot persona.</param>
        public async Task<string> GetResponseByIntentName(string intentName, PersonalityChatPersona persona)
        {

            // Let's not get away empty handed.
            if (persona == PersonalityChatPersona.None)
            {
                persona = PersonalityChatPersona.Friendly;
            }

            IList<SmallTalkResponse> result = await _smallTalkResponseReader.GetSmallTalkResponsesByIntentName(intentName, persona.ToString());
            
            if(result == null || result.Count == 0)
            {
                // Could not match in Database, try divert conversation.
                return "Let's move on. What can I help with?";
            }

            // Keep conversation fresh by randomly picking one response from list.
            Random random = new Random();
            return result[random.Next(result.Count)].IntentResponse;
        }
    }
}