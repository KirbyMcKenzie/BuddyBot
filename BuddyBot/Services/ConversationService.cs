using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BuddyBot.Contracts;

namespace BuddyBot.Services
{
    public class ConversationService : IConversationService
    {
        
        public async Task<string> GetGreeting()
        {
            IList<string> greetingList = getGreetingList();

            // add items to the list
            Random r = new Random();
            int index = r.Next(greetingList.Count);
            string randomString = greetingList[index];

            await Task.Yield();

            return randomString;
        }

        public async Task<string> GetPoliteExpression()
        {
            IList<string> politeExpressionList = getPoliteExpressionList();

            // add items to the list
            Random r = new Random();
            int index = r.Next(politeExpressionList.Count);
            string politeExpression = politeExpressionList[index];

            await Task.Yield();

            return politeExpression;
        }

        public async Task<string> GetHowsItPrompt()
        {
            IList<string> greetingList = GetHowsItPromptList();

            // add items to the list
            Random r = new Random();
            int index = r.Next(greetingList.Count);
            string randomString = greetingList[index];

            await Task.Yield();

            return randomString;
        }

        public async Task<string> GetHowsItResultGood()
        {
            IList<string> greetingList = getHowsItResultGoodList();

            // add items to the list
            Random r = new Random();
            int index = r.Next(greetingList.Count);
            string randomString = greetingList[index];

            await Task.Yield();

            return randomString;
        }


        // TODO - Pull to db 
        // TODO - Get users name
        // TODO - Emoji detection and handler
        private List<string> GetHowsItPromptList()
        {

            List<string> howsItPromptList = new List<string>();

            howsItPromptList.AddRange(new List<string>
            {
                // TODO Get - users name and add to string 
                // TODO - Add more
                "I'm well thanks 😀",
                "I'm good thanks 😊 how are you?",
                "It's good, you?",
                "gr8 m8 u?",
                "Can't complain, you?",
                "I'm well thank you, how are you?",
                "I'm doing fine, how are you today?"
            });

            return howsItPromptList;
        }


        // TODO - Pull to db 
        // TODO - Get users name
        // TODO - Emoji detection and handler
        private List<string> getGreetingList()
        {
            
         List<string> greetingList = new List<string>();

        greetingList.AddRange(new List<string>
            {
                // TODO Get users name and add to string 
                "Hi hi 😊",
                "Hi there!",
                "Hiya",
                "Hey",
                "Hello",
                "Heya 😁",
                "Howdy!",
                "Sup m8",
                "Sup",
                "Yo",
                "Yo 😎",
                "What can I do for you? 🤖",
                "G'day M8"
            });

            return greetingList;
        }

        // TODO - Pull to db 
        // TODO - Get users name
        // TODO - Emoji detection and handler
        private List<string> getPoliteExpressionList()
        {

            List<string> politeExpressionList = new List<string>();

            politeExpressionList.AddRange(new List<string>
            {
                "Cheers",
                "Cheers 😁",
                "Thanks 😁",
                "Thanks M8",
                "Thank you 😁",
            });

            return politeExpressionList;
        }

        // TODO - Pull to db 
        // TODO - Get users name
        // TODO - Emoji detection and handler
        private List<string> getHowsItResultGoodList()
        {

            List<string> howsItResultGoodList = new List<string>();

            howsItResultGoodList.AddRange(new List<string>
            {
                "That's great 😁",
                "Good to hear, what can I do for you?",
                "Thats cool 😎",
            });

            return howsItResultGoodList;
        }

    }
}