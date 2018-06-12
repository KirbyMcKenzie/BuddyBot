using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BuddyBot.Contracts;

namespace BuddyBot.Services
{
    public class LanguageService : ILanguageService
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
                "What up? 🤖",
                "What new?",
                "Yo",
                "Yo 😎",
                "What can I do for you? 🤖",
                "How's it?",
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
    }
}