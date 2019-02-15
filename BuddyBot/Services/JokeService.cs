using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BuddyBot.Models.Dtos;
using BuddyBot.Services.Contracts;
using Newtonsoft.Json;

namespace BuddyBot.Services
{
    public class JokeService : IJokeService
    {
        private readonly string _jokeRequestUrl = ConfigurationManager.AppSettings["jokeApi:requestUrl"];

        /// <summary>
        /// Gets random joke from JokeAPI.
        /// </summary>
        public async Task<string> GetRandomJoke()
        {
            
                HttpClient client = new HttpClient { BaseAddress = new Uri(_jokeRequestUrl) };
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(_jokeRequestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jokeString = await response.Content.ReadAsStringAsync();

                    var jokeDto = JsonConvert.DeserializeObject<JokeDto>(jokeString);

                    return jokeDto.Joke;
                }

                return "I'm having problems computing a joke. Please try again later";
        }
    }
}