﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BuddyBot.Contracts;

namespace BuddyBot.Services
{
    public class GreetingService : IGreetingService
    {
        

        public async Task<string> GetRandomGreeting()
        {
            IList<string> greetingList = getGreetingList();


            // add items to the list
            Random r = new Random();
            int index = r.Next(greetingList.Count);
            string randomString = greetingList[index];

            await Task.Yield();

            return randomString;
        }


        private List<string> getGreetingList()
        {

         List<string> greetingList = new List<string>();

        greetingList.AddRange(new List<string>
            {
                "Hey",
                "Hello",
                "Hiya",
                "Yo",
                "What can I do for you?",
                "How's it?",
                "G'day M8"
            });

            return greetingList;

        }
    }
}