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

            // add items to the list
            Random r = new Random();
            int index = r.Next(greetingList.Count);
            string randomString = greetingList[index];

            await Task.Yield();

            return randomString;
        }

        public string GetHowCanIHelpPhrase()
        {
            IList<string> howCanIHelpPhraseList = GetHowCanIHelpPhraseList();

            // add items to the list
            Random r = new Random();
            int index = r.Next(howCanIHelpPhraseList.Count);
            string randomString = howCanIHelpPhraseList[index];

            return randomString;
        }

        private IList<string> GetHowCanIHelpPhraseList()
        {
            List<string> canIHelpPhraseList = new List<string>();


            canIHelpPhraseList.AddRange(new List<string>
            {
                "What can I do for you today?",
                "Okay, is there anything I can do for you today?",
                "Can I help with anything else?",
                "Let's move on. What can I help with?",
            });

            return canIHelpPhraseList;
        }

        // TODO - Pull to db 
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
                    $"Sup {name}",
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
                "Howdy!",
                "Sup m8",
                "Yo 😎",
                "Yoooo",
                "G'day M8",
                "What can I do for you today?",
                "Hows it going?",
                "Hey, how are you today?",
            });

            return greetingList;
        }

        public async Task<string> GetResponseByIntentName(string intentName, PersonalityChatPersona persona)
        {

            if (persona == PersonalityChatPersona.None)
            {
                persona = PersonalityChatPersona.Friendly;
            }

            IList<SmallTalkResponse> result = await _smallTalkResponseReader.GetSmallTalkResponsesByIntentName(intentName, persona.ToString());

            Random random = new Random();

            return result[random.Next(result.Count)].IntentResponse;

        }
    }
}